using MediatR;

namespace kpZleceniaWeb.Shared.Klient.Command
{
    public class DeleteKlientCommand : IRequest
    {
        public int KlientId { get; set; }   
    }
}
