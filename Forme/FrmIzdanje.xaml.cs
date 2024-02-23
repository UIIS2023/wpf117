using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace WPFKnjižara.Forme
{
    /// <summary>
    /// Interaction logic for FrmIzdanje.xaml
    /// </summary>
    public partial class FrmIzdanje : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmIzdanje(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtNazivIzdanja.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();


        }

        public FrmIzdanje()
        {
            InitializeComponent();
            txtNazivIzdanja.Focus();
            konekcija = kon.KreirajKonekciju();



        }

        private void txtbtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };

                cmd.Parameters.Add("@NazivIzdanja", System.Data.SqlDbType.NVarChar).Value = txtNazivIzdanja.Text;

                if(this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblIzdanje set NazivIzdanja=@NazivIzdanja where IzdavanjeID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblIzdanje(NazivIzdanja) values(@NazivIzdanja);";

                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();


            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);

            
            }
            finally
            {
                if(konekcija !=null)
                {
                    konekcija.Close();
                }


            }
           

        }
        private void txtbtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
