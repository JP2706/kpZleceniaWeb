using MediatR;

namespace kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command
{
    public class DeleteTypUrzadzeniaCommand : IRequest
    {
        public int Id { get; set; }
    }
}
