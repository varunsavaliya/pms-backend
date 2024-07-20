using Microsoft.EntityFrameworkCore;
using PMS.Model.Context;
using PMS.Model.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implementation
{
    public class ClientRepository(PMSDbContext dbContext) : GenericRepository<Client>(dbContext), IClientRepository
    {
        public async Task<IEnumerable<Client>> GetAllClientsIncludePlan()
        {
            return await Dbset.Include(client => client.Plan).ToListAsync();
        }

    }
}
