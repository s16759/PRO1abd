using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Sos
    {
        public Sos()
        {
            Pizza = new HashSet<Pizza>();
        }

        public Guid IdSos { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
