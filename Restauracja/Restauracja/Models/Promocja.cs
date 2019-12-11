using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            Pizza = new HashSet<Pizza>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public Guid IdPromocja { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }
        public float Multiplier { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
