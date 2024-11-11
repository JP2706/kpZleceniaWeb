using MediatR;
using System.ComponentModel.DataAnnotations;


namespace kpZleceniaWeb.Shared.Klient.Command
{
    public class AddEditKlientCommand : IRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Pole 'Imię' jest wymagane!")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Pole 'Nazwisko' jest wymagane!")]
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        [Required(ErrorMessage = "Pole 'Telefon' jest wymagane!")]
        public string Tel { get; set; }
    }
}
