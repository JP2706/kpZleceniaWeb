using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using kpZleceniaWeb.Shared.User.Dto;
using kpZleceniaWeb.Shared.User.Query;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application.User
{
    public class GetUserQueryHandler : KpBaseHandler, IRequestHandler<GetUserQuery, List<GetUserDto>>
    {
        public GetUserQueryHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService, RoleManager<IdentityRole> roleManager) : base(context, userManager, currentUserService, roleManager)
        {
        }

        public async Task<List<GetUserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var listUsers = new List<GetUserDto>();

            var userFromReq = await _userManager.FindByIdAsync(_currentUserService.UserId);

            var globalAdmin =  await _userManager.GetUsersInRoleAsync(GlobalParameters.GlobalAdminstrator);

            var allRoles = _roleManager.Roles.ToList();

            if(string.IsNullOrEmpty(request.Id))
            {
                if (userFromReq.Id == globalAdmin.FirstOrDefault().Id)
                {

                    var usersFromDb = _context.User.ToList();
                    foreach (var user in usersFromDb)
                    {
                        var roles = await  _userManager.GetRolesAsync(user);

                        var userRoles = new Dictionary<string ,bool>();
                        foreach (var role in allRoles)
                        {
                            if(roles.Contains(role.Name))
                            {
                                userRoles.Add(role.Name, true);
                            }
                            else
                            {
                                userRoles.Add(role.Name, false);
                            }
                        }

                        var userDto = new GetUserDto
                        {
                            Id = user.Id,
                            Email = user.Email,
                            CreatedDate = user.RegisterDateTime,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            IsDeleted = user.IsDeleted,
                            Roles = userRoles
                        };
                        listUsers.Add(userDto);
                    }

                }
                else
                {
                    List<ApplicationUser> usersFromDb;
                    if(_currentUserService.UserId ==  globalAdmin.FirstOrDefault().Id)
                    {
                        usersFromDb = _context.User.ToList();
                    }
                    else
                    {
                        usersFromDb = _context.User.Where(x => x.IsDeleted == false).ToList();
                    }
                     
                    foreach (var user in usersFromDb)
                    {
                        if (user.Id != globalAdmin.First().Id)
                        {
                            var roles = await _userManager.GetRolesAsync(user);

                            var userRoles = new Dictionary<string, bool>();
                            foreach (var role in allRoles)
                            {
                                if (roles.Contains(role.Name))
                                {
                                    userRoles.Add(role.Name, true);
                                }
                                else
                                {
                                    userRoles.Add(role.Name, false);
                                }
                            }
                            var userDto = new GetUserDto
                            {
                                Id = user.Id,
                                Email = user.Email,
                                CreatedDate = user.RegisterDateTime,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                IsDeleted = user.IsDeleted,
                                Roles = userRoles,
                            };
                            listUsers.Add(userDto);
                        }


                    }
                   
                }

            }
            else
            {
                var user = _context.User.FirstOrDefault(x => x.Id == request.Id);
                if (user != null)
                {
                    var roles = await _userManager.GetRolesAsync(user);

                    var userRoles = new Dictionary<string, bool>();
                    foreach (var role in allRoles)
                    {
                        if (roles.Contains(role.Name))
                        {
                            userRoles.Add(role.Name, true);
                        }
                        else
                        {
                            userRoles.Add(role.Name, false);
                        }
                    }

                    var userDto = new GetUserDto
                    {
                        Id = user.Id,
                        Email = user.Email,
                        CreatedDate = user.RegisterDateTime,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        IsDeleted= user.IsDeleted,
                        Roles = userRoles,
                    };
                    listUsers.Add(userDto);
                }
               
            }
            
            

            return listUsers;
        }
    }
}
