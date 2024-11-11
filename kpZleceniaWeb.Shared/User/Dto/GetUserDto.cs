
using kpZleceniaWeb.Shared.Klient.Dto;

namespace kpZleceniaWeb.Shared.User.Dto
{
    public class GetUserDto
    {
        public GetUserDto()
        {
            Roles = new();
        }

        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }

        public Dictionary<string, bool> Roles { get; set; }
    }
}
