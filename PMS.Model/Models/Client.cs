namespace PMS.Model.Models
{
    public class Client
    {
        public int Id { get; set; }

        public int PlanId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime StartDate { get; set; }

        public virtual Plan Plan { get; set; } = null!;
    }
}
