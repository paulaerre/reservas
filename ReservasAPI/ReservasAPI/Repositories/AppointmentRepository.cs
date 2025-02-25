using ReservasAPI.Data;
using Microsoft.EntityFrameworkCore;
using ReservasAPI.Exceptions;
using ReservasAPI.Models;

namespace ReservasAPI.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppointmentsContext _context;

        public AppointmentRepository(AppointmentsContext context)
        {
            this._context = context;
        }

        public async Task<Appointment> CreateAsync(Appointment appt)
        {
            // 3. Validar reserva mismo día y hora
            if (await this._context.Appointments.Where(a => a.Time == appt.Time && a.Date == appt.Date).FirstOrDefaultAsync() != null)
            {
                throw new DuplicateTimeException($"Ya existe una reserva para el día {appt.Date.ToString()} a las {appt.Time.ToString()}hs.");
            }

            // 3. Validar 2 reservas mismo cliente
            if (await this._context.Appointments.Where(a => a.Client == appt.Client && a.Date == appt.Date).FirstOrDefaultAsync() != null)
            {
                throw new DuplicateClientPerDayException($"Ya existe una reserva para el cliente {appt.Client.ToString()} el {appt.Date.ToString()}.");
            }

            this._context.Appointments.Add(appt);
            await this._context.SaveChangesAsync();

            return appt;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await this._context.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date)
        {
            return await this._context.Appointments.Where(appt => appt.Date == date.Date.ToString("dd/MM/yyyy")).ToListAsync();
        }

    }
}
