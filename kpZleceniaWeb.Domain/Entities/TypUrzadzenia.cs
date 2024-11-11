

using Microsoft.EntityFrameworkCore;

namespace kpZleceniaWeb.Domain.Entities
{
    [PrimaryKey("Id")]
    public class TypUrzadzenia
    {
        public int Id { get; set; }
        public string Nazwa {  get; set; }

        public List<Zlecenie> Zlecenie { get; set; }
    }
}
