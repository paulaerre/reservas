using ReservasAPI.Models;
using ReservasAPI.Repositories;

namespace ReservasAPI.Services
{
    public class ServiceService : IServiceService
    {
        private readonly ILogger<ServiceService> _logger;
        private readonly IServiceRepository _repository;
        public ServiceService(ILogger<ServiceService> logger, IServiceRepository serviceRepository)
        {
            _logger = logger;
            _repository = serviceRepository;
        }

        public async Task<IEnumerable<Service>> Get()
        {
            return await _repository.GetAllAsync();
        }
    }
}
