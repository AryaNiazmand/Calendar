using Calendar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Data
{
    public class CalendarDbContext : DbContext
    {

        public DbSet<Appointment> Appointments { set; get; }
        public DbSet<AppointmentDetail> AppointmentDetails { set; get; }
        public DbSet<User> Users { set; get; }

        public CalendarDbContext(DbContextOptions<CalendarDbContext> options) : base(options) { }

    }
}