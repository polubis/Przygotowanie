using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4
{
    class Produkt:ICloneable
    {
        public string Nazwa { get; set; }
        public double cenaJednostkowa { get; set; }
        public int Ilosc { get; set; }
        public Produkt() { }
        public Produkt(string Nazwa,double cenaJednostkowa,int Ilosc)
        {
            this.Nazwa = Nazwa;
            this.cenaJednostkowa = cenaJednostkowa;
            this.Ilosc = Ilosc;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public double PodajCeneLaczna()
        {
            return Math.Round(cenaJednostkowa * Ilosc);
        }
        public string ToString()
        {
            return Nazwa+","+cenaJednostkowa.ToString()+"*"+Ilosc.ToString()+"="+PodajCeneLaczna().ToString();
            
        }
    }
}
