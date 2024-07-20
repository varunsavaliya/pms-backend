using PMS.Model.DTOs.Response.Plan;

namespace PMS.Model.DTOs.Response.Client
{
    public class ClientResponseDTO
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public PlanResponseDTO Plan { get; set; } = new();
    }
}
