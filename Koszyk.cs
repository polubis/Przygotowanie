using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4
{
    class Koszyk
    {
        public List<Produkt> Zakupy;
        public Koszyk() 
        {
        }
        public List<Produkt> DodajProdukt(string Nazwa,double Cena,int Ilosc)
        {
            Zakupy = new List<Produkt>();
            Zakupy.Add(new Produkt(Nazwa, Cena, Ilosc));
            return Zakupy;
        }
    }
}
