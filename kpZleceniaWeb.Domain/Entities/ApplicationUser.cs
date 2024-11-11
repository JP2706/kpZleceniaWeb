using Microsoft.AspNetCore.Identity;

namespace kpZleceniaWeb.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime RegisterDateTime { get; set; }

        public List<Zlecenie> Zlecenie { get; set; }
     
    }
}
