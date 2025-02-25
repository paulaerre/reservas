using ReservasAPI.Models;
using ReservasAPI.Repositories;

namespace ReservasAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ILogger<AppointmentService> _logger;
        private readonly IAppointmentRepository _repository;
        public AppointmentService(ILogger<AppointmentService> logger, IAppointmentRepository appointmentRepository)
        {
            _logger = logger;
            _repository = appointmentRepository;
        }

        public async Task<IEnumerable<Appointment>> Get()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<string>> Get(DateTime date)
        {
            List<string> timeslots = new List<string>
            {
                "10", "11", "12", "13", "14", "15", "16", "17"
            };

            IEnumerable<Appointment> appointmentsByDay = await _repository.GetByDateAsync(date);
            List<string> filledTimeslots = appointmentsByDay.Select(r => r.Time).ToList();

            // devolver los que no están ocupados
            return timeslots.Where(t => !filledTimeslots.Contains(t)).ToList();
        }

        public async Task<Appointment> Create(Appointment appt)
        {
           return await _repository.CreateAsync(appt);
        }

    }
}
