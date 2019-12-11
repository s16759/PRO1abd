using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Dostawa
    {
        public Guid IdZamowienie { get; set; }
        public Guid IdDostawca { get; set; }
        public int Odleglosc { get; set; }
        public int Czas { get; set; }

        public Dostawca IdDostawcaNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
