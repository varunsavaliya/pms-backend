using PMS.Model.Context;
using PMS.Model.Models;
using PMS.Repository.Interface;

namespace PMS.Repository.Implementation
{
    public class PlanRepository(PMSDbContext dbContext) : GenericRepository<Plan>(dbContext), IPlanRepository
    {
    }
}
