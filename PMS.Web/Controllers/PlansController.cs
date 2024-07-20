using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PMS.Model.Common.Constants;
using PMS.Model.DTOs.Request.Plan;
using PMS.Model.DTOs.Response;
using PMS.Model.DTOs.Response.Plan;
using PMS.Model.Models;
using PMS.Service.Interface;

namespace PMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController(IPlanService planService, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Get list of all plans. 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            IEnumerable<Plan> plans = await planService.GetAllAsync();

            IEnumerable<PlanResponseDTO> result = mapper.Map<IEnumerable<PlanResponseDTO>>(plans);

            return Ok(new ApiResponseDTO(result));
        }

        /// <summary>
        /// Add new plan.
        /// </summary>
        /// <param name="planRequestDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddPlan(PlanRequestDTO planRequestDTO)
        {
            Plan plan = mapper.Map<Plan>(planRequestDTO);

            await planService.InsertAsync(plan);

            return Ok(new ApiResponseDTO(plan.Id, PlanConstants.INSERT_SUCCESS_MESSAGE));
        }

        /// <summary>
        /// Delete plan.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="BadHttpRequestException"></exception>
        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeletePlan(int id)
        {
            Plan plan = await planService.GetAsync(plan => plan.Id == id) ?? throw new BadHttpRequestException(PlanConstants.NOT_FOUND_MESSAGE);

            await planService.DeleteAsync(plan);

            return Ok(new ApiResponseDTO(id, PlanConstants.DELETE_SUCCESS_MESSAGE));
        }
    }
}
