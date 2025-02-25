using Microsoft.EntityFrameworkCore;
using ReservasAPI.Models;

namespace ReservasAPI.Data
{
    public class AppointmentsContext : DbContext
    {
        public AppointmentsContext(DbContextOptions<AppointmentsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }


    }
}
