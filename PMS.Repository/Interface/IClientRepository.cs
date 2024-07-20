using PMS.Model.Models;

namespace PMS.Repository.Interface
{
    public interface IClientRepository : IGenericRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsIncludePlan();
    }
}
