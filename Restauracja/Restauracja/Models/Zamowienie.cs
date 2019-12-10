using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            Dostawa = new HashSet<Dostawa>();
        }

        public Guid IdZamowienie { get; set; }
        public Guid IdKlient { get; set; }
        public Guid IdPizza { get; set; }
        public string IdPromocja { get; set; }
        public int CenaZamowienia { get; set; }
        public string Stan { get; set; }
        public int Czas { get; set; }

        public Klient IdKlientNavigation { get; set; }
        public Pizza IdPizzaNavigation { get; set; }
        public Promocja IdPromocjaNavigation { get; set; }
        public ICollection<Dostawa> Dostawa { get; set; }
    }
}
