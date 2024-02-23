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

namespace WPFKnjižara.Forme
{
    /// <summary>
    /// Interaction logic for FrmKorisnik.xaml
    /// </summary>
    public partial class FrmKorisnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKorisnik(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();

        
         }

        public FrmKorisnik()
        {
            InitializeComponent();
            txtImeKorisnika.Focus();
            konekcija= kon.KreirajKonekciju();



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
                cmd.Parameters.Add("@ImeKorisnika", SqlDbType.NVarChar).Value = txtImeKorisnika.Text;
                cmd.Parameters.Add("@PrezimeKorisnika", SqlDbType.NVarChar).Value = txtPrezimeKorisnika.Text;
                cmd.Parameters.Add("@AdresaKorisnika", SqlDbType.NVarChar).Value = txtAdresaKorisnika.Text;
                cmd.Parameters.Add("@GradKorisnika", SqlDbType.NVarChar).Value = txtGradKorisnika.Text;
                cmd.Parameters.Add("@KontaktKorisnika", SqlDbType.NVarChar).Value = txtKontaktKorisnika.Text;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKorisnik
                                      set ImeKorisnika=@ImeKorisnika, PrezimeKorisnika=@PrezimeKorisnika,
                                      AdresaKorisnika=@AdresaKorisnika, GradKorisnika=@GradKorisnika,KontaktKorisnika=@KontaktKorisnika
                                      where KorisnikID=@id";
                    pomocniRed = null;


                }
                else
                {
                    cmd.CommandText = @"insert into tblKorisnik(ImeKorisnika,PrezimeKorisnika,AdresaKorisnika,GradKorisnika,KontaktKorisnika)
                                   values(@ImeKorisnika,@PrezimeKorisnika,@AdresaKorisnika,@GradKorisnika,@KontaktKorisnika);";


                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            }
            finally
            {
                if (konekcija != null)
                {

                    konekcija.Close();
                
                }
            
            }
        }

        private void txtbtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
