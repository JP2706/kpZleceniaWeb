using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using kpZleceniaWeb.Shared.Common.Models;

namespace kpZleceniaWeb.Client.HttpRepository.Interfaces
{
    public interface IAuthenticationHttpRepository
    {
        Task<string> RefreshToken();
        Task<ResponseDto> RegisterUser(RegisterUserCommand registerUserCommand);
        Task<LoginUserDto> Login(LoginUserCommand userForAuthentication);
        Task Logout();
    }
}
