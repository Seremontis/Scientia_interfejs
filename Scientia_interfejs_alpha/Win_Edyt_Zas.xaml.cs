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
    /// Interaction logic for Win_Edyt_Zas.xaml
    /// </summary>
    public partial class Win_Edyt_Zas : Window
    {

        SqlConnectionStringBuilder cs = new SqlConnectionStringBuilder();
        DataSet ds = new DataSet();
        SqlConnection sqlConnection;
        SqlCommand sqlCommand;
        SqlDataAdapter da;
        public Win_Edyt_Zas()
        {
            InitializeComponent();
            cs.DataSource = "";
            cs.InitialCatalog = "Ewidencja_SI";
            cs.IntegratedSecurity = true;
        }
        /* public class Zasob
         {
             public int Id { get; set; }

             public string Nazwa { get; set; }

             public string Kod { get; set; }

             public string Kategoria { get; set; }

             public string Opis { get; set; }

             public string Stan_techniczny { get; set; }

             public bool Czy_wypozyczalny { get; set; }

             public bool Status_wyp { get; set; }
         }*/
        private void czysc()
        {
            txtnazwa.Text = null;
            txtkod.Text = null;
            txtopis.Text = null;
            txtstan.Text = null;
            cmb_kat.Text = null;
            cb_czywypoz.IsChecked = false;
            btndodaj.IsEnabled = true;
            btnedytuj.IsEnabled = false;
        }
        private void odswiez_datagrid()
        {
            DGzasob.ItemsSource = null;
            sqlConnection = new SqlConnection(cs.ToString());
            string zap = "SELECT * FROM Zasoby";
            da = new SqlDataAdapter(zap, cs.ConnectionString);
            da.FillSchema(ds, SchemaType.Source, "Zasoby");
            da.Fill(ds, "Zasoby");
            DGzasob.ItemsSource = ds.Tables["Zasoby"].DefaultView;
        }
        private void btnczysc_Click(object sender, RoutedEventArgs e)
        {
            czysc();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            odswiez_datagrid();
        }

        private void DGzasob_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Int16 wybrany = Convert.ToInt16(DGzasob.SelectedValue);
            btndodaj.IsEnabled = false;
            btnedytuj.IsEnabled = true;

            if (DGzasob.SelectedIndex != -1)
            {
                foreach (DataRow rw in ds.Tables["Zasoby"].AsEnumerable())
                {
                    if (rw.Field<Int16>("id_zasobu") == wybrany)
                    {
                        txtnazwa.Text = rw.Field<string>("Nazwa");
                        txtkod.Text = rw.Field<string>("Kod");
                        txtopis.Text = rw.Field<string>("Opis");
                        txtstan.Text = rw.Field<string>("Stan_techniczny");
                        cb_czywypoz.IsChecked = rw.Field<Boolean>("Czy_wypozyczalny");
                        cmb_kat.Text = rw.Field<string>("Kategoria");
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
            if (txtnazwa.Text != null)
            {
                try
                {

                    if (txtkod.Text != null)
                    {
                        foreach (var rw in ds.Tables["Zasoby"].AsEnumerable())
                        {
                            if (rw.Field<string>("Kod") == txtkod.Text)
                            {
                                MessageBox.Show("Podany kod już jest zajęty");
                                spr = true;
                                break;
                            }
                        }
                    }
                    if (spr == false && txtnazwa.Text != null && cmb_kat.Text != null && txtstan != null)
                    {
                        sqlConnection = new SqlConnection(cs.ToString());
                        sqlConnection.Open();
                        string zap = "INSERT INTO Zasoby VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
                        sqlCommand = new SqlCommand(zap, sqlConnection);
                        sqlCommand.Parameters.Add("@p1", SqlDbType.NVarChar).Value = txtnazwa.Text;
                        sqlCommand.Parameters.Add("@p2", SqlDbType.NVarChar).Value = txtkod.Text;
                        sqlCommand.Parameters.Add("@p3", SqlDbType.NVarChar).Value = txtopis.Text;
                        sqlCommand.Parameters.Add("@p4", SqlDbType.NVarChar).Value = cmb_kat.Text;
                        sqlCommand.Parameters.Add("@p5", SqlDbType.NVarChar).Value = txtstan.Text;
                        sqlCommand.Parameters.Add("@p6", SqlDbType.Bit).Value = cb_czywypoz.IsChecked;
                        sqlCommand.Parameters.Add("@p7", SqlDbType.Bit).Value = false;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.ExecuteNonQuery();
                        czysc();
                        MessageBox.Show("Dodano zasób", "Sukces");
                        odswiez_datagrid();
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Błąd");
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }



        private void btnedytuj_Click(object sender, RoutedEventArgs e)
        {
            int kontrola = 0;
            bool spr = false;
            if (cb_czywypoz.IsChecked==false)
            {         
            string kontrola_uzytkowany = @"SELECT count(*) FROM Wypozyczenia w,Zasoby z
                                        WHERE w.ID_zasobu=z.ID_zasobu AND z.ID_zasobu=1 AND z.Status_wypozyczenia=1 AND w.aktualne=1";
            try
            {
                sqlCommand = new SqlCommand(kontrola_uzytkowany, sqlConnection);
                sqlConnection.Open();
                kontrola = (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
            finally
            {
            sqlConnection.Close();
            }
            if (kontrola != 0)
            {
                spr = true;
                    MessageBox.Show("Tą opcję można modyfikować tylko gdy sprzęt nie jest wypożyczony");
            }
            }
            if (spr!=true && !(string.IsNullOrEmpty(txtkod.Text)))
            {
                foreach (var rw in ds.Tables["Zasoby"].AsEnumerable())
                {
                    if (rw.Field<string>("Kod") == txtkod.Text && rw.Field<string>("Nazwa") != txtnazwa.Text)
                    {
                        MessageBox.Show("Podany kod już jest zajęty");
                        spr = true;
                        break;
                    }
                }
            }

            if (spr == false && txtnazwa.Text != null && cmb_kat.Text!=null && txtstan!=null)
            {
                string zap = "UPDATE Zasoby SET Nazwa=@Nazwa,Kod=@Kod,Opis=@Opis,Kategoria=@Kategoria,Stan_techniczny=@Stan_techniczny,Czy_wypozyczalny=@Czy_wypozyczalny,Status_wypozyczenia=@Status_wypozyczenia WHERE ID_zasobu=@ID";
                try
                {

                    sqlCommand = new SqlCommand(zap, sqlConnection);


                    sqlCommand.Parameters.Add("@ID", SqlDbType.SmallInt).Value = DGzasob.SelectedValue;
                    sqlCommand.Parameters.Add("@Nazwa", SqlDbType.NVarChar).Value = txtnazwa.Text;
                    sqlCommand.Parameters.Add("@Kod", SqlDbType.NVarChar).Value = txtkod.Text;
                    sqlCommand.Parameters.Add("@Opis", SqlDbType.NVarChar).Value = txtopis.Text;
                    sqlCommand.Parameters.Add("@Kategoria", SqlDbType.NVarChar).Value = cmb_kat.Text;
                    sqlCommand.Parameters.Add("@Stan_techniczny", SqlDbType.NVarChar).Value = txtstan.Text;
                    sqlCommand.Parameters.Add("@Czy_wypozyczalny", SqlDbType.Bit).Value = (cb_czywypoz.IsChecked==true)? 1:0;
                    sqlCommand.Parameters.Add("@Status_wypozyczenia", SqlDbType.Bit).Value = 0;

                    sqlConnection.Open();
                    sqlCommand.ExecuteNonQuery();

                    odswiez_datagrid();
                    MessageBox.Show("Wykonano");
                    czysc();
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Błąd");
                }
                finally
                {
                    sqlConnection.Close();
                }

            }
        }
    }
}

