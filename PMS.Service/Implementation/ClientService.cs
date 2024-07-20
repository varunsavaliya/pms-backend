using PMS.Model.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implementation
{
    public class ClientService(IClientRepository clientRepository) : BaseService<Client>(clientRepository), IClientService
    {
        public Task<IEnumerable<Client>> GetAllClientsIncludePlan() => clientRepository.GetAllClientsIncludePlan();
    }
}
