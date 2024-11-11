using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Status.Command
{
    public class ChangeZlecenieStatusCommand : IRequest
    {
        public int ZlecenieId { get; set; }
        public int ZlecenieStatusId { get; set; }
    }
}
