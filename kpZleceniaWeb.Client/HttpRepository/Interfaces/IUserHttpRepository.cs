using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.User.Command;
using kpZleceniaWeb.Shared.User.Dto;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IUserHttpRepository
    {
        Task<List<GetUserDto>> GetUser(string id = "");
        Task<InfoDto> AddEditUser(AddEditUserCommand command);
        Task DeleteUser(DeleteUserCommand command);
    }
}
