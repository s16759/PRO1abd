using System;
using System.Collections.Generic;

namespace Restauracja.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            Dostawa = new HashSet<Dostawa>();
            ListaPizz = new HashSet<ListaPizz>();
        }

        public Guid IdZamowienie { get; set; }
        public Guid? IdPromocja { get; set; }
        public Guid? IdKlient { get; set; }
        public int Cena { get; set; }
        public string Stan { get; set; }
        public int Czas { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }

        public Klient IdKlientNavigation { get; set; }
        public Promocja IdPromocjaNavigation { get; set; }
        public ICollection<Dostawa> Dostawa { get; set; }
        public ICollection<ListaPizz> ListaPizz { get; set; }
    }
}
