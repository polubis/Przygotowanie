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
            Zakupy = new List<Produkt>();
        }
        public void DodajProdukt(string Nazwa,double Cena,int Ilosc)
        {
            Zakupy.Add(new Produkt(Nazwa, Cena, Ilosc));
        }
    }
}
