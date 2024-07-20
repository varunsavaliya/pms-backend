namespace PMS.Model.DTOs.Request.Client
{
    public class ClientRequestDTO
    {
        public int PlanId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }
    }
}
