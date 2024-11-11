using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kpZleceniaWeb.Infrastructure.Persistence.Configurations
{
    public class ZlecenieConfiguration : IEntityTypeConfiguration<Zlecenie>
    {
        public void Configure(EntityTypeBuilder<Zlecenie> builder)
        {
            builder.Property(x => x.Symbol)
                .HasMaxLength(300).IsRequired();

            builder.Property(x => x.Urzadzenie)
                .HasMaxLength(300).IsRequired();

            builder.Property(x => x.NumerSer)
                .HasMaxLength(300);

            builder.Property(x => x.OpisUsterki)
                .HasMaxLength(300).IsRequired();

            builder.Property(x => x.Opis)
                .HasMaxLength(300);

            
        }
    }
}
