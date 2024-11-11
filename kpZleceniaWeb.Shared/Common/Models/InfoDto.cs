using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kpZleceniaWeb.Shared.Common.Models
{
    public class InfoDto
    {
        public InfoDto()
        {
            Info = string.Empty;
        }

        public int Blad {  get; set; }
        public string Info { get; set; }
    }
}
