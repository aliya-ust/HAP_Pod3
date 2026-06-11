using HealthCare.Shared;
using HealthCare.Shared.DTOs.Patient;
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
    public class PatientMvcServiceTests
    {
        //  GET PATIENTS SUCCESS
        [TestMethod]
        public async Task GetPatients_ShouldReturnPagedResult_WhenSuccess()
        {
            var data = new PagedResult<PatientDto>
            {
                Items = new List<PatientDto>(),
                TotalCount = 0
            };

            var json = JsonSerializer.Serialize(data);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.GetPatientsAsync(null, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET PATIENTS FAIL
        [TestMethod]
        public async Task GetPatients_ShouldReturnEmpty_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.GetPatientsAsync(null, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET BY ID SUCCESS
        [TestMethod]
        public async Task GetById_ShouldReturnPatient_WhenSuccess()
        {
            var dto = new PatientDto
            {
                PatientId = 1
            };

            var json = JsonSerializer.Serialize(dto);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.PatientId);
        }

        //  GET BY ID FAIL
        [TestMethod]
        public async Task GetById_ShouldReturnNull_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.GetByIdAsync(1);

            Assert.IsNull(result);
        }

        //  CREATE SUCCESS
        [TestMethod]
        public async Task Create_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var dto = new PatientDto
            {
                PatientId = 1,
                FullName = "Test Patient"
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
            var service = new PatientService(client);

            var result = await service.CreateAsync(new PatientDto());

            Assert.IsFalse(result);
        }

        //  UPDATE SUCCESS
        [TestMethod]
        public async Task Update_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var dto = new PatientDto { PatientId = 1 };

            var result = await service.UpdateAsync(dto);

            Assert.IsTrue(result);
        }

        //  DELETE SUCCESS
        [TestMethod]
        public async Task Delete_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.DeleteAsync(1);

            Assert.IsTrue(result);
        }

        //  DELETE FAIL
        [TestMethod]
        public async Task Delete_ShouldReturnFalse_WhenFail()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new PatientService(client);

            var result = await service.DeleteAsync(1);

            Assert.IsFalse(result);
        }
    }
}