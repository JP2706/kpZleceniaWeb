using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace kpZleceniaWeb.Infrastructure.Persistence.Configurations
{
    public class KlientConfiguration : IEntityTypeConfiguration<Klient>
    {
        public void Configure(EntityTypeBuilder<Klient> builder)
        {
            builder.Property(x => x.Imie)
                .HasMaxLength(100);

            builder.Property(x => x.Nazwisko)
                .HasMaxLength(100);

            builder.Property(x => x.Nazwa)
                .HasMaxLength(200);

            builder.Property(x => x.Tel)
                .HasMaxLength(50);
        }
    }
}
