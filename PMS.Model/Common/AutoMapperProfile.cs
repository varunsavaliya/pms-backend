using PMS.Model.DTOs.Request.Client;
using PMS.Model.DTOs.Request.Plan;
using PMS.Model.DTOs.Response.Client;
using PMS.Model.DTOs.Response.Plan;
using PMS.Model.Models;

namespace PMS.Model.Common
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Plan, PlanResponseDTO>();

            CreateMap<PlanRequestDTO, Plan>();

            CreateMap<Client, ClientResponseDTO>();

            CreateMap<ClientRequestDTO, Client>();
        }
    }
}
