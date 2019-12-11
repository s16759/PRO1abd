using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public Guid IdKlient { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public string DaneOsobowe { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
