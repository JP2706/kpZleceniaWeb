using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kpZleceniaWeb.Infrastructure.Persistence.Configurations
{
    class FirmaConfiguration : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.Property(x => x.Nazwa)
                 .HasMaxLength(200).IsRequired();
            builder.Property(x => x.NIP)
                .HasMaxLength(10).IsRequired();
            builder.Property(x => x.Adres)
                .HasMaxLength(1200).IsRequired();
            builder.Property(x => x.Telefon)
                .HasMaxLength(30).IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(50);
            builder.Property(x => x.Ulica)
               .HasMaxLength(200).IsRequired();
            builder.Property(x => x.NumerDomu)
              .HasMaxLength(200).IsRequired();
            builder.Property(x => x.NumerLokalu)
              .HasMaxLength(200).IsRequired();
            builder.Property(x => x.Miejscowosc)
             .HasMaxLength(200).IsRequired();
            builder.Property(x => x.KodPocztowy)
             .HasMaxLength(200).IsRequired();
            builder.Property(x => x.Poczta)
             .HasMaxLength(200).IsRequired();
        }
    }
}
