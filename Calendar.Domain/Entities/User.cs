using System.Collections.Generic;

namespace Calendar.Domain.Entities
{
    public class User: BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<AppointmentDetail> AppointmentDetails { get; set; }
    }
}
