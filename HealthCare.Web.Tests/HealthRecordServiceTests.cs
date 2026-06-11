using HealthCare.Shared;
using HealthCare.Shared.DTOs.HealthRecord;
using HealthCare.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCare.Tests
{
    [TestClass]
    public class HealthRecordMvcServiceTests
    {
        //  GET PATIENT HISTORY SUCCESS
        [TestMethod]
        public async Task GetPatientHealthHistory_ShouldReturnPagedResult_WhenSuccess()
        {
            var data = new PagedResult<HealthRecordDto>
            {
                Items = new List<HealthRecordDto>(),
                TotalCount = 0
            };

            var json = JsonSerializer.Serialize(data);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetPatientHealthHistoryAsync(1, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET PATIENT HISTORY FAIL
        [TestMethod]
        public async Task GetPatientHealthHistory_ShouldReturnEmpty_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetPatientHealthHistoryAsync(1, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  CREATE SUCCESS
        [TestMethod]
        public async Task Create_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var dto = new CreateHealthRecordDto
            {
                AppointmentId = 1
            };

            var result = await service.CreateAsync(dto);

            Assert.IsTrue(result);
        }

        //  CREATE FAIL
        [TestMethod]
        public async Task Create_ShouldReturnFalse_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var dto = new CreateHealthRecordDto
            {
                AppointmentId = 1
            };

            var result = await service.CreateAsync(dto);

            Assert.IsFalse(result);
        }

        //  GET BY APPOINTMENT SUCCESS
        [TestMethod]
        public async Task GetByAppointmentId_ShouldReturnRecord_WhenSuccess()
        {
            var dto = new HealthRecordDto
            {
                AppointmentId = 1
            };

            var json = JsonSerializer.Serialize(dto);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetByAppointmentIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.AppointmentId);
        }

        //  GET BY APPOINTMENT FAIL
        [TestMethod]
        public async Task GetByAppointmentId_ShouldReturnNull_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetByAppointmentIdAsync(1);

            Assert.IsNull(result);
        }

        //  GET BY ID SUCCESS
        [TestMethod]
        public async Task GetById_ShouldReturnRecord_WhenSuccess()
        {
            var dto = new HealthRecordDto
            {
                RecordId = 5
            };

            var json = JsonSerializer.Serialize(dto);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetByIdAsync(5);

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.RecordId);
        }

        //  GET BY ID FAIL
        [TestMethod]
        public async Task GetById_ShouldReturnNull_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new HealthRecordService(client);

            var result = await service.GetByIdAsync(5);

            Assert.IsNull(result);
        }
    }
}