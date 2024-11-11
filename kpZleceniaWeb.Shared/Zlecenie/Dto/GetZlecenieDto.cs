
using kpZleceniaWeb.Shared.Klient.Dto;
using System.Globalization;

namespace kpZleceniaWeb.Shared.Zlecenie.Dto
{
    public class GetZlecenieDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Urzadzenie { get; set; }
        public string NumerSer { get; set; }
        public string OpisUsterki { get; set; }
        public string Opis { get; set; }
        public DateTime DataPrzyjecie { get; set; }
        public DateTime? DataRozpoczRealizacji { get; set; }
        public DateTime? DataZakRealizacji { get; set; }
        public DateTime? DataWydania { get; set; }
        
        public string ZlecenieStatus { get; set; }
        public int ZlecenieStatusId { get; set; }
        public int KlientId { get; set; }
        public int TypUrzadzeniaId { get; set; }
        public string ApplicationUserId { get; set; }

        public GetKlientDto Klient { get; set; }
    }
}
