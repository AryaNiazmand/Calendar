using System;

namespace Calendar.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Subject { get; set; }
        public AppointmentDetail AppointmentDetail { get; set; }
    }
}
