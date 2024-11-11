using kpZleceniaWeb.Shared.Zlecenie.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Query
{
    public class GetZlecenieQuery : IRequest<List<GetZlecenieDto>>
    {
        public int Id { get; set; }
    }
}
