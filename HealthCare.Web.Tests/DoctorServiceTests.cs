using HealthCare.Shared;
using HealthCare.Shared.DTOs.Doctor;
using HealthCare.Web.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace HealthCare.Tests
{
    //  Fake HTTP handler

    [TestClass]
    public class DoctorMvcServiceTests
    {
        //  GET DOCTORS SUCCESS
        [TestMethod]
        public async Task GetDoctors_ShouldReturnPagedResult_WhenSuccess()
        {
            var data = new PagedResult<DoctorDto>
            {
                Items = new List<DoctorDto>(),
                TotalCount = 0
            };

            var json = JsonSerializer.Serialize(data);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.GetDoctorsAsync(null, null, false, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET DOCTORS FAIL
        [TestMethod]
        public async Task GetDoctors_ShouldReturnEmpty_WhenFailed()
        {
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.GetDoctorsAsync(null, null, false, 1, 10);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.TotalCount);
        }

        //  GET BY ID SUCCESS
        [TestMethod]
        public async Task GetById_ShouldReturnDoctor_WhenSuccess()
        {
            var dto = new DoctorDto { DoctorId = 1 };

            var json = JsonSerializer.Serialize(dto);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.GetByIdAsync(1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.DoctorId);
        }

        //  GET BY ID FAIL
        [TestMethod]
        public async Task GetById_ShouldReturnNull_WhenFailed()
        {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.GetByIdAsync(1);

            Assert.IsNull(result);
        }

        //  CREATE SUCCESS
        [TestMethod]
        public async Task Create_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.CreateAsync(new CreateDoctorDto());

            Assert.IsTrue(result);
        }

        //  UPDATE SUCCESS
        [TestMethod]
        public async Task Update_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.UpdateAsync(new UpdateDoctorDto { DoctorId = 5 });

            Assert.IsTrue(result);
        }

        //  DELETE SUCCESS
        [TestMethod]
        public async Task Delete_ShouldReturnTrue_WhenSuccess()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);

            var client = new HttpClient(new FakeHttpMessageHandler(response));
            var service = new DoctorService(client);

            var result = await service.DeleteAsync(1);

            Assert.IsTrue(result);
        }

        //  GET BY SPECIALIZATION SUCCESS
        [TestMethod]
        public async Task GetDoctorsBySpecialization_ShouldReturnList()
        {
            var list = new List<DoctorLookupDto>
            {
                new DoctorLookupDto { DoctorId = 1 }
            };

            var json = JsonSerializer.Serialize(list);

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json)
            };

            var client = new HttpClient(new FakeHttpMessageHandler(response))
            {
                //  FIX: base address for relative URL
                BaseAddress = new System.Uri("https://localhost:44373/api/")
            };

            var service = new DoctorService(client);

            var result = await service.GetDoctorsBySpecializationAsync("Cardiology");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }
    }
}