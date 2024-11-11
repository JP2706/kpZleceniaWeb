using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command;
using kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Dto;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class UrzadzenieHttpRepository : KpBaseHttpRepository, IUrzadzenieHttpRepository
    {
        public UrzadzenieHttpRepository(HttpClient httpClient): base(httpClient)
        {   
        }

        public async Task<List<GetTypUrzadzeniaDto>> GetTypUrzadzenia(int id = 0)
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetTypUrzadzeniaDto>>($"urzadzenie/get_typ_urzadzenia?id={id}");

            return result;
        }

        public async Task AddEditTypUrzadzenia(AddEditTypUrzadzeniaCommand command)
        {
            await _httpClient.PostAsJsonAsync("urzadzenie/add_edit_typ_urzadzenia", command);
        }

        public async Task DeleteTypUrzadzenia(int id)
        {
           var command = new DeleteTypUrzadzeniaCommand { Id = id };

           await _httpClient.PostAsJsonAsync("urzadzenie/delete_typ_urzadzenia", command);
        }
    }
}
