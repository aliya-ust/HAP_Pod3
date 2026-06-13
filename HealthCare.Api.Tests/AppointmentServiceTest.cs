using HealthCare.Api;
using HealthCare.Shared;
using HealthCareApi.Repositories.Interfaces;
using HealthCareApi.Services.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HealthCareApi.Tests.Services
{
    public class AppointmentServiceTest
    {
        private readonly Mock<IAppointmentRepository> _appointmentRepoMock;
        private readonly AppointmentService _service;

        public AppointmentServiceTest()
        {
            _appointmentRepoMock = new Mock<IAppointmentRepository>();

            // Mock context
            var contextMock = new Mock<HealthCare.Api.HealthAppDbContext>();

            _service = new AppointmentService(
                _appointmentRepoMock.Object,
                contextMock.Object);
        }

        #region ConfirmAppointmentAsync

        [Fact]
        public async Task ConfirmAppointmentAsync_ShouldConfirmAppointment_WhenValid()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act
            var result = await _service.ConfirmAppointmentAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Confirmed", result.Status);

            _appointmentRepoMock.Verify(
                x => x.UpdateAsync(It.IsAny<Appointment>()),
                Times.Once);
        }

        [Fact]
        public async Task ConfirmAppointmentAsync_ShouldThrow_WhenAppointmentNotFound()
        {
            // Arrange
            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Appointment)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.ConfirmAppointmentAsync(1));

            Assert.Equal("Appointment not found", ex.Message);
        }

        [Fact]
        public async Task ConfirmAppointmentAsync_ShouldThrow_WhenCancelled()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Cancelled"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.ConfirmAppointmentAsync(1));

            Assert.Equal(
                "Cannot confirm a cancelled appointment",
                ex.Message);
        }

        [Fact]
        public async Task ConfirmAppointmentAsync_ShouldThrow_WhenCompleted()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Completed"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.ConfirmAppointmentAsync(1));

            Assert.Equal(
                "Appointment already completed",
                ex.Message);
        }

        #endregion

        #region CancelAppointmentAsync

        [Fact]
        public async Task CancelAppointmentAsync_ShouldCancelAppointment_WhenValid()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act
            var result = await _service.CancelAppointmentAsync(
                1,
                "Patient unavailable");

            // Assert
            Assert.Equal("Cancelled", result.Status);
            Assert.Equal(
                "Patient unavailable",
                result.CancellationReason);

            _appointmentRepoMock.Verify(
                x => x.UpdateAsync(It.IsAny<Appointment>()),
                Times.Once);
        }

        [Fact]
        public async Task CancelAppointmentAsync_ShouldThrow_WhenAppointmentNotFound()
        {
            // Arrange
            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Appointment)null);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.CancelAppointmentAsync(1, "Reason"));

            Assert.Equal("Appointment not found", ex.Message);
        }

        [Fact]
        public async Task CancelAppointmentAsync_ShouldThrow_WhenAlreadyCancelled()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Cancelled"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.CancelAppointmentAsync(1, "Reason"));

            Assert.Equal(
                "Appointment already cancelled",
                ex.Message);
        }

        [Fact]
        public async Task CancelAppointmentAsync_ShouldThrow_WhenReasonIsEmpty()
        {
            // Arrange
            var appointment = new Appointment
            {
                AppointmentId = 1,
                Status = "Pending"
            };

            _appointmentRepoMock
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(appointment);

            // Act & Assert
            var ex = await Assert.ThrowsAsync<Exception>(
                () => _service.CancelAppointmentAsync(1, ""));

            Assert.Equal(
                "Cancellation reason is required",
                ex.Message);
        }

        #endregion

        #region GetAppointmentsByDateAsync

        [Fact]
        public async Task GetAppointmentsByDateAsync_ShouldReturnAppointments()
        {
            // Arrange
            var appointments = new List<Appointment>
            {
                new Appointment { AppointmentId = 1 },
                new Appointment { AppointmentId = 2 }
            };

            _appointmentRepoMock
                .Setup(x => x.GetAppointmentsByDateAsync(It.IsAny<DateTime>()))
                .ReturnsAsync(appointments);

            // Act
            var result = await _service.GetAppointmentsByDateAsync(DateTime.Today);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<Appointment>)result).Count);
        }

        #endregion
    }
}