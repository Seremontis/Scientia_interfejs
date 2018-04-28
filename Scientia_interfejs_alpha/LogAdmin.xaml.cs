using System;
using System.Collections.Generic;
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
    /// Interaction logic for LogAdmin.xaml
    /// </summary>
    public partial class LogAdmin : Window 
    {
        private string datasource;
        private string catalog;
        SqlConnection con;
        SqlCommand com;
        
        public LogAdmin(string a,string b)
        {
            InitializeComponent();
            datasource = a;
            catalog = b;
        }
        private void Btnzaloguj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtboxlog.Text == "Admin" && txtboxpsw.Password == "patrykszymon")
                {
                    PanelAdmin pane = new PanelAdmin(datasource, catalog);
                    MessageBox.Show("Cześć Admin!", "Zalogowano");
                    pane.ShowDialog();
                    this.Close();
                }
                else
                {
                    SqlConnectionStringBuilder pol = new SqlConnectionStringBuilder();
                    pol.DataSource = datasource;
                    pol.InitialCatalog = catalog;
                    pol.IntegratedSecurity = true;
                    con = new SqlConnection(pol.ConnectionString);
                    SqlParameter login = new SqlParameter("@login", txtboxlog.Text);
                    string zapytanie = "select logg,haslo from Osoby where logg=@login and Ranga='Admin'";
                    com = new SqlCommand(zapytanie, con);
                    com.Parameters.Add(login);
                    con.Open();
                    SqlDataReader red = com.ExecuteReader();
                    if (red.HasRows)
                    {
                        while (red.Read())
                        {
                            if (red.GetValue(0).ToString() == txtboxlog.Text && red.GetValue(1).ToString() == txtboxpsw.Password)
                            {
                                con.Close();
                                PanelAdmin pane = new PanelAdmin(datasource, catalog);
                                MessageBox.Show("Cześć Admin!", "Zalogowano");
                                pane.ShowDialog();
                                this.Close();
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Błędne hasło", "Błąd logowania");
                            }
                        }
                    }
                    else
                        MessageBox.Show("Błędny login");
                    con.Close();
                }
               
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message,"xx");
            }
           
            
        }

        private void btnwroc_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnkontakt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("E-Mail: patryk.wisniewski@edu.uekat.pl", "Kontakt Admin");
        }

        private void txtboxpsw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Enter)
            {
                Btnzaloguj_Click(sender,e);
            }
        }
    }
}
