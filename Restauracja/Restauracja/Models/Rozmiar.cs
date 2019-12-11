using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdRozmiar { get; set; }
        public string Nazwa { get; set; }
        public float Multiplier { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
