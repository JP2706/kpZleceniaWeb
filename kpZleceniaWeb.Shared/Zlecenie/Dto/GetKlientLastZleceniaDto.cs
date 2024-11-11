using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpZleceniaWeb.Shared.Zlecenie.Dto
{
    public class GetKlientLastZleceniaDto
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

        public int Id_k { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        public string Tel { get; set; }
    }
}
