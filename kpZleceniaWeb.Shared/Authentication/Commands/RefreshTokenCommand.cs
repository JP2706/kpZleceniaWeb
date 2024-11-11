using kpZleceniaWeb.Shared.Authentication.Dtos;
using MediatR;

namespace kpZleceniaWeb.Shared.Authentication.Commands
{
    public class RefreshTokenCommand : IRequest<LoginUserDto>
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
