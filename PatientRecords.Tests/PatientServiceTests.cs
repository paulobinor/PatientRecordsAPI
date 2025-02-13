using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PatientRecords.Api.Controllers;
using PatientRecords.Core.Dtos;
using PatientRecords.Core.Interfaces;
using PatientRecords.Core.models;
using PatientRecords.Repo;
using System;

namespace PatientRecords.Tests
{
    public class PatientControllerTests
    {
        private readonly PatientsController _controller;
        private readonly Mock<IPatientService> _mockPatientService;
        private ILogger<PatientsController> _logger;

        public PatientControllerTests()
        {
            _mockPatientService = new Mock<IPatientService>();
            _controller = new PatientsController(_logger, _mockPatientService.Object);
        }

        [Fact]
        public async Task GetPatients_ReturnsListOfPatients()
        {
            // Arrange
            var patients = new List<PatientDto>
        {
            new PatientDto { PatientId = Guid.NewGuid(), FirstName = "John", Surname = "Doe" },
            new PatientDto { PatientId = Guid.NewGuid(), FirstName = "Jane", Surname = "Smith" }
        };

            _mockPatientService
                .Setup(service =>  service.PatientList(It.IsAny<string>(), It.IsAny<string>()).Result)
                .Returns(patients);

            // Act
            var result = await _controller.GetPatientList(null, null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPatients = Assert.IsType<List<PatientDto>>(okResult.Value);
            Assert.Equal(2, returnedPatients.Count);
        }

    }
}