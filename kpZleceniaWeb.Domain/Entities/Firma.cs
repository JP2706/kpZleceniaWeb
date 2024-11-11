using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace kpZleceniaWeb.Domain.Entities
{
    [PrimaryKey("Id")]
    public class Firma
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string NIP { get; set; }
        public string Adres {  get; set; } 
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Ulica { get; set; }
        public string NumerDomu { get; set; }
        public string NumerLokalu { get; set; }
        public string Miejscowosc { get; set; }
        public string KodPocztowy { get; set; }
        public string Poczta { get; set; }
    }
}
