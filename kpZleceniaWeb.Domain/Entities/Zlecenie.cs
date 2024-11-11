
using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Domain.Entities
{
    [PrimaryKey("Id")]
    public class Zlecenie
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Urzadzenie { get; set; }
        public string NumerSer { get; set; }
        public string OpisUsterki {  get; set; }
        public string Opis { get; set; }
        public DateTime DataPrzyjecie { get; set; }
        public DateTime? DataRozpoczRealizacji { get; set; }
        public DateTime? DataZakRealizacji { get; set; }
        public DateTime? DataWydania { get; set; }
        public int ZlecenieStatusId { get; set; }
        public int KlientId { get; set; }
        public int TypUrzadzeniaId { get; set; }
        public string ApplicationUserId { get; set; }
        public ZlecenieStatus ZlecenieStatus { get; set; }
        public Klient Klient {  get; set; }
        public TypUrzadzenia TypUrzadzeniaT { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime DataModyfikacji { get; set; }
    }
}
