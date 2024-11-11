using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Firma.Command;
using kpZleceniaWeb.Shared.Firma.Dto;
using System.Net.Http.Json;
using System.Text.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class FirmaHttpRepository : KpBaseHttpRepository, IFirmaHttpRepository
    {
        public FirmaHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<InfoDto> AddEditFirma(AddEditFirmaCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync("firma/add_edit_firma", command);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<InfoDto>(content, _options);

            return result;
        }

        public async Task<bool> CzyFirma()
        {
            var result = await _httpClient.GetFromJsonAsync<CzyBrakFirmyDto>($"firma/czy_firma");

            return result.CzyBrakFirmy;
        }

        public async Task<GetFirmaDto> GetFirma()
        {
            var result = await _httpClient.GetFromJsonAsync<GetFirmaDto>($"firma/get_firma");

            return result;
        }
    }
}
