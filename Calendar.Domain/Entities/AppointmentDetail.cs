using System.Collections.Generic;

namespace Calendar.Domain.Entities
{
    public class AppointmentDetail: BaseEntity
    {
        public string Organizer { get; set; }
        public ICollection<User> Attendees { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
