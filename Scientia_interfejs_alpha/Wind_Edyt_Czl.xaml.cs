using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Scientia_interfejs_alpha
{
    /// <summary>
    /// Interaction logic for Wind_Edyt_Czl.xaml
    /// </summary>
    public partial class Wind_Edyt_Czl : Window
    {
        SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
        DataSet ds = new DataSet();
        DateTime dzis = DateTime.Today;
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        public Wind_Edyt_Czl()
        {
            InitializeComponent();
            cs.DataSource = "";
            cs.InitialCatalog = "Ewidencja_SI";
            cs.IntegratedSecurity = true;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            odswiez_datagrid();
        }
        /*public class Czlonek
        {
            public int Id { get; set; }

            public string Imie { get; set; }

            public string Nazwisko { get; set; }

            public string Nr_alb { get; set; }

            public string Ranga { get; set; }

            public string Login { get; set; }

            public string Haslo { get; set; }

            public DateTime Data_dol { get; set; }

            public string Telefon { get; set; }

            public string Email { get; set; }

            public string Opis { get; set; }

            public bool Czy_aktywny { get; set; }
        }*/
        private void czysc()
        {
            txthaslo.Text = null;
            txtimie.Text = null;
            txtlog.Text = null;
            txtmail.Text = null;
            txtnazwi.Text = null;
            txtnr_alb.Text = null;
            txtopis.Text = null;
            txttele.Text = null;
            cb_czyakty.IsChecked = false;
            cmb_rang.Text = null;
            btndodaj.IsEnabled = true;
            btnedytuj.IsEnabled = false;
        }
        private void btnczysc_Click(object sender, RoutedEventArgs e)
        {
            czysc();
        }

        private void odswiez_datagrid()
        {
            DGczlon.ItemsSource = null;

            string zap = "SELECT * FROM Osoby ";
            da = new SqlDataAdapter(zap, cs.ConnectionString);
            da.FillSchema(ds,SchemaType.Source, "Czlonkowie");
            da.Fill(ds, "Czlonkowie");           
            DGczlon.ItemsSource = ds.Tables["Czlonkowie"].DefaultView;
        }
        private void DGczlon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Int16 wybrany = Convert.ToInt16(DGczlon.SelectedValue);
            btndodaj.IsEnabled = false;
            btnedytuj.IsEnabled = true;

            if (DGczlon.SelectedIndex != -1)
            {
                foreach (DataRow rw in ds.Tables["Czlonkowie"].AsEnumerable())
                {
                    if (rw.Field<Int16>("id_osoby") == wybrany)
                    {
                        txtimie.Text = rw.Field<string>("Imie");
                        txtnazwi.Text = rw.Field<string>("Nazwisko");
                        txtnr_alb.Text = rw.Field<string>("Nr_albumu");
                        cmb_rang.Text = rw.Field<string>("Ranga");
                        txtlog.Text = rw.Field<string>("Logg");
                        txthaslo.Text = rw.Field<string>("Haslo");
                        txttele.Text = rw.Field<string>("Telefon");
                        txtmail.Text = rw.Field<string>("E_mail");
                        txtopis.Text = rw.Field<string>("Opis");
                        cb_czyakty.IsChecked = rw.Field<Boolean>("Czy_aktywny");
                        break;
                    }
                }
            }
            else
            {
                czysc();
            }
        }

        private void btndodaj_Click(object sender, RoutedEventArgs e)
        {
            bool spr = false;
            if (txttele.Text != null)
            {
                foreach (var rw in ds.Tables["Czlonkowie"].AsEnumerable())
                {
                    if (rw.Field<string>("Telefon") == txttele.Text)
                    {
                        MessageBox.Show("Podany nr alb już jest zajęty");
                        spr = true;
                        break;
                    }
                }
            }

            if (spr == false && txtimie.Text != null && txtnazwi.Text != null)
            {
                try
                {
                    sqlConnection = new SqlConnection(cs.ToString());
                    sqlConnection.Open();
                    string zap = "INSERT INTO Osoby VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)";
                    sqlCommand = new SqlCommand(zap, sqlConnection);
                    sqlCommand.Parameters.Add("@p1", SqlDbType.NVarChar).Value = txtimie.Text;
                    sqlCommand.Parameters.Add("@p2", SqlDbType.NVarChar).Value = txtnazwi.Text;
                    sqlCommand.Parameters.Add("@p3", SqlDbType.NVarChar).Value = txtnr_alb.Text;
                    sqlCommand.Parameters.Add("@p4", SqlDbType.NVarChar).Value = cmb_rang.Text;
                    sqlCommand.Parameters.Add("@p5", SqlDbType.VarChar).Value = txtlog.Text;
                    sqlCommand.Parameters.Add("@p6", SqlDbType.VarChar).Value = txthaslo.Text;
                    sqlCommand.Parameters.Add("@p7", SqlDbType.Date).Value = dzis;
                    sqlCommand.Parameters.Add("@p8", SqlDbType.NVarChar).Value = txttele.Text;
                    sqlCommand.Parameters.Add("@p9", SqlDbType.NVarChar).Value = txtmail.Text;
                    sqlCommand.Parameters.Add("@p10", SqlDbType.NVarChar).Value = txtopis.Text;
                    sqlCommand.Parameters.Add("@p11", SqlDbType.Bit).Value = cb_czyakty.IsChecked;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    czysc();
                    MessageBox.Show("Dodano członka", "Sukces");
                    odswiez_datagrid();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message, "Błąd");
                }
            }
        }



        private void btnedytuj_Click(object sender, RoutedEventArgs e)
        {
            bool spr = false;
            if (!(string.IsNullOrEmpty(txttele.Text)))
            {
                if (!(string.IsNullOrEmpty(txtnr_alb.Text)))
                {
                    foreach (var rw in ds.Tables["Czlonkowie"].AsEnumerable())
                    {
                        if (rw.Field<string>("Telefon") == txttele.Text && (rw.Field<string>("Imie") != txtimie.Text && rw.Field<string>("Nazwisko") != txtnazwi.Text))
                        {
                            MessageBox.Show("Podany telefon już jest zajęty");
                            spr = true;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (var rw in ds.Tables["Czlonkowie"].AsEnumerable())
                    {
                        if (rw.Field<string>("Telefon") == txttele.Text || rw.Field<string>("Nr_albumu") == txtnr_alb.Text && (rw.Field<string>("Imie") != txtimie.Text && rw.Field<string>("Nazwisko") != txtnazwi.Text))
                        {
                            MessageBox.Show("Podany telefon bądź numer albumu już jest zajęty");
                            spr = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak numeru telefonu");
                spr = true;
            }
            

            if (spr == false && txtimie.Text != null && txtnazwi.Text != null)
            {
                string zap = "UPDATE Osoby SET Imie=@Imie, Nazwisko=@Nazwisko, Nr_albumu=@Nr_albumu, Ranga=@Ranga, Logg=@Login, Haslo=@Haslo, Data_dolaczenia=@Data_dol, Telefon=@Telefon, E_mail=@E_mail, Opis=@Opis, Czy_aktywny=@Czy_akt  WHERE ID_osoby=@ID ";
              

                try
                {
                    sqlConnection = new SqlConnection(cs.ToString());
                    sqlCommand = new SqlCommand(zap, sqlConnection);
                    sqlCommand.Parameters.Add("@ID", SqlDbType.SmallInt).Value = DGczlon.SelectedIndex+1;
                sqlCommand.Parameters.Add("@Imie", SqlDbType.NVarChar).Value = txtimie.Text;
                sqlCommand.Parameters.Add("@Nazwisko", SqlDbType.NVarChar).Value = txtnazwi.Text;
                sqlCommand.Parameters.Add("@Nr_albumu", SqlDbType.NVarChar).Value = txtnr_alb.Text;
                sqlCommand.Parameters.Add("@Ranga", SqlDbType.NVarChar).Value = cmb_rang.Text;
                sqlCommand.Parameters.Add("@Login", SqlDbType.VarChar).Value = txtlog.Text;
                sqlCommand.Parameters.Add("@Haslo", SqlDbType.VarChar).Value = txthaslo.Text;
                sqlCommand.Parameters.Add("@Data_dol", SqlDbType.DateTime).Value = dzis;
                sqlCommand.Parameters.Add("@Telefon", SqlDbType.NVarChar).Value = txttele.Text;
                sqlCommand.Parameters.Add("@E_mail", SqlDbType.NVarChar).Value = txtmail.Text;
                sqlCommand.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = txtopis.Text;
                sqlCommand.Parameters.Add("@Czy_akt", SqlDbType.Bit).Value = cb_czyakty.IsChecked;

               
                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    odswiez_datagrid();
                    czysc();
                }
                catch (Exception exc)
                {

                    MessageBox.Show(exc.Message,"Błąd") ;
                }
                
            }
        }

        
    }
        }
