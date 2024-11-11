using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Authentication.Commands;
using kpZleceniaWeb.Shared.Authentication.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application.Authentication.Commands
{
    public class LoginUserCommandHandler : KpBaseHandler, IRequestHandler<LoginUserCommand, LoginUserDto>
    {
        public LoginUserCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthenticationService authenticationService) : base(context, userManager, authenticationService)
        {
        } 

        public async Task<LoginUserDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var badResult = new LoginUserDto();

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                badResult.ErrorMessage = "Nieprawidłowe dane.";
                return badResult;
            }

            if (user.IsDeleted)
            {
                badResult.ErrorMessage = "Nieprawidłowe dane.";
                return badResult;
            }

            //if (!await _userManager.IsEmailConfirmedAsync(user))
            //{
            //    badResult.ErrorMessage = "E-mail nie został jeszcze potwierdzony.";
            //    return badResult;
            //}

            if (await _userManager.IsLockedOutAsync(user))
            {
                badResult.ErrorMessage = "Konto jest zablokowane.";
                return badResult;
            }

            if (!await _userManager.CheckPasswordAsync(user, request.Password))
            {
                await _userManager.AccessFailedAsync(user);

                if (await _userManager.IsLockedOutAsync(user))
                {
                    badResult.ErrorMessage = "Konto zostało zablokowane.";
                    return badResult;
                }

                badResult.ErrorMessage = "Nieprawidłowe dane.";
                return badResult;
            }

            var token = await _authenticationService.GetToken(user);

            user.RefreshToken = _authenticationService.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(14);
            await _userManager.UpdateAsync(user);

            

            await _userManager.ResetAccessFailedCountAsync(user);

            return new LoginUserDto
            {
                IsAuthSuccessful = true,
                Token = token,
                RefreshToken = user.RefreshToken
            };

        }
    }
}
