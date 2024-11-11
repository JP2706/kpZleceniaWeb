using MediatR;


namespace kpZleceniaWeb.Shared.Zlecenie.Status.Command
{
    public class DeleteZlecenieStatusCommand : IRequest
    {
        public int Id { get; set; }
    }
}
