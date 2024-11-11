using kpZleceniaWeb.Application.Common.Interfaces;
using kpZleceniaWeb.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Application
{
    public class KpBaseHandler
    {
        protected readonly IApplicationDbContext _context;
        protected readonly UserManager<ApplicationUser> _userManager;
        protected readonly IAuthenticationService _authenticationService;
        protected readonly ICurrentUserService _currentUserService;
        protected readonly RoleManager<IdentityRole> _roleManager;

        public KpBaseHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public KpBaseHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, ICurrentUserService currentUserService, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _currentUserService = currentUserService;
            _roleManager = roleManager;
        }

        public KpBaseHandler(IApplicationDbContext context, UserManager<ApplicationUser> userManager, IAuthenticationService authenticationService)
        {
            _context = context;
            _userManager = userManager;
            _authenticationService = authenticationService;
        }
    }
}
