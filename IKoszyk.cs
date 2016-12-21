using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication4
{
    interface IKoszyk
    {
        void DodajProdukt(string Nazwa,double Cena,int Ilosc);
        void SkopiujOstatni();
        void Skasuj(int Linia);
        void Wydrukuj();
        void Wyczysc();
        string PodajZawartosc();

    }
}
