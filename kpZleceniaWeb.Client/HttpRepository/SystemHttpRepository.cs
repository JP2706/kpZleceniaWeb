using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using System.Net.Http.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class SystemHttpRepository : KpBaseHttpRepository, ISystemHttpRepository
    {
        public SystemHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<pAppComboDto>> pAppCombo(string forms, string combo)
        {
            var result = await _httpClient.GetFromJsonAsync<List<pAppComboDto>>($"system/p_app_combo?forms={forms}&combo={combo}");

            return result;
        }
    }
}
