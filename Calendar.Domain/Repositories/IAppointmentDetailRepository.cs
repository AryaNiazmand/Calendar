using Calendar.Domain.Entities;
using System.Threading.Tasks;

namespace Calendar.Domain.Repositories
{
    public interface IAppointmentDetailRepository
    {
        Task<AppointmentDetail> GetByAppointmentIdAsync(int id);
    }
}
