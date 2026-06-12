using HealthCare.Shared;
using HealthCareApi;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HealthCare.Tests
{
    [TestClass]
    public class AppointmentServiceTests
    {
        private Mock<IAppointmentRepository> _repoMock;
        private AppointmentService _service;

        [TestInitialize]
        public void Setup()
        {
            _repoMock = new Mock<IAppointmentRepository>();

            _service = new AppointmentService(
                _repoMock.Object
            );
        }

        //  BOOK APPOINTMENT SUCCESS
        [TestMethod]
        public async Task BookAppointment_ShouldReturnPending_WhenValid()
        {
            var appt = new Appointment
            {
                PatientId = 1,
                DoctorId = 2,
                ScheduledDate = DateTime.Today.AddDays(1),
                TimeSlot = "10:00-10:30"
            };

            //  FIX: use repo instead of context
            _repoMock.Setup(r => r.PatientExistsAsync(1)).ReturnsAsync(true);
            _repoMock.Setup(r => r.DoctorExistsAsync(2)).ReturnsAsync(true);

            _repoMock.Setup(r => r.SlotExistsAsync(2, "10:00-10:30"))
                .ReturnsAsync(true);

            _repoMock.Setup(r => r.IsSlotBookedAsync(2, appt.ScheduledDate, "10:00-10:30"))
                .ReturnsAsync(false);

            _repoMock.Setup(r => r.AddAsync(It.IsAny<Appointment>()))
                .Returns(Task.CompletedTask);

            var result = await _service.BookAppointmentAsync(appt);

            Assert.IsNotNull(result);
            Assert.AreEqual("Pending", result.Status);
        }

        //  INVALID PATIENT
        [TestMethod]
        public async Task BookAppointment_ShouldReturnNull_WhenPatientInvalid()
        {
            var appt = new Appointment
            {
                PatientId = 1,
                DoctorId = 2
            };

            _repoMock.Setup(r => r.PatientExistsAsync(1)).ReturnsAsync(false);

            var result = await _service.BookAppointmentAsync(appt);

            Assert.IsNull(result);
        }


        //  SLOT ALREADY BOOKED
        [TestMethod]
        public async Task BookAppointment_ShouldReturnNull_WhenSlotAlreadyBooked()
        {
            var appt = new Appointment
            {
                PatientId = 1,
                DoctorId = 2,
                ScheduledDate = DateTime.Today.AddDays(1),
                TimeSlot = "10:00-10:30"
            };

            _repoMock.Setup(r => r.PatientExistsAsync(1)).ReturnsAsync(true);
            _repoMock.Setup(r => r.DoctorExistsAsync(2)).ReturnsAsync(true);
            _repoMock.Setup(r => r.SlotExistsAsync(2, "10:00-10:30")).ReturnsAsync(true);

            _repoMock.Setup(r =>
                r.IsSlotBookedAsync(2, appt.ScheduledDate, "10:00-10:30"))
                .ReturnsAsync(true);

            var result = await _service.BookAppointmentAsync(appt);

            Assert.IsNull(result);
        }

        //  CONFIRM SUCCESS
        [TestMethod]
        public async Task ConfirmAppointment_ShouldSetConfirmed()
        {
            var appt = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appt);
            _repoMock.Setup(r => r.UpdateAsync(appt)).Returns(Task.CompletedTask);

            var result = await _service.ConfirmAppointmentAsync(1);

            Assert.AreEqual("Confirmed", result.Status);
        }

        //  CONFIRM FAIL (Cancelled)
        [TestMethod]
        public async Task ConfirmAppointment_ShouldReturnNull_WhenCancelled()
        {
            var appt = new Appointment
            {
                AppointmentId = 1,
                Status = "Cancelled"
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appt);

            var result = await _service.ConfirmAppointmentAsync(1);

            Assert.IsNull(result);
        }

        //  CANCEL SUCCESS
        [TestMethod]
        public async Task CancelAppointment_ShouldSetCancelled()
        {
            var appt = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appt);
            _repoMock.Setup(r => r.UpdateAsync(appt)).Returns(Task.CompletedTask);

            var result = await _service.CancelAppointmentAsync(1, "Reason");

            Assert.AreEqual("Cancelled", result.Status);
            Assert.AreEqual("Reason", result.CancellationReason);
        }

        //  CANCEL FAIL (No reason)
        [TestMethod]
        public async Task CancelAppointment_ShouldReturnNull_WhenReasonEmpty()
        {
            var appt = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(appt);

            var result = await _service.CancelAppointmentAsync(1, "");

            Assert.IsNull(result);
        }


        //  AVAILABLE SLOTS
        [TestMethod]
        public async Task GetAvailableSlots_ShouldReturnOnlyFreeSlots()
        {
            _repoMock.Setup(r => r.GetDoctorSlotsAsync(1))
                .ReturnsAsync(new List<string> { "10:00", "10:30", "11:00" });

            _repoMock.Setup(r => r.GetBookedSlotsAsync(1, It.IsAny<DateTime>()))
                .ReturnsAsync(new List<string> { "10:30" });

            var result = await _service.GetAvailableSlotsAsync(1, DateTime.Today);

            Assert.IsTrue(result.Contains("10:00"));
            Assert.IsTrue(result.Contains("11:00"));
            Assert.IsFalse(result.Contains("10:30"));
        }

        //  GET UPCOMING
        [TestMethod]
        public async Task GetUpcomingAppointments_ShouldReturnData()
        {
            var data = new PagedResult<Appointment>
            {
                Items = new List<Appointment>(),
                TotalCount = 0
            };

            _repoMock.Setup(r => r.GetUpcomingAppointmentsAsync(null, null, 1, 10))
                .ReturnsAsync(data);

            var result = await _service.GetUpcomingAppointmentsAsync(null, null, 1, 10);

            Assert.IsNotNull(result);
        }
    }
}