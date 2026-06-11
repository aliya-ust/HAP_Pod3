using HealthCare.Shared;
using HealthCare.Shared.DTOs.Appointment;
using HealthCare.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCare.Tests
{
    //  Fake handler to mock HttpClient
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        private readonly HttpResponseMessage _response;

        public FakeHttpMessageHandler(HttpResponseMessage response)
        {
            Uri BaseAddress = new Uri("https://localhost:44373/api/");
            _response = response;
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return Task.FromResult(_response);
        }
    }

    [TestClass]
    public class AppointmentMvcServiceTests
    {
        //  GET APPOINTMENTS SUCCESS
        [TestMethod]
        public async Task GetAppointments_ShouldReturnPagedResult_WhenSuccess()
        {
            var data = new PagedResult<AppointmentDto>
            {
                Items = new List<AppointmentDto>(),
                TotalCount = 0
            };

            var json = JsonSerializer.Serialize(data);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.GetAppointmentsAsync(null, null, null, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET APPOINTMENTS FAILURE
        [TestMethod]
        public async Task GetAppointments_ShouldReturnEmpty_WhenApiFails()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.GetAppointmentsAsync(null, null, null, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET BY DATE
        [TestMethod]
        public async Task GetByDate_ShouldReturnAppointments()
        {
            var list = new List<AppointmentDto>();

            var json = JsonSerializer.Serialize(list);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.GetByDateAsync(DateTime.Today);

            Assert.IsNotNull(result);
        }

        //  BOOK SUCCESS
        [TestMethod]
        public async Task Book_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.BookAsync(new AppointmentDto());

            Assert.IsTrue(result);
        }

        //  CONFIRM SUCCESS
        [TestMethod]
        public async Task Confirm_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.ConfirmAsync(1);

            Assert.IsTrue(result);
        }

        //  CANCEL SUCCESS
        [TestMethod]
        public async Task Cancel_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.CancelAsync(1, "reason");

            Assert.IsTrue(result);
        }

        //  AVAILABLE SLOTS
        [TestMethod]
        public async Task GetAvailableSlots_ShouldReturnList()
        {
            var slots = new List<string> { "10:00", "11:00" };

            var json = JsonSerializer.Serialize(slots);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var testDate = new DateTime(2026, 1, 1); //  fixed date

            var result = await service.GetAvailableSlotsAsync(1, testDate);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        //  UPCOMING APPOINTMENTS
        [TestMethod]
        public async Task GetUpcomingAppointments_ShouldReturnPagedResult()
        {
            var data = new PagedResult<AppointmentDto>
            {
                Items = new List<AppointmentDto>(),
                TotalCount = 0
            };

            var json = JsonSerializer.Serialize(data);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new AppointmentService(client);

            var result = await service.GetUpcomingAppointmentsAsync(null, null, null, 1, 10);

            Assert.IsNotNull(result);
        }
    }
}