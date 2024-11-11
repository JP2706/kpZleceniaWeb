using kpZleceniaWeb.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace kpZleceniaWeb.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DatabaseFacade Database { get; }

        DbSet<ApplicationUser> User { get; set; }
        DbSet<Domain.Entities.Klient> Klient { get; set; }
        DbSet<Domain.Entities.Zlecenie> Zlecenie { get; set; }
        DbSet<ZlecenieStatus> ZlecenieStatus { get; set; }
        DbSet<TypUrzadzenia> TypUrzadzenia { get; set; }
        DbSet<Domain.Entities.Firma> Firma { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
