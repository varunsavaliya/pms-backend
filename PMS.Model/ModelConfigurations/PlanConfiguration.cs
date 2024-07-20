using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Common.Enums;
using PMS.Model.Models;

namespace PMS.Model.ModelConfigurations
{
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(e => e.Id)
                .IsRequired();

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.Duration)
                .HasMaxLength(64)
                .HasConversion(v => v.ToString(), v => (PlanEnums.Duration)Enum.Parse(typeof(PlanEnums.Duration), v))
                .IsRequired();
        }
    }
}
