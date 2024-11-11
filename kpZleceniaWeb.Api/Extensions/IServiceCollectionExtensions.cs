using System.Globalization;

namespace kpZleceniaWeb.Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCulture(this IServiceCollection service)
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("pl-PL")
            };

            CultureInfo.DefaultThreadCurrentCulture = supportedCultures[0];
            CultureInfo.DefaultThreadCurrentUICulture = supportedCultures[0];

            service.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
    }
}
