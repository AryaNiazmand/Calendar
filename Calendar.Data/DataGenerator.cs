using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Calendar.Data
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CalendarDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<CalendarDbContext>>()))
            {
                var users = new List<User>
                {
                    new(){Id=1,FullName="Joun Smith"},
                    new(){Id=2,FullName="Robert Turner"},
                    new(){Id=3,FullName="Erika Gobler"},
                    new(){Id=4,FullName="Wade Williams"},
                    new(){Id=5,FullName="Daisy Harris"},
                    new(){Id=6,FullName="Deborah Robinson"},
                };
                context.Users.AddRange(users);

                var organizer = users[5];
                var appointments = new List<Appointment>
                {
                    new(){Date=new(2022,1,1),Subject="Team Meeting",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>(){users[0],users[1]}}},
                    new(){Date=new (2022,1,2),Subject="Date with Sara:)",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[2],users[3]}}},
                    new(){Date=new (2022,1,3),Subject="1th Interview with Mohammad :)",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[3],users[4]}}},
                    new(){Date=new(2022,2,1),Subject="2th Interview with Mohammad :)",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,2,2),Subject="3th Interview with Mohammad :)",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[1],users[2]}}},
                    new(){Date=new (2022,2,3),Subject="4th Interview with Mohammad :)",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[2],users[3]}}},
                    new(){Date=new (2022,3,1),Subject="5th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[3],users[4]}}},
                    new(){Date=new (2022,4,1),Subject="6th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,5,1),Subject="7th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[1],users[2]}}},
                    new(){Date=new (2022,6,1),Subject="8th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[2],users[3]}}},
                    new(){Date=new (2022,7,1),Subject="9th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[4],users[1]}}},
                    new(){Date=new (2022,8,1),Subject="10th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,9,1),Subject="11th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,10,1),Subject="12th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,11,1),Subject="13th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                    new(){Date=new (2022,12,1),Subject="14th Interview with Mohammad ):",
                    AppointmentDetail=new(){Organizer=organizer.FullName, Attendees=new List<User>{users[0],users[1]}}},
                };
                context.Appointments.AddRange(appointments);

                context.SaveChanges();
            }
        }
    }
}
