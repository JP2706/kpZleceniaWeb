using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kpZleceniaWeb.Infrastructure.Persistence.Configurations
{
    public class ZlecenieStatusConfiguration : IEntityTypeConfiguration<ZlecenieStatus>
    {
        public void Configure(EntityTypeBuilder<ZlecenieStatus> builder)
        {
            builder.Property(x => x.Nazwa)
                .HasMaxLength(200).IsRequired();
        }
    }
}
