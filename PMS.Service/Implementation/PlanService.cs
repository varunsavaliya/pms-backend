using PMS.Model.Models;
using PMS.Repository.Interface;
using PMS.Service.Interface;

namespace PMS.Service.Implementation
{
    public class PlanService(IPlanRepository planRepository) : BaseService<Plan>(planRepository), IPlanService
    {
    }
}
