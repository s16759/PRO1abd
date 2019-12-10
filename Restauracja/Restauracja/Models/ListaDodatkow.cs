using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class ListaDodatkow
    {
        public Guid IdPizza { get; set; }
        public Guid IdDodatek { get; set; }

        public Dodatek IdDodatekNavigation { get; set; }
        public Pizza IdPizzaNavigation { get; set; }
    }
}
