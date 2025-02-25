using ReservasAPI.Models;

namespace ReservasAPI.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<Service>> Get();
    }
}
