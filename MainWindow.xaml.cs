using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Koszyk koszyk = new Koszyk();
        
        public MainWindow()
        {
            InitializeComponent();
            pobierzIlosc.Text = "1";
            wynikSumy.Text = "0";
            
        }
     
        private void dodajClick(object sender, RoutedEventArgs e)
        {
            
            if(string.IsNullOrEmpty(Convert.ToString(pobierzNazwe.Text)) ||string.IsNullOrEmpty(Convert.ToString(pobierzCene.Text)))
            {
                MessageBox.Show("Nie masz wartosci w wymaganych polach (patrz[Nazwa,Cena])");
            }
            else
            {
                try
                {
                    koszyk.DodajProdukt(Convert.ToString(pobierzNazwe.Text), Double.Parse(pobierzCene.Text), Convert.ToInt32(pobierzIlosc.Text));
                    listaProduktow.ItemsSource = koszyk.Zakupy;
                    CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource).Refresh();
                    wynikSumy.Text = koszyk.obliczSume();
                }
                catch
                {
                    MessageBox.Show("Wartosci w polach cena i ilosc musza byc wartosciami liczbowymi");
                }
            }
        }

        private void skasujClick(object sender, RoutedEventArgs e)
        {
            int wybranyWiersz = listaProduktow.SelectedIndex;
            Produkt wybranaWartosc = (Produkt)listaProduktow.SelectedItem;
            wynikSumy.Text = koszyk.usunWybrany(wybranyWiersz, Double.Parse(wynikSumy.Text), wybranaWartosc);
           
            CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource).Refresh();

        }
        private void czyszczeBoxy()
        {
            wynikSumy.Text = "0";
            pobierzCene.Text = "";
            pobierzIlosc.Text = "1";
            pobierzNazwe.Text = "";
        }
        private void wyczyscWszystko(object sender, RoutedEventArgs e)
        {
            koszyk.Zakupy.Clear();
            CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource).Refresh();
            czyszczeBoxy();
        }

        private void wyjscieClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void wydrukujClick(object sender, RoutedEventArgs e)
        {
            string Suma = wynikSumy.Text;
            koszyk.zapisDoPliku(Suma);
            koszyk.Zakupy.Clear();
            CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource).Refresh();
            MessageBox.Show("Dziekujemy za skorzystanie z naszych uslug. Miłego dnia.");
            czyszczeBoxy();
        }

        private void kopiujClick(object sender, RoutedEventArgs e)
        {
            koszyk.kopiujeOstatni();
            CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource).Refresh();
        }

    

          
    }
}
