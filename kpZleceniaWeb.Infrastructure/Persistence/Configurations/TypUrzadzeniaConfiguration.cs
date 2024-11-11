using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kpZleceniaWeb.Infrastructure.Persistence.Configurations
{
    public class TypUrzadzeniaConfiguration : IEntityTypeConfiguration<TypUrzadzenia>
    {
        public void Configure(EntityTypeBuilder<TypUrzadzenia> builder)
        {
            builder.Property(x => x.Nazwa)
                .HasMaxLength(200).IsRequired();
        }
    }
}
