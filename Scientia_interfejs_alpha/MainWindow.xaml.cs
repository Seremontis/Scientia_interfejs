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
using System.Data;
using System.Data.SqlClient;

namespace Scientia_interfejs_alpha
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataSet ds = new DataSet();
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlConnection con;
        SqlConnectionStringBuilder pol = new SqlConnectionStringBuilder();


        public MainWindow()
        {
            InitializeComponent();           
            pol.DataSource = "";
            pol.InitialCatalog = "Ewidencja_SI";
            pol.IntegratedSecurity = true;

            con = new SqlConnection(pol.ConnectionString);

            odswiez();

        }
        public class Sprzet
        {
                public int Id { get; set; }

                public string Nazwa { get; set; }

                public string Kategoria { get; set; }

                public string Opis { get; set; }

                public string Stan { get; set; }

                public bool Czywypozyczalny { get; set; }

                public bool Czywypozyczony { get; set; }


        }
        
        private void BtnPanel_Click(object sender, RoutedEventArgs e)
        {
            LogAdmin logadm = new LogAdmin(pol.DataSource,pol.InitialCatalog);
            logadm.ShowDialog();            
        }
        private void BtnO_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Witaj użytkowniku! Jesteśmy wielce zadowoleni, że korzystasz z naszego programu mamy nadzieję, że Ci się spodoba!", "O programie");
        }

        private void plak_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                
                System.Diagnostics.Process.Start("http://knsi.ue.katowice.pl/");
            }
            catch { }
        }

        private void plak_MouseEnter(object sender, MouseEventArgs e)
        {
            plak.Opacity = .2;
        }

        private void plak_MouseLeave(object sender, MouseEventArgs e)
        {
            plak.Opacity = 1;
        }

        private void Lblkom_MouseEnter(object sender, MouseEventArgs e)
        {
            BtnPanel.FontWeight = FontWeights.ExtraBold;
        }

        private void Lblkom_MouseLeave(object sender, MouseEventArgs e)
        {
            BtnPanel.FontWeight = FontWeights.Normal;
        }

        private void CBfiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          

            string text = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content as string;

            if (text=="wszystko")
            {
                var x = from z in ds.Tables["Zasoby"].AsEnumerable()                                            
                             select new Sprzet
                            {
                                Id = z.Field<Int16>("id_zasobu"),
                                Nazwa = z.Field<string>("Nazwa"),
                                Stan = z.Field<string>("Stan_techniczny"),
                                Opis = z.Field<string>("Opis"),
                                Kategoria = z.Field<string>("Kategoria"),
                                Czywypozyczalny = z.Field<bool>("Czy_wypozyczalny"),
                                Czywypozyczony = z.Field<bool>("Status_wypozyczenia")

                            };
                dgsprzet.ItemsSource = x;
            }
            else
            {
                var x = from z in ds.Tables["Zasoby"].AsEnumerable()                         
                        where z.Field<string>("Kategoria") == text
                             select new Sprzet
                             {
                                 Id = z.Field<Int16>("id_zasobu"),
                                 Nazwa = z.Field<string>("Nazwa"),
                                 Stan = z.Field<string>("Stan_techniczny"),
                                 Opis = z.Field<string>("Opis"),
                                 Kategoria = z.Field<string>("Kategoria"),
                                 Czywypozyczalny = z.Field<bool>("Czy_wypozyczalny"),
                                 Czywypozyczony = z.Field<bool>("Status_wypozyczenia")

                             };
                dgsprzet.ItemsSource = x;
            }

            
                 
        } //filtrowanie listy sprzętu

        private void odswiez()
        {
            try
            {                                                                                               //tworzenie lub odwieza tabel w datasecie

                string zapytanie2 = "SELECT * FROM Zasoby";
                adap = new SqlDataAdapter(zapytanie2, con);                                   
                adap.FillSchema(ds, SchemaType.Source, "Zasoby");
                adap.Fill(ds, "Zasoby");




            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd");
            }
            

            var wszystko = from z in ds.Tables["Zasoby"].AsEnumerable()
                           select new Sprzet
                           {
                               Id = z.Field<Int16>("id_zasobu"),
                               Nazwa = z.Field<string>("Nazwa"),
                               Stan = z.Field<string>("Stan_techniczny"),
                               Opis = z.Field<string>("Opis"),
                               Kategoria = z.Field<string>("Kategoria"),
                               Czywypozyczalny = z.Field<bool>("Czy_wypozyczalny"),
                               Czywypozyczony = z.Field<bool>("Status_wypozyczenia")

                           };

            dgsprzet.ItemsSource = wszystko;
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            ds.Tables["Zasoby"].Clear();
            odswiez();
        }
    }
}
