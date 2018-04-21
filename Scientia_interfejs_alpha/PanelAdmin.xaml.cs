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
//using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using Microsoft.Win32;




/// <summary>
/// spróbować zrobić polecenia SQL  jako procedury składowane
/// </summary>
namespace Scientia_interfejs_alpha
{
    /// <summary>
    /// Interaction logic for PanelAdmin.xaml
    /// </summary>
    public partial class PanelAdmin : Window
    {
        DataSet ds = new DataSet("Kolo");
        SqlConnectionStringBuilder pol = new SqlConnectionStringBuilder();
        SqlDataAdapter adap = new SqlDataAdapter();
        SqlDataAdapter adap3 = new SqlDataAdapter();
        SqlCommand cm;
        SqlConnection con;
        Regex dane_imie = new Regex("^[A-ZĄĆĘŁŃÓŚŹŻ]{1}[a-ząćęłńóśźż ]{2,15}$");
        Regex dane_nazwisko = new Regex("[a-zA-z]+([ '-][a-zA-Z]+)*");
        Regex numer_tel = new Regex("^([+]{1}[0-9]{2} [0-9]{3} [0-9]{3} [0-9]{3})|([0-9]{11,11})|([0-9]{9})|([0-9]{3}[-]{1}[0-9]{3}[-]{1}[0-9]{3})|([0-9]{3} [0-9]{3} [0-9]{3})$");


        public PanelAdmin()
        {
            InitializeComponent();
            this.DPdzis.SelectedDate = DateTime.Now;

            pol.DataSource = "";                            ////połączenie z bazą
            pol.InitialCatalog = "Ewidencja_SI";
            pol.IntegratedSecurity = true;

            DataTable dane = ds.Tables.Add("Wypozyczenia");
            aktualizacja();


        }
        public class Wypozyczenie
        {
            public int Id { get; set; }

            public string Nazwa { get; set; }

            public string Kod { get; set; }

            public bool aktualne { get; set; }

            public string Data_wypoz { get; set; }

            public string Data_zwrot { get; set; }

            public string Kto { get; set; }

            public string Telefon { get; set; }
        }
        public class Sprzet
        {
            public int Id { get; set; }

            public string Nazwa { get; set; }

            public string Kategoria { get; set; }

            public string Kod { get; set; }

            public string Opis { get; set; }

            public string Stan { get; set; }

            public bool Czywypozyczalny { get; set; }

            public bool Czywypozyczony { get; set; }

            public DateTime Data_wyp { get; set; }

            public DateTime Data_zwr { get; set; }

            public string Kto { get; set; }
        }



        private void MenuItem_Wroc(object sender, RoutedEventArgs e)
        {

            this.Close();

        }

        private void MenuItem_Zamk(object sender, RoutedEventArgs e)
        {

            Application.Current.Shutdown();

        }



        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (RBczl.IsChecked == true)
            {
                CBkto.Visibility = Visibility.Visible;
                lblkto2.Visibility = Visibility.Visible;
                SPdane.Visibility = Visibility.Hidden;
                SPlbl.Visibility = Visibility.Hidden;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            if (RBgosc.IsChecked == true)
            {
                CBkto.Visibility = Visibility.Hidden;
                lblkto2.Visibility = Visibility.Hidden;
                SPdane.Visibility = Visibility.Visible;
                SPlbl.Visibility = Visibility.Visible;
            }
        }

        private void MIedytczlo_Click(object sender, RoutedEventArgs e)//edycja czlonkow
        {
            Wind_Edyt_Czl wind_Edyt_Czl = new Wind_Edyt_Czl();
            wind_Edyt_Czl.ShowDialog();
        }

        private void MIedytzaso_Click(object sender, RoutedEventArgs e)//edycja zasobow
        {
            Win_Edyt_Zas win_Edyt_Zas = new Win_Edyt_Zas();
            win_Edyt_Zas.ShowDialog();
        }

        private void aktualizacja()                 //aktualizacja danych w oknie
        {
            try
            {
                con = new SqlConnection(pol.ConnectionString);

                string zapytanie3 = "SELECT * FROM Osoby";
                adap3 = new SqlDataAdapter(zapytanie3, con);
                adap3.FillSchema(ds, SchemaType.Source, "Osoby");
                adap3.Fill(ds, "Osoby");


            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Błąd");
            }
            var lista_czlonkow = from os in ds.Tables["Osoby"].AsEnumerable()
                                 where os.Field<string>("Nazwisko") != "" & os.Field<string>("Imie") != "" & os.Field<string>("Ranga") != "Gosc"
                                 select new
                                 {
                                     id = os.Field<Int16>("id_osoby"),
                                     dane = os.Field<string>("Imie") + " " + os.Field<string>("Nazwisko")
                                 };
            CBkto.ItemsSource = lista_czlonkow;

            try
            {
                //prowizorka ;)


                ds.Tables["Wypozyczenia"].Clear();

                adap = new SqlDataAdapter();

                string zapytanie = @"SELECT DISTINCT(z.ID_zasobu),z.Nazwa,z.Kod,z.Kategoria,z.Opis,z.Stan_techniczny,z.Czy_wypozyczalny,z.Status_wypozyczenia,
                                     CASE 
                                    WHEN z.Status_wypozyczenia=0  THEN null
		                            WHEN  z.Status_wypozyczenia=1 then FORMAT(w.Data_wypozyczenia, 'dd/MM/yyyy')
                                    END AS Data_wypozyczenia,
                                    CASE 
                                    WHEN z.Status_wypozyczenia=0  THEN null
		                            WHEN  z.Status_wypozyczenia=1 then FORMAT(w.Data_zwrot , 'dd/MM/yyyy')
                                    END AS Data_zwrot,
                                    CASE 
                                    WHEN z.Status_wypozyczenia=0  THEN null
		                            WHEN  z.Status_wypozyczenia=1 then o.Imie+' '+Nazwisko
                                    END AS 'Kto',
                                    CASE 
                                    WHEN z.Status_wypozyczenia=0  THEN null
		                            WHEN  z.Status_wypozyczenia=1 then o.Telefon
                                    END AS Telefon
                                    from Zasoby z
                                    left join Wypozyczenia w on z.ID_zasobu=w.ID_zasobu
                                    left join Osoby o on o.ID_osoby=w.ID_osoby 
                                    where (z.Status_wypozyczenia = 1 and w.aktualne=1) or (z.Status_wypozyczenia = 0 and (w.Data_zwrot is null or
                                    w.Data_zwrot=(select Max(wi.Data_zwrot) from zasoby zi join Wypozyczenia wi on zi.ID_zasobu=wi.ID_zasobu  where zi.ID_zasobu=z.ID_zasobu group by zi.ID_zasobu) ))";
                cm = new SqlCommand(zapytanie, con);
                adap.SelectCommand = cm;
                adap.Fill(ds, "Wypozyczenia");






                dgsprzet.ItemsSource = ds.Tables["Wypozyczenia"].AsDataView();



            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message + " " + exc.Source);
            }
            finally
            {
                con.Close();
            }
            //tu konczy sie prowizorka

            try
            {


                var przeglad = from dane in ds.Tables["Wypozyczenia"].AsEnumerable()
                               where dane.Field<bool>("Status_wypozyczenia") == true
                               select new Wypozyczenie
                               {
                                   Nazwa = dane.Field<string>("Nazwa"),
                                   Kod = dane.Field<string>("Kod"),
                                   aktualne = dane.Field<bool>("Status_wypozyczenia"),
                                   Data_wypoz = dane.Field<string>("Data_wypozyczenia"),
                                   Data_zwrot = dane.Field<string>("Data_zwrot"),
                                   Kto = dane.Field<string>("Kto"),
                                   Telefon = dane.Field<string>("Telefon")
                               };



                DGprzeglad.ItemsSource = przeglad;

            }
            catch (Exception EXC)
            {

                MessageBox.Show(EXC.Message);
            }

        }

        private void btnwypozycz_Click(object sender, RoutedEventArgs e)  //wypozycz
        {

            if (dgsprzet.SelectedValue != null)             //sprawdzanie pustych wartości
            {
                if (DPdokiedy.SelectedDate != null && DPdokiedy.SelectedDate > DateTime.Now)
                {
                    if (CBkto.SelectedValue != null || (RBgosc.IsChecked == true && dane_imie.IsMatch(txtboximie.Text) && dane_nazwisko.IsMatch(txtboxnazwisko.Text) && numer_tel.IsMatch(txtboxnumer.Text)))
                    {

                        try

                        {
                            int id = (Int16)dgsprzet.SelectedValue;
                            //sprawdzanie czy sprzęt jest wolny
                            string zapytanie_spr = @"SELECT count(Status_wypozyczenia) from Zasoby where id_zasobu=" + dgsprzet.SelectedValue + " AND Status_wypozyczenia=1";

                            cm = new SqlCommand(zapytanie_spr, con);
                            con.Open();
                            SqlParameter osoba = null;
                            if ((int)cm.ExecuteScalar() == 0)
                            {
                                con.Close();
                                if (RBgosc.IsChecked == true)               //jeśli gość,dodajemy jego dane do bazy
                                {



                                    try
                                    {
                                        SqlParameter imie = new SqlParameter("@imie", txtboximie.Text);
                                        SqlParameter nazwisko = new SqlParameter("@nazwisko", txtboxnazwisko.Text);
                                        SqlParameter numer = new SqlParameter("@numer", txtboxnumer.Text);
                                        string zapytanie_uzytk = @"INSERT INTO Osoby VALUES (@imie,@nazwisko,'','Gość','','',CURRENT_TIMESTAMP,@numer,'','',1)";

                                        cm = new SqlCommand(zapytanie_uzytk, con);
                                        cm.Parameters.Add(imie);
                                        cm.Parameters.Add(nazwisko);
                                        cm.Parameters.Add(numer);
                                        con.Open();
                                        cm.ExecuteNonQuery();
                                        con.Close();

                                        imie = new SqlParameter("@imie", txtboximie.Text);
                                        nazwisko = new SqlParameter("@nazwisko", txtboxnazwisko.Text);
                                        //pobieranie id gościa
                                        string zapytanie_wyszukaj = @"SELECT id_osoby FROM Osoby WHERE Imie+' '+Nazwisko=@imie+' '+@nazwisko";

                                        cm = new SqlCommand(zapytanie_wyszukaj, con);
                                        cm.Parameters.Add(imie);
                                        cm.Parameters.Add(nazwisko);
                                        con.Open();
                                        SqlDataReader red = cm.ExecuteReader();
                                        if (red.Read())
                                        {
                                            osoba = new SqlParameter("@osoba", red.GetInt16(0));
                                        }
                                    }
                                    catch (Exception exc)
                                    {

                                        MessageBox.Show(exc.Message + " " + exc.Source);
                                    }


                                }                                                                          //koniec z identyfikacją osoby
                                else
                                {
                                    osoba = new SqlParameter("@osoba", CBkto.SelectedValue.ToString());
                                }
                                SqlParameter zasob = new SqlParameter("@zasob", dgsprzet.SelectedValue.ToString());         //dodawanie rekordu do tab wypożyczenia
                                SqlParameter data = new SqlParameter("@data", DPdokiedy.SelectedDate);
                                con.Close();
                                if (osoba != null)
                                {
                                    string zapytanie_wyp = @"INSERT INTO Wypozyczenia 
                                            VALUES(@osoba, @zasob, CURRENT_TIMESTAMP, @data, 1)

                                             UPDATE Zasoby SET Status_wypozyczenia=1 WHERE ID_zasobu=@zasob";

                                    cm = new SqlCommand(zapytanie_wyp, con);
                                    cm.Parameters.Add(osoba);
                                    cm.Parameters.Add(zasob);
                                    cm.Parameters.Add(data);
                                    con.Open();


                                    int spr = cm.ExecuteNonQuery();

                                    con.Close();

                                    if (spr == 2)                                   //sprawdzanie czy wszystko się zaaktualizowało
                                    {
                                        MessageBox.Show("Sukces");

                                        aktualizacja();
                                    }
                                    else if (spr == 1)
                                    {
                                        string poprawa = @"DELETE FROM Wypozyczenia
                                            WHERE Data_wypozyczenia=CURRENT_TIMESTAMP AND aktualne=1 AND ID_zasobu = @zasob

                                             UPDATE Zasoby SET Status_wypozyczenia = 0 WHERE ID_zasobu = @zasob";

                                        cm = new SqlCommand(poprawa, con);
                                        cm.Parameters.Add(zasob);
                                        cm.Parameters.Add(data);
                                        con.Open();


                                        cm.ExecuteNonQuery();
                                        MessageBox.Show("Coś poszło nie tak");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nie znaleziono osoby");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sprzęt jest wypożyczony");
                            }

                        }

                        catch (Exception exc)
                        {

                            MessageBox.Show(exc.Message + " " + exc.Source);
                        }
                        finally
                        {
                            con.Close();
                        }


                        txtboximie.Text = null;
                        txtboxnazwisko.Text = null;
                        txtboxnumer.Text = null;
                        CBkto.SelectedValue = null;
                    }
                    else MessageBox.Show("Proszę wybrać osobę bądź podać poprawnie dane osobowe");
                }
                else MessageBox.Show("Proszę wybrać prawidłową datę");
            }
            else MessageBox.Show("Proszę wybrać sprzęt");


        }

        private void btnoddaj_Click(object sender, RoutedEventArgs e) //oddaj
        {
            if (dgsprzet.SelectedValue != null)
            {

                try                                                 //aktualizacja tabel po oddaniu
                {

                    SqlParameter zasob = new SqlParameter("@zasob", dgsprzet.SelectedValue.ToString());

                    string zapytanie_wyp = @"UPDATE Wypozyczenia 
                                            SET  Data_zwrot=CURRENT_TIMESTAMP,aktualne=0
                                            WHERE ID_zasobu=@zasob And aktualne=1

                                            UPDATE Zasoby SET Status_wypozyczenia=0 WHERE ID_zasobu=@zasob";

                    cm = new SqlCommand(zapytanie_wyp, con);
                    cm.Parameters.Add(zasob);
                    con.Open();

                    if (cm.ExecuteNonQuery() > 0)
                        MessageBox.Show("Sukces");




                    aktualizacja();


                }

                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message + " " + exc.Source);
                }
                finally
                {
                    con.Close();
                }

            }

        }

        private void dgsprzet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) ////wyłączanie buttonów gdy jest coś wyopżyczone lub nie
        {
            for (int i = 0; i < ds.Tables["Wypozyczenia"].Rows.Count; i++)
            {
                if (Convert.ToInt32(ds.Tables["Wypozyczenia"].Rows[i][0]) == Convert.ToInt32(dgsprzet.SelectedValue))
                {
                    if (Convert.ToBoolean(ds.Tables["Wypozyczenia"].Rows[i][6]) == false)
                    {
                        btnwypozycz.IsEnabled = false;
                        btnoddaj.IsEnabled = false;
                        break;
                    }
                    else if (Convert.ToBoolean(ds.Tables["Wypozyczenia"].Rows[i][6]) == true && Convert.ToBoolean(ds.Tables["Wypozyczenia"].Rows[i][7]) == true)
                    {
                        btnwypozycz.IsEnabled = false;
                        btnoddaj.IsEnabled = true;
                        break;
                    }
                    else if (Convert.ToBoolean(ds.Tables["Wypozyczenia"].Rows[i][6]) == true && Convert.ToBoolean(ds.Tables["Wypozyczenia"].Rows[i][7]) == false)
                    {
                        btnwypozycz.IsEnabled = true;
                        btnoddaj.IsEnabled = false;
                        break;
                    }
                }
            }
        }

        private void MIplik_Click(object sender, RoutedEventArgs e)
        {
            //zrzut wypożyczeń do pliku

            SaveFileDialog folder = new SaveFileDialog();
            // miejsce do zapisania plikow txt
            folder.FileName = "Zapisz tutaj";
            Nullable<bool> czy_zapis = folder.ShowDialog();
            if (czy_zapis == true)
            {
                string sciezka_do_folderu = (Path.GetDirectoryName(folder.FileName));
                string[] tablica = new string[] { "Wypozyczenia", "Osoby" };
                try
                {
                    for (int z = 0; z < tablica.Length; z++)
                    {
                        using (StreamWriter zapisz = new StreamWriter(sciezka_do_folderu + "/" + tablica[z] + ".txt"))
                        {
                            foreach (DataColumn item in ds.Tables[tablica[z]].Columns)
                            {
                                zapisz.Write(item.ColumnName + "\t|");
                            }
                            zapisz.WriteLine();
                            for (int i = 0; i < ds.Tables[tablica[z]].Rows.Count; i++)
                            {
                                int kolumna = ds.Tables[tablica[z]].Columns.Count;
                                for (int y = 0; y < ds.Tables[tablica[z]].Columns.Count; y++)
                                {
                                    if (y < kolumna - 1)
                                        zapisz.Write(ds.Tables[tablica[z]].Rows[i][y].ToString() + "\t| ");
                                    else
                                        zapisz.WriteLine(ds.Tables[tablica[z]].Rows[i][y].ToString());
                                }
                            }
                        }
                    }
                    using (StreamWriter zapisz = new StreamWriter(sciezka_do_folderu + "/Zasoby.txt"))
                    {
                        string zapyt = @"SELECT * FROM Zasoby";
                        cm = new SqlCommand(zapyt, con);
                        con.Open();
                        SqlDataReader czytaj = cm.ExecuteReader();
                        while (czytaj.Read())
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (i < 7)
                                    zapisz.Write(czytaj.GetValue(i).ToString() + "\t|");
                                else
                                    zapisz.WriteLine(czytaj.GetValue(i).ToString());
                            }
                        }
                    }

                    MessageBox.Show("Zapisano");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            aktualizacja();
        }
    }
}
