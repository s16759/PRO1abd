using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            ListaDodatkow = new HashSet<ListaDodatkow>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public Guid IdPizza { get; set; }
        public Guid? IdSos { get; set; }
        public string IdPromocja { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }
        public int Rozmiar { get; set; }

        public Promocja IdPromocjaNavigation { get; set; }
        public Sos IdSosNavigation { get; set; }
        public ICollection<ListaDodatkow> ListaDodatkow { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
