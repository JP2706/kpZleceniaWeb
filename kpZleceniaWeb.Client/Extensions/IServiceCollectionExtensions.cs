using System.Globalization;

namespace kpZleceniaWeb.Client.Extensions
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

            
        }
    }
}
