using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace kpZleceniaWeb.Infrastructure.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ApplicationUser> User {  get; set; }
        public DbSet<Klient> Klient { get; set; }
        public DbSet<Zlecenie> Zlecenie { get; set; }
        public DbSet<ZlecenieStatus> ZlecenieStatus { get; set; }
        public DbSet<TypUrzadzenia> TypUrzadzenia { get; set; }
        public DbSet<Firma> Firma { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<IdentityRole>().HasData(
               new IdentityRole
               {
                   Id = "CDBA0656-5628-48BD-A85E-321B11CBF6FB",
                   Name = "GlobalAdminstrator",
                   NormalizedName = "GLOBALADMINISTRATOR",
                   ConcurrencyStamp = "2F1171EE-0FB3-449D-BE46-9930B9CAFD51"
               });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "2EAF55AC-D8C7-47DB-B1AE-9D0C66E22556",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    ConcurrencyStamp = "3F5DB870-5626-4F3A-9018-590022100AA1"
                });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "6C9452D9-37CB-4B59-895A-912264382584",
                    Name = "Pracownik",
                    NormalizedName = "PRACOWNIK",
                    ConcurrencyStamp = "F7B4916B-FFF7-4853-847C-2C4BDA3361A5"
                });

            #region PreTypyUrz
            modelBuilder.Entity<TypUrzadzenia>().HasData(
                new Domain.Entities.TypUrzadzenia
                {
                    Id = 1,
                    Nazwa = "Brak Typu"
                });

            modelBuilder.Entity<TypUrzadzenia>().HasData(
                new Domain.Entities.TypUrzadzenia
                {
                    Id = 2,
                    Nazwa = "Inne"
                });
            #endregion

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Zlecenie)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired();

            modelBuilder.Entity<Klient>()
                .HasMany(x => x.Zlecenie)
                .WithOne(x => x.Klient)
                .HasForeignKey(x => x.KlientId)
                .IsRequired();

            modelBuilder.Entity<TypUrzadzenia>()
                .HasMany(x => x.Zlecenie)
                .WithOne(x => x.TypUrzadzeniaT)
               .HasForeignKey(x => x.TypUrzadzeniaId)
                .IsRequired();

            modelBuilder.Entity<ZlecenieStatus>()
                .HasMany(x => x.Zlecenie)
                .WithOne(x => x.ZlecenieStatus)
                .HasForeignKey(x => x.ZlecenieStatusId)
                .IsRequired();

            modelBuilder.Entity<Zlecenie>()
                .ToTable(tb => tb.UseSqlOutputClause(false));

            base.OnModelCreating(modelBuilder);
        }
    }
}
