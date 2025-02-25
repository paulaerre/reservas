using ReservasAPI.Models;

namespace ReservasAPI.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> CreateAsync(Appointment appt);
        Task<IEnumerable<Appointment>> GetAllAsync();
        Task<IEnumerable<Appointment>> GetByDateAsync(DateTime date);

    }
}
