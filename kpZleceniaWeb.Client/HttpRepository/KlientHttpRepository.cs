using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Klient.Command;
using kpZleceniaWeb.Shared.Klient.Dto;
using System.Net.Http.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class KlientHttpRepository : KpBaseHttpRepository, IKlientHttpRepository
    {
        public KlientHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<GetKlientDto>> GetKlient(int id = 0)
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetKlientDto>>($"klient/get_klient?id={id}");

            return result;
        }

        public async Task AddEditKlient(AddEditKlientCommand command)
        {
            await _httpClient.PostAsJsonAsync("klient/add_edit_klient", command);
        }

        public async Task DeleteKlient(int id)
        {
            var command = new DeleteKlientCommand { KlientId = id};

            await _httpClient.PostAsJsonAsync("klient/delete_klient", command);
        }
    }
}
