using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PatientManagement.Api.Controllers;
using PatientManagement.Application.Commands;
using PatientManagement.Application.Queries;
using PatientManagement.Core.Entities;

namespace PatientManagement.Test.Controllers
{
    public class PatientsControllerTests
    {
        private readonly PatientsController _controller;
        private readonly Mock<IMediator> _mockMediator;

        public PatientsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new PatientsController(_mockMediator.Object);
        }

        [Fact]
        public async Task GetAllPatients_ReturnsListOfPatients()
        {
            // Arrange
            var patients = new List<Patient>
            {
                new Patient { Id = 1, FirstName = "John", LastName = "Doe" },
                new Patient { Id = 2, FirstName = "Jane", LastName = "Doe" }
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllPatientsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(patients);

            // Act
            var result = await _controller.GetAllPatients();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPatients = Assert.IsType<List<Patient>>(okResult.Value);
            Assert.Equal(2, returnedPatients.Count);
        }

        [Fact]
        public async Task GetPatient_ReturnsPatient_WhenPatientExists()
        {
            // Arrange
            var patient = new Patient { Id = 1, FirstName = "John", LastName = "Doe" };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPatientByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(patient);

            // Act
            var result = await _controller.GetPatient(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedPatient = Assert.IsType<Patient>(okResult.Value);
            Assert.Equal(1, returnedPatient.Id);
        }

        [Fact]
        public async Task GetPatient_ReturnsNotFound_WhenPatientDoesNotExist()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPatientByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync((Patient)null);

            // Act
            var result = await _controller.GetPatient(1);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreatePatient_ReturnsCreatedAtAction_WithPatientId()
        {
            // Arrange
            var command = new CreatePatientCommand { FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.UtcNow };
            var patientId = 1;

            _mockMediator
                .Setup(m => m.Send(It.IsAny<CreatePatientCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(patientId);

            // Act
            var result = await _controller.CreatePatient(command);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(PatientsController.GetPatient), createdAtActionResult.ActionName);
            Assert.Equal(patientId, createdAtActionResult.RouteValues["id"]);
            Assert.Equal(patientId, createdAtActionResult.Value);
        }

        [Fact]
        public async Task UpdatePatient_ReturnsNoContent_WhenUpdateIsSuccessful()
        {
            // Arrange
            var command = new UpdatePatientCommand { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.UtcNow };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<UpdatePatientCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.UpdatePatient(1, command);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task UpdatePatient_ReturnsBadRequest_WhenIdsDoNotMatch()
        {
            // Arrange
            var command = new UpdatePatientCommand { Id = 1, FirstName = "John", LastName = "Doe", DateOfBirth = DateTime.UtcNow };

            // Act
            var result = await _controller.UpdatePatient(2, command);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task SoftDeletePatient_ReturnsNoContent_WhenSoftDeleteIsSuccessful()
        {
            // Arrange
            _mockMediator
                .Setup(m => m.Send(It.IsAny<SoftDeletePatientCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.SoftDeletePatient(1);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

    }
}
