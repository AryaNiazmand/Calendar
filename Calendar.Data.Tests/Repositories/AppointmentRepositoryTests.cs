using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Calendar.Data.Repositories
{
    public class AppointmentRepositoryTests
    {

        [Fact]
        public async Task GetAllByMonth_ShouldGetAllAppointmentByMonthAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalendarDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldGetAllAppointmentByMonth")
                .Options;

            int month = 1;
            var expectedAppointments = CreateAppointments(month);

            using (var context = new CalendarDbContext(options))
            {
                await context.Appointments.AddRangeAsync(expectedAppointments);
                context.SaveChanges();
            }

            // Act
            IEnumerable<Appointment> actualAppointments;
            using (var context = new CalendarDbContext(options))
            {
                var repository = new AppointmentRepository(context);
                actualAppointments = await repository.GetAllByMonthAsync(month);
            }

            // Assert
            Assert.Equal(actualAppointments.Count(), expectedAppointments.Count);
            Assert.Equal(actualAppointments.First().Date, expectedAppointments.First().Date);
            Assert.Equal(actualAppointments.First().Subject, expectedAppointments.First().Subject);
            Assert.All(actualAppointments, appoinment => Assert.Null(appoinment.AppointmentDetail));
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