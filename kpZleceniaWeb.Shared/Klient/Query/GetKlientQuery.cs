using kpZleceniaWeb.Shared.Klient.Dto;
using MediatR;

namespace kpZleceniaWeb.Shared.Klient.Query
{
    public class GetKlientQuery : IRequest<List<GetKlientDto>>
    {
        public int Id { get; set; }
    }
}
