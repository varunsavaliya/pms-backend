using PMS.Model.Models;

namespace PMS.Service.Interface
{
    public interface IClientService : IBaseService<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsIncludePlan();
    }
}
