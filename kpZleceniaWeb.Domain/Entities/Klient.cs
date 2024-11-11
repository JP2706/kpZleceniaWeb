using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Domain.Entities
{
    [PrimaryKey("Id")]
    public class Klient
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nazwa { get; set; }
        public string Tel { get; set; }

        public List<Zlecenie> Zlecenie { get; set; }
    }
}
