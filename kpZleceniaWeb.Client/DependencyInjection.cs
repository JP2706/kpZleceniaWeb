using kpZleceniaWeb.Client.AuthStateProviders;
using kpZleceniaWeb.Client.HttpInterceptor;
using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Client.HttpRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using kpZleceniaWeb.Client.Services.Interfaces;
using kpZleceniaWeb.Client.Services;
using Microsoft.FluentUI.AspNetCore.Components;

namespace kpZleceniaWeb.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClient(this IServiceCollection services, Uri uri)
        {
            services.AddHttpClient("kpZleceniaWebApi", (sp, client) =>
            {
                client.BaseAddress = uri;
                client.Timeout = TimeSpan.FromMinutes(15);
                client.EnableIntercept(sp);
            });

            services.AddScoped(sp =>
                sp.GetService<IHttpClientFactory>().CreateClient("kpZleceniaWebApi"));

            services.AddFluentUIComponents();

            services.AddHttpClientInterceptor();

            services.AddScoped<HttpInterceptorService>();

            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
            services.AddScoped<IAuthenticationHttpRepository, AuthenticationHttpRepository>();
            services.AddScoped<RefreshTokenService>();
            services.AddScoped<CookieStorageService>();
            services.AddScoped<IUrzadzenieHttpRepository, UrzadzenieHttpRepository>();
            services.AddScoped<ISystemHttpRepository, SystemHttpRepository>();
            services.AddScoped<IZlecenieHttpRepository, ZlecenieHttpRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IFirmaHttpRepository, FirmaHttpRepository>();
            services.AddScoped<IUserHttpRepository, UserHttpRepository>();
            services.AddScoped<IKlientHttpRepository, KlientHttpRepository>();

            return services;
        }
    }
}
