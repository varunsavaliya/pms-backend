using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Models;

namespace PMS.Model.ModelConfigurations
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.HasOne(uba => uba.Plan)
                .WithMany(u => u.Clients)
                .HasForeignKey(uba => uba.PlanId);
        }
    }
}
