using kpZleceniaWeb.Client.HttpRepository.Interfaces;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.User.Command;
using kpZleceniaWeb.Shared.User.Dto;
using System.Net.Http.Json;
using System.Text.Json;

namespace kpZleceniaWeb.Client.HttpRepository
{
    public class UserHttpRepository : KpBaseHttpRepository, IUserHttpRepository
    {
        public UserHttpRepository(HttpClient httpClient) : base(httpClient)
        {
        }

        public async Task<List<GetUserDto>> GetUser(string id = "")
        {
            var result = await _httpClient.GetFromJsonAsync<List<GetUserDto>>($"user/get_user?id={id}");

            return result;
        }

        public async Task<InfoDto> AddEditUser(AddEditUserCommand command)
        {
           var response = await _httpClient.PostAsJsonAsync("user/add_edit_user", command);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<InfoDto>(content, _options);

            return result;
        }

        public async Task DeleteUser(DeleteUserCommand command)
        {
            await _httpClient.PostAsJsonAsync("user/delete_user", command);
        }
    }
}
