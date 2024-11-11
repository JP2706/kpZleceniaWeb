using kpZleceniaWeb.Shared.User.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.User.Query
{
    public class GetUserQuery : IRequest<List<GetUserDto>>
    {
        public string Id { get; set; }
    }
}
