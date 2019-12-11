using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            ListaDodatkow = new HashSet<ListaDodatkow>();
            ListaPizz = new HashSet<ListaPizz>();
        }

        public Guid IdPizza { get; set; }
        public Guid? IdPromocja { get; set; }
        public Guid? IdSos { get; set; }
        public int IdRozmiar { get; set; }
        public string Nazwa { get; set; }
        public int Cena { get; set; }

        public Promocja IdPromocjaNavigation { get; set; }
        public Rozmiar IdRozmiarNavigation { get; set; }
        public Sos IdSosNavigation { get; set; }
        public ICollection<ListaDodatkow> ListaDodatkow { get; set; }
        public ICollection<ListaPizz> ListaPizz { get; set; }
    }
}
