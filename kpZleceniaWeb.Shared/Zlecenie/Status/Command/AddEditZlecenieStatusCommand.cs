using MediatR;

namespace kpZleceniaWeb.Shared.Zlecenie.Status.Command
{
    public class AddEditZlecenieStatusCommand : IRequest
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
    }
}
