using MediatR;
using System.ComponentModel.DataAnnotations;

namespace kpZleceniaWeb.Shared.Urzadzenie.TypUrzadzenia.Command
{
    public class AddEditTypUrzadzeniaCommand : IRequest
    {
        public int Id { get; set; }
        //walidacja na oknie
        public string Nazwa { get; set; }
    }
}
