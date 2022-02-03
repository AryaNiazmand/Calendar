using Calendar.Data;
using Calendar.Domain.Entities;
using Calendar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Calendar.Data.Repositories
{
    public class AppointmentDetailRepository : IAppointmentDetailRepository
    {
        private readonly CalendarDbContext _calendarDBContext;

        public AppointmentDetailRepository(CalendarDbContext callendarDBContext)
        {
            _calendarDBContext = callendarDBContext;
        }

        public async Task<AppointmentDetail> GetByAppointmentIdAsync(int appointmentId)
        {
            return await _calendarDBContext
                .AppointmentDetails
                .Include(a => a.Appointment)
                .Include(a => a.Attendees)
                .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);
        }
    }
}
