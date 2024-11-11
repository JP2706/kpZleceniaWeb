using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.Common.Models;
using kpZleceniaWeb.Shared.User.Command;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application.User
{
    public class AddEditUserCommandHandler : KpBaseHandler, IRequestHandler<AddEditUserCommand, InfoDto>
    {
        public AddEditUserCommandHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService, RoleManager<IdentityRole> roleManager) : base(context, userManager, currentUserService, roleManager)
        {
        }

        public async Task<InfoDto> Handle(AddEditUserCommand request, CancellationToken cancellationToken)
        {
            var returnResult = new InfoDto();

            if(string.IsNullOrEmpty(request.Id))
            {

            }
            else
            {
                var user = _userManager.Users.FirstOrDefault(x => x.Id == request.Id);
                if(user != null)
                {
                    user.Email = request.Email;
                    user.FirstName = request.FirstName; 
                    user.LastName = request.LastName;
                    var result =  await _userManager.UpdateAsync(user);

                    if(!result.Succeeded)
                    {
                        returnResult.Blad = -100;
                        foreach(var item in result.Errors)
                        {
                            returnResult.Info += item.Description + " ";
                        }
                        return returnResult;
                    }

                    var userRoles = await _userManager.GetRolesAsync(user);

                    foreach (var role in request.Roles)
                    {
                        if (role.Value == true)
                        {
                            if(!userRoles.Contains(role.Key))
                            {
                               var result1 =  await _userManager.AddToRoleAsync(user, role.Key);

                                if (!result1.Succeeded)
                                {
                                    returnResult.Blad = -100;
                                    foreach (var item in result1.Errors)
                                    {
                                        returnResult.Info += item.Description + " ";
                                    }
                                    return returnResult;
                                }
                            }
                        }
                        else
                        {
                            if (userRoles.Contains(role.Key))
                            {
                                var result2 = await _userManager.RemoveFromRoleAsync(user, role.Key);

                                if (!result2.Succeeded)
                                {
                                    returnResult.Blad = -100;
                                    foreach (var item in result2.Errors)
                                    {
                                        returnResult.Info += item.Description + " ";
                                    }
                                    return returnResult;
                                }
                            }
                        }
                    }
                }

                if(request.PCH)
                {
                    var userPasswordHash = user.PasswordHash;
                    var passChangeResult = await _userManager.ChangePasswordAsync(user, userPasswordHash, request.Password);

                    if (!passChangeResult.Succeeded)
                    {
                        returnResult.Blad = -100;
                        foreach (var item in passChangeResult.Errors)
                        {
                            returnResult.Info += item.Description + " ";
                        }
                        return returnResult;
                    }
                }
            }

            return returnResult;
        }
    }
}
