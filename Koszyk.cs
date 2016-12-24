using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WpfApplication4
{
    class Koszyk:Produkt
    {
        public List<Produkt> Zakupy;
        public Koszyk() 
        {
          Zakupy = new List<Produkt>();
        }
        public List<Produkt> DodajProdukt(string Nazwa,double Cena,int Ilosc)
        {
            Zakupy.Add(new Produkt(Nazwa, Cena, Ilosc));
            return Zakupy;
        }
        public string usunWybrany(int wybranyWiersz,double Suma,Produkt obiekt)
        {
            if(wybranyWiersz!=-1)
            { 
              Zakupy.RemoveAt(wybranyWiersz);
              Suma = Suma - obiekt.cenaJednostkowa;
             
            }
            return Suma.ToString();
        }
        public string obliczSume()
        {
            double Suma = 0;
            foreach(var element in Zakupy)
            {
                Suma = Suma + element.cenaJednostkowa*element.Ilosc;
            }
            return Suma.ToString();
        }
        private void TworzeFakture(TextWriter Zapis,string Suma,string Sciezka,string Czas)
        {
            
            
          using(Zapis)
          { 
            Zapis.WriteLine("Data: "+Sciezka+"Czas: "+Czas);
            foreach(var element in Zakupy)
            {
                Zapis.WriteLine("Nazwa: "+element.Nazwa.ToString() + "," +"Cena: "+ element.cenaJednostkowa.ToString() + "," +"Ilość: "+ element.Ilosc.ToString());
            }
            Zapis.WriteLine("Zaplacono : {0}", Suma);
            Zapis.Close();
          }
        }
        public void zapisDoPliku(string Suma)
        {
            string Dzien = DateTime.Now.Day.ToString();
            string Miesiac = DateTime.Now.Month.ToString();
            string Rok = DateTime.Now.Year.ToString();
            string Czas = DateTime.Today.Hour.ToString() + " " + DateTime.Today.Second.ToString();
            string Sciezka=Dzien +" "+ Miesiac+" " + Rok +" "+Czas+" "+ ".txt";
            if (File.Exists(Sciezka))
            {
                TextWriter Zapis = new StreamWriter("TOSAMO"+Sciezka, true);
                TworzeFakture(Zapis, Suma,Sciezka,Czas);
            }
            if(!File.Exists(Sciezka))
            {
                TextWriter Zapis = new StreamWriter(Sciezka, true);
                TworzeFakture(Zapis,Suma,Sciezka,Czas);
            }
            
        }
        public void kopiujeOstatni()
        {
            int rozmiarListy = Zakupy.Count;
            Produkt ostatniElement = (Produkt)Zakupy[rozmiarListy - 1];
            Produkt kopia = new Produkt();
            kopia = (Produkt)ostatniElement.Clone();
            Zakupy.Add(new Produkt(kopia.Nazwa, kopia.cenaJednostkowa, kopia.Ilosc));
        }
    }
}
