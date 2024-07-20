using PMS.Model.Common.Enums;

namespace PMS.Model.Models
{
    public class Plan
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public PlanEnums.Duration Duration { get; set; }

        public virtual ICollection<Client> Clients { get; set; } = null!;
    }
}
