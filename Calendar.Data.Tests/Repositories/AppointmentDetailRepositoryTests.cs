using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Calendar.Data.Repositories
{
    public class AppointmentDetailRepositoryTests
    {

        [Fact]
        public async Task GetByAppointmentId_ShouldGetAppointmentDetailIncludedAppointmentAndAttendeesAsync()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalendarDbContext>()
                .UseInMemoryDatabase(databaseName: "ShouldGetAppointmentDetailIncludedAppointmentAndAttendees")
                .Options;

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

            using (var context = new CalendarDbContext(options))
            {
                context.AppointmentDetails.Add(expectedAppointmentDetail);
                context.SaveChanges();
            }

            // Act
            AppointmentDetail actualAppointmentDetail;
            using (var context = new CalendarDbContext(options))
            {
                var repository = new AppointmentDetailRepository(context);
                actualAppointmentDetail = await repository.GetByAppointmentIdAsync(expectedAppointmentDetail.AppointmentId);
            }

            // Assert
            Assert.Equal(actualAppointmentDetail, expectedAppointmentDetail, new AppointmentDetailEqualityComparer());
        }

        private class AppointmentDetailEqualityComparer : IEqualityComparer<AppointmentDetail>
        {
            public bool Equals([AllowNull] AppointmentDetail x, [AllowNull] AppointmentDetail y)
            {
                return
                    x.Id == y.Id
                    && x.Organizer == y.Organizer
                    && x.Appointment.Subject == y.Appointment.Subject
                    && x.Appointment.Date == y.Appointment.Date
                    && x.Appointment.Id == y.Appointment.Id
                    && x.Attendees.Count == y.Attendees.Count
                    && x.Attendees.First().FullName == y.Attendees.First().FullName;

            }

            public int GetHashCode([DisallowNull] AppointmentDetail obj)
            {
                return obj.Id.GetHashCode();
            }
        }


    }
}