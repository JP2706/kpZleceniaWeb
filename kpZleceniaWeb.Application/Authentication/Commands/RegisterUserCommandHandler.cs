using FluentValidation.Results;
using kpZleceniaWeb.Application.Common.Exceptions;
using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Authentication.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Application.Authentication.Commands
{
    public class RegisterUserCommandHandler : KpBaseHandler, IRequestHandler<RegisterUserCommand>
    {
        public RegisterUserCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthenticationService authenticationService) : base(context, userManager, authenticationService)
        {
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var users = _context.User.ToList();
            var userExists = users
               .Any(x =>
                   x.Email == request.Email);

            if (userExists)
                throw new ValidationException("Wybrany email jest już zajęty.");

            var czyAdmin = users.Count == 1 ? true : false;
          
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
                RegisterDateTime = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure { PropertyName = e.Code, ErrorMessage = e.Description });
                throw new ValidationException(errors);
            }

            var resultRole = await _userManager.AddToRoleAsync(user, czyAdmin ? GlobalParameters.Adminstrator : GlobalParameters.Pracownik);

            if(!resultRole.Succeeded)
            {
                var errors = result.Errors.Select(e => new ValidationFailure { PropertyName = e.Code, ErrorMessage = e.Description });
                throw new ValidationException(errors);
            }

        }
    }
}
