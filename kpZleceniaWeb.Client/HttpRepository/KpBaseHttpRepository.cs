using System.Text.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class KpBaseHttpRepository
    {
        protected HttpClient _httpClient;
        protected readonly JsonSerializerOptions _options =
           new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public KpBaseHttpRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
