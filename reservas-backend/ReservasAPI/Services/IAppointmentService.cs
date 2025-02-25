using ReservasAPI.Models;

namespace ReservasAPI.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> Get();

        Task<IEnumerable<string>> Get(DateTime date);

        Task<Appointment> Create(Appointment appt);
    }
}
