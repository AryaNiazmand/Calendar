using Calendar.Domain.Entities;
using Calendar.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly CalendarDbContext _calendarDBContext;

        public AppointmentRepository(CalendarDbContext callendarDBContext)
        {
            _calendarDBContext = callendarDBContext;
        }
        public async Task<IEnumerable<Appointment>> GetAllByMonthAsync(int month)
        {
            return await _calendarDBContext
                .Appointments
                .Where(a => a.Date.Month == month)
                .ToListAsync();
        }
       
    }
}
