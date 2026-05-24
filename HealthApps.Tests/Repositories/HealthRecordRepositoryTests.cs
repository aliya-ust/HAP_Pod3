using Xunit;
using HealthApp.ConsoleApp.Repositories;
using HealthApp.ConsoleApp.Databases;
using HealthApp.ConsoleApp.Models;
using System;

namespace HealthApp.Tests
{
    public class HealthRecordRepositoryTests
    {
        private readonly HealthRecordRepository _repo;

        public HealthRecordRepositoryTests()
        {
            _repo = new HealthRecordRepository(new HealthRecordDb());
        }

        [Fact]
        public void GetAllRecords_ShouldReturnSorted()
        {
            // Act
            var result = _repo.GetAllRecords();

            // Assert
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetRecordById_ShouldReturnRecord()
        {
            // Arrange
            int id = 301;

            // Act
            var result = _repo.GetRecordById(id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void AddHealthRecord_ShouldAddRecord()
        {
            // Arrange
            var record = _repo.GetAllRecords()[0];

            // Act
            _repo.AddHealthRecord(record);
            var result = _repo.GetAllRecords();

            // Assert
            Assert.NotEmpty(result);
        }
    }
}