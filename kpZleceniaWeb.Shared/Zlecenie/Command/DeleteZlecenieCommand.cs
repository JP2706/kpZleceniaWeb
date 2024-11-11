using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Command
{
    public class DeleteZlecenieCommand : IRequest
    {
        public int ZlecenieId { get; set; }
    }
}
