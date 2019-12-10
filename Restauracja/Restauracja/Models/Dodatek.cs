using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            ListaDodatkow = new HashSet<ListaDodatkow>();
        }

        public Guid IdDodatek { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public ICollection<ListaDodatkow> ListaDodatkow { get; set; }
    }
}
