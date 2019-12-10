using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            Dostawa = new HashSet<Dostawa>();
        }

        public Guid IdDostawca { get; set; }
        public string DaneOsobowe { get; set; }
        public string Polozenie { get; set; }

        public ICollection<Dostawa> Dostawa { get; set; }
    }
}
