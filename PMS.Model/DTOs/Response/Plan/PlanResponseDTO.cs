using PMS.Model.Common.Enums;

namespace PMS.Model.DTOs.Response.Plan
{
    public class PlanResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public PlanEnums.Duration Duration { get; set; }
    }
}
