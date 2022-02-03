using Calendar.API.Controllers;
using Calendar.Domain.Entities;
using Calendar.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.API.Tests.Controller
{
    public class AppointmentControllerTests
    {
        private readonly Mock<IAppointmentRepository> _mockAppointmentRepository;
        private readonly Mock<IAppointmentDetailRepository> _mockAppointmentDetailRepository;
        private readonly Mock<ILogger<AppointmentController>> _mockLogger;

        public AppointmentControllerTests()
        {
            _mockAppointmentRepository = new();
            _mockAppointmentDetailRepository = new();
            _mockLogger = new();
        }

        [Fact]
        public async Task GetAppointmentsByMonth_GivenMonthHasAppointments_ReturnsAppointments()
        {
            //Arrange
            int month = 1;
            var expectedAppointments = CreateAppointments(month);
            _mockAppointmentRepository.Setup(a => a.GetAllByMonthAsync(It.IsAny<int>()))
               .ReturnsAsync(expectedAppointments);
            var controller = CreateController();

            //Act
            var actionResult = await controller.GetAppointmentsByMonthAsync(month);

            //Assert
            var OkObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            var actualAppointments = Assert.IsType<List<Appointment>>(OkObjectResult.Value);
            Assert.Equal(actualAppointments.Count, expectedAppointments.Count);
        }

        [Fact]
        public async Task GetAppointmentDetail_GivenAppointmentIdHasDetail_ReturnsAppointmentDetail()
        {
            //Arrange
            var expectedAppointmentDetail = new AppointmentDetail
            {
                Appointment = new Appointment
                {
                    Id = 1,
                    Date = DateTime.Now,
                    Subject = "Team Meeting"
                },
                Organizer = "Joun Smith",
                Attendees = new List<User>
                {
                    new(){Id=2,FullName="Robert Turner"},
                    new(){Id=3,FullName="Erika Gobler"},
                }

            };
            _mockAppointmentDetailRepository.Setup(a => a.GetByAppointmentIdAsync(It.IsAny<int>()))
               .ReturnsAsync(expectedAppointmentDetail);
            var controller = CreateController();

            //Act
            var actionResult = await controller.GetAppointmentDetailAsync(expectedAppointmentDetail.AppointmentId);

            //Assert
            var OkObjectResult = Assert.IsType<OkObjectResult>(actionResult);
            var actualAppointmentDetail = Assert.IsType<AppointmentDetail>(OkObjectResult.Value);
            Assert.Equal(expectedAppointmentDetail.Organizer, actualAppointmentDetail.Organizer);
            Assert.Equal(expectedAppointmentDetail.Attendees.Count, actualAppointmentDetail.Attendees.Count);
        }

        [Fact]
        public async Task GetAppointmentDetail_GivenAppointmentIdHasNotDetail_ReturnsNotFound()
        {
            //Arrange

            _mockAppointmentDetailRepository.Setup(a => a.GetByAppointmentIdAsync(It.IsAny<int>()));
            var controller = CreateController();

            //Act
            var actionResult = await controller.GetAppointmentDetailAsync(It.IsAny<int>());

            //Assert
            var OkObjectResult = Assert.IsType<NotFoundResult>(actionResult);
        }


        private AppointmentController CreateController()
        {
            return new AppointmentController(_mockLogger.Object, _mockAppointmentDetailRepository.Object, _mockAppointmentRepository.Object);
        }

        private static List<Appointment> CreateAppointments(int month)
        {
            var attendees = new List<User>
                {
                    new(){Id=2,FullName="Robert Turner"},
                    new(){Id=3,FullName="Erika Gobler"},
                };
            return new List<Appointment>
                {
                    new(){Date=new(2022,month,1),Subject="Team Meeting1",AppointmentDetail=new(){Organizer="Joun Smith",Attendees=attendees}},
                    new(){Date=new(2022,month,2),Subject="Team Meeting2",AppointmentDetail=new(){Organizer="Joun Smith",Attendees=attendees}},
                    new(){Date=new(2022,month,3),Subject="Team Meeting3",AppointmentDetail=new(){Organizer="Joun Smith",Attendees=attendees}},
                };
        }
    }
}
