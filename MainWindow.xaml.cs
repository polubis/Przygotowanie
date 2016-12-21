using System;
using System.Collections.Generic;
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
            listaProduktow.ItemsSource = koszyk.Zakupy;
            CollectionView Widok = (CollectionView)CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource);
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
                    koszyk.DodajProdukt(pobierzNazwe.Text, Convert.ToDouble(pobierzCene.Text), Convert.ToInt32(pobierzIlosc.Text));
                    listaProduktow.ItemsSource = koszyk.Zakupy;
                    CollectionView Widok = (CollectionView)CollectionViewSource.GetDefaultView(listaProduktow.ItemsSource);
                }
                catch
                {
                    MessageBox.Show("Wartosci w polach cena i ilosc musza byc wartosciami liczbowymi");
                }
            }
        }

          
    }
}
