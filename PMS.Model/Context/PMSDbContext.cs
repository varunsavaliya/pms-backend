using Microsoft.EntityFrameworkCore;
using PMS.Model.Models;

namespace PMS.Model.Context
{
    public class PMSDbContext : DbContext
    {
        public PMSDbContext()
        {
        }

        public PMSDbContext(DbContextOptions<PMSDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(PMSDbContext).Assembly);

            base.OnModelCreating(builder);
        }

        public DbSet<Plan> Plans { get; set; }

        public DbSet<Client> Clients { get; set; }
    }
}
