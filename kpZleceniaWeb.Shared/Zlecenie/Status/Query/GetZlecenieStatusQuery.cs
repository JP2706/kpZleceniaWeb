using kpZleceniaWeb.Shared.Zlecenie.Status.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Status.Query
{
    public class GetZlecenieStatusQuery : IRequest<List<GetZlecenieStatusDto>>
    {
        public int Id { get; set; }
    }
}
