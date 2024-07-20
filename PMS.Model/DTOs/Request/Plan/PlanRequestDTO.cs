using PMS.Model.Common.Enums;

namespace PMS.Model.DTOs.Request.Plan
{
    public class PlanRequestDTO
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public PlanEnums.Duration Duration { get; set; }
    }
}
