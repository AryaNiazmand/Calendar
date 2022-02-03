using Calendar.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calendar.Domain.Repositories
{
    public interface IAppointmentRepository
    {
       Task<IEnumerable<Appointment>> GetAllByMonthAsync(int month);
    }
}
