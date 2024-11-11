using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application.Authentication.Commands
{
    public class RefreshTokenCommandHandler : KpBaseHandler, IRequestHandler<RefreshTokenCommand, LoginUserDto>
    {
        public RefreshTokenCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthenticationService authenticationService) : base(context, userManager, authenticationService)
        {
        }

        public async Task<LoginUserDto> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var principal = _authenticationService
                .GetPrincipalFromExpiredToken(request.Token);
            var name = principal.Identity.Name;

            var user = await _userManager.FindByEmailAsync(name);

            if (user == null || user.Email != name)
                return new LoginUserDto { ErrorMessage = "Nieprawidłowe żądanie." };

            if (user.RefreshToken != request.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
                return new LoginUserDto { ErrorMessage = "Nieprawidłowe żądanie." };

            var token = await _authenticationService.GetToken(user);
            user.RefreshToken = _authenticationService.GenerateRefreshToken();

            await _userManager.UpdateAsync(user);

            return new LoginUserDto
            {
                Token = token,
                RefreshToken = user.RefreshToken,
                IsAuthSuccessful = true
            };
        }
    }
}
