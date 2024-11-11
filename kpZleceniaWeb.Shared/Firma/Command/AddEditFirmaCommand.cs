using kpZleceniaWeb.Shared.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace kpZleceniaWeb.Shared.Firma.Command
{
    public class AddEditFirmaCommand : IRequest<InfoDto>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole 'Nip' jest wymagane.")]
        public string Nip { get; set; }
        [Required(ErrorMessage = "Pole 'Nazwa' jest wymagane.")]
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Pole 'Telefon' jest wymagane.")]
        public string Telefon { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Pole 'Ulica' jest wymagane.")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Pole 'Numer Domu' jest wymagane.")]
        public string NumerDomu {  get; set; }
        public string NumerLokalu { get; set; }
        [Required(ErrorMessage = "Pole 'Miejscowość' jest wymagane.")]
        public string Miejscowosc {  get; set; }
        [Required(ErrorMessage = "Pole 'Kod Pocztowy' jest wymagane.")]
        public string KodPocztowy {  get; set; }
        [Required(ErrorMessage = "Pole 'Poczta' jest wymagane.")]
        public string Poczta { get; set; }
    }
}
