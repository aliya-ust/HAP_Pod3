using AutoMapper;
using HealthCare.Api.Data;
using HealthCare.Api.DTOs.Appointment;
using HealthCare.Api.Events;
using HealthCare.Api.Models;
using HealthCare.Api.Repositories.Interfaces;
using HealthCare.Api.Services.Implementations;
using HealthCare.Api.Services.Interfaces;
using HealthCare.Shared.DTOs.Appointment;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Moq;
using System.Linq.Expressions;

namespace HealthCare.Api.Tests;

public class AppointmentServiceTests
{
    private readonly Mock<IAppointmentRepository> _repositoryMock;
    private readonly Mock<IDoctorService> _doctorServiceMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<HealthCareDbContext> _contextMock;
    private readonly Mock<IPublishEndpoint> _publishEndpointMock;
    private readonly Mock<ILogger<AppointmentService>> _loggerMock;
    private readonly Mock<IDistributedCache> _cacheMock;

    private readonly AppointmentService _service;

    public AppointmentServiceTests()
    {
        _repositoryMock = new Mock<IAppointmentRepository>();
        _doctorServiceMock = new Mock<IDoctorService>();
        _mapperMock = new Mock<IMapper>();
        _publishEndpointMock = new Mock<IPublishEndpoint>();
        _loggerMock = new Mock<ILogger<AppointmentService>>();
        _cacheMock = new Mock<IDistributedCache>();

        var options = new DbContextOptionsBuilder<HealthCareDbContext>()
            .Options;

        _contextMock = new Mock<HealthCareDbContext>(options);

        _contextMock
            .Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        SetupPatientsDbSet();

        _service = new AppointmentService(
            _repositoryMock.Object,
            _doctorServiceMock.Object,
            _contextMock.Object,
            _mapperMock.Object,
            _publishEndpointMock.Object,
            _loggerMock.Object,
            _cacheMock.Object
        );
    }

    private void SetupPatientsDbSet()
    {
        var patients = new List<Patient>
        {
            new Patient
            {
                PatientId = 5,
                FullName = "Test Patient",
                UserId = "user-5",
                PhoneNumber = "9999999999",
                Gender = "Female",
                InsuranceId = "INS001",
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Patient
            {
                PatientId = 50,
                FullName = "Another Patient",
                UserId = "user-50",
                PhoneNumber = "8888888888",
                Gender = "Female",
                InsuranceId = "INS050",
                IsActive = true,
                CreatedDate = DateTimeOffset.UtcNow
            }
        }.AsQueryable();

        var mockSet = new Mock<DbSet<Patient>>();

        mockSet.As<IAsyncEnumerable<Patient>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<Patient>(patients.GetEnumerator()));

        mockSet.As<IQueryable<Patient>>()
            .Setup(m => m.Provider)
            .Returns(new TestAsyncQueryProvider<Patient>(patients.Provider));

        mockSet.As<IQueryable<Patient>>()
            .Setup(m => m.Expression)
            .Returns(patients.Expression);

        mockSet.As<IQueryable<Patient>>()
            .Setup(m => m.ElementType)
            .Returns(patients.ElementType);

        mockSet.As<IQueryable<Patient>>()
            .Setup(m => m.GetEnumerator())
            .Returns(() => patients.GetEnumerator());

        _contextMock
            .Setup(c => c.Patients)
            .Returns(mockSet.Object);
    }
     public class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
     {
        private readonly IQueryProvider _inner;

        public TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object? Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(
            Expression expression,
            CancellationToken cancellationToken = default)
        {
            var expectedResultType = typeof(TResult).GetGenericArguments()[0];

            var executionResult = typeof(IQueryProvider)
                .GetMethod(
                    name: nameof(IQueryProvider.Execute),
                    genericParameterCount: 1,
                    types: new[] { typeof(Expression) })!
                .MakeGenericMethod(expectedResultType)
                .Invoke(_inner, new[] { expression });

            return (TResult)typeof(Task)
                .GetMethod(nameof(Task.FromResult))!
                .MakeGenericMethod(expectedResultType)
                .Invoke(null, new[] { executionResult })!;
        }
    }

    public class TestAsyncEnumerable<T> :
        EnumerableQuery<T>,
        IAsyncEnumerable<T>,
        IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable)
            : base(enumerable)
        {
        }

        public TestAsyncEnumerable(Expression expression)
            : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(
            CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<T>(
                this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider =>
            new TestAsyncQueryProvider<T>(this);
    }

    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public T Current => _inner.Current;

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }
    }
}