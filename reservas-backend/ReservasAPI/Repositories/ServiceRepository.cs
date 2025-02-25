using Microsoft.EntityFrameworkCore;
using ReservasAPI.Data;
using ReservasAPI.Models;

namespace ReservasAPI.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppointmentsContext _context;

        public ServiceRepository(AppointmentsContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Service>> GetAllAsync()
        {
            return await this._context.Services.ToListAsync();
        }
    }
}
