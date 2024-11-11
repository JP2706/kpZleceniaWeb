using kpZleceniaWeb.Shared.Common.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace kpZleceniaWeb.Shared.Zlecenie.Command
{
    public class AddEditZlecenieCommand : IRequest<InfoDto>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole 'Symbol' jest wymagane.")]
        [MaxLength(300, ErrorMessage = "Pole 'Symbol' może mieć maksymalnie 300 znaków.")]
        public string Symbol { get; set; }
        [Required(ErrorMessage = "Pole 'Urzadzenie' jest wymagane.")]
        [MaxLength(300, ErrorMessage = "Pole 'Urzadzenie' może mieć maksymalnie 300 znaków.")]
        public string Urzadzenie { get; set; }
        [MaxLength(300, ErrorMessage = "Pole 'Numer Seryjny' może mieć maksymalnie 300 znaków.")]
        public string NumerSer { get; set; }
        [Required(ErrorMessage = "Pole 'Opis Usterki' jest wymagane.")]
        [MaxLength(300, ErrorMessage = "Pole 'Opis Usterki' może mieć maksymalnie 300 znaków.")]
        public string OpisUsterki { get; set; }
        [Required(ErrorMessage = "Pole 'Opis' jest wymagane.")]
        [MaxLength(300, ErrorMessage = "Pole 'Opis' może mieć maksymalnie 300 znaków.")]
        public string Opis { get; set; }
        [Required(ErrorMessage = "Pole 'Data Przyjęcia' jest wymagane.")]
        public DateTime? DataPrzyjecie { get; set; }
        public DateTime? DataRozpoczRealizacji { get; set; }
        public DateTime? DataZakRealizacji { get; set; }
        public DateTime? DataWydania { get; set; }
        public int ZlecenieStatusId { get; set; }
        public int KlientId { get; set; }
        public int TypUrzadzeniaId { get; set; }
        public string ApplicationUserId { get; set; }

    }
}
