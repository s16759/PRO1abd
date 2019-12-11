using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class ListaPizz
    {
        public Guid IdPizza { get; set; }
        public Guid IdZamowienie { get; set; }

        public Pizza IdPizzaNavigation { get; set; }
        public Zamowienie IdZamowienieNavigation { get; set; }
    }
}
