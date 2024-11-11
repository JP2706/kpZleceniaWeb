using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Infrastructure.Identity;
using kpZleceniaWeb.Infrastructure.Persistence;
using kpZleceniaWeb.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace kpZleceniaWeb.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var encryptionService = new EncryptionService(new KeyInfo("qJ/JwZ1XrNhguTER6KQDM4elt1O6lPisscKoFTK50JE=", "xUG+WrkN1LE/fv8ZPWJ2zg=="));
            services.AddSingleton<IEncryptionService>(encryptionService);

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(connectionString)
               .EnableSensitiveDataLogging());

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 3;

                options.SignIn.RequireConfirmedAccount = true;

                options.Password = new PasswordOptions
                {
                    RequiredLength = 8,
                    RequireDigit = true,
                    RequireLowercase = true,
                    RequireUppercase = true,
                    RequireNonAlphanumeric = true,
                };

                

            }).AddErrorDescriber<LocalizedIdentityErrorDescriber>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddScoped<Application.Common.Interfaces.IAuthenticationService, Services.AuthenticationService>();
            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
