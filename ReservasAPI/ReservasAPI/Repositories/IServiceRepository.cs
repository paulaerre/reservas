using ReservasAPI.Models;

namespace ReservasAPI.Repositories
{
    public interface IServiceRepository
    {
        Task<IEnumerable<Service>> GetAllAsync();
    }
}
