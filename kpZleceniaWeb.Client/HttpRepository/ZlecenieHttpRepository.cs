using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Zlecenie.Command;
using kpZleceniaWeb.Shared.Zlecenie.Dto;
using kpZleceniaWeb.Shared.Zlecenie.Status.Command;
using kpZleceniaWeb.Shared.Zlecenie.Status.Dto;
using System.Net.Http.Json;
using System.Text.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class ZlecenieHttpRepository : KpBaseHttpRepository, IZlecenieHttpRepository
    {
        public ZlecenieHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<GetZlecenieStatusDto>> GetZlecenieStatus(int id = 0)
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetZlecenieStatusDto>>($"zlecenie/get_zlecenie_status?id={id}");

            return result;
        }

        public async Task AddEditZlecenieStatus(AddEditZlecenieStatusCommand command)
        {
           await _httpClient.PostAsJsonAsync("zlecenie/add_edit_zlecenie_status", command); 
        }

        public async Task DeleteZlecenieStatus(int id)
        {
            var command = new DeleteZlecenieStatusCommand { Id = id };

            await _httpClient.PostAsJsonAsync("zlecenie/delete_zlecenie_status", command);
        }

        public async Task<InfoDto> AddEditZlecenie(AddEditZlecenieCommand command)
        {
            var response = await _httpClient.PostAsJsonAsync("zlecenie/add_edit_zlecenie", command);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<InfoDto>(content, _options);

            return result;
        }

        public async Task<List<GetZlecenieDto>> GetZlecenie(int id = 0)
        {
            var content = await _httpClient.GetFromJsonAsync<List<GetZlecenieDto>>($"zlecenie/get_zlecenie?id={id}");

            return content;
        }

        public async Task ChangeZlecenieStatus(ChangeZlecenieStatusCommand command)
        {
            await _httpClient.PostAsJsonAsync("zlecenie/change_zlecenie_status", command);
        }

        public async Task DeleteZlecenie(int id)
        {
            var command = new DeleteZlecenieCommand { ZlecenieId = id };

            await _httpClient.PostAsJsonAsync("zlecenie/delete_zlecenie", command);
        }

        public async Task<List<GetKlientLastZleceniaDto>> GetKlientLastZlecenia(int klientId, int ileRek)
        {
            var content = await _httpClient.GetFromJsonAsync<List<GetKlientLastZleceniaDto>>($"zlecenie/get_klient_last_zlecenia?klientId={klientId}&ileZlec={ileRek}");

            return content;
        }

        public async Task<GetCzyKlientMaZleceniaDto> GetCzyKlientMaZlecenia(int klientId)
        {
            var content = await _httpClient.GetFromJsonAsync<GetCzyKlientMaZleceniaDto>($"zlecenie/get_czy_klient_ma_zlecenia?klientId={klientId}");

            return content;
        }
    }
}
