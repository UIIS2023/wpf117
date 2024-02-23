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
using System.Globalization;

namespace WPFKnjižara.Forme
{
    /// <summary>
    /// Interaction logic for FrmKupac.xaml
    /// </summary>
    public partial class FrmKupac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmKupac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtImeKupca.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
        }

        public FrmKupac()
        {
            InitializeComponent();
            txtImeKupca.Focus();
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
                cmd.Parameters.Add("@ImeKupca", SqlDbType.NVarChar).Value = txtImeKupca.Text;
                cmd.Parameters.Add("@PrezimeKupca", SqlDbType.NVarChar).Value = txtPrezimeKupca.Text;
                cmd.Parameters.Add("@AdresaKupca", SqlDbType.NVarChar).Value = txtAdresaKupca.Text;
                cmd.Parameters.Add("@GradKupca", SqlDbType.NVarChar).Value = txtGradKupca.Text;
                cmd.Parameters.Add("@KontaktKupca", SqlDbType.NVarChar).Value = txtKontaktKupca.Text;
                cmd.Parameters.Add("@ClanskaKarta", SqlDbType.Bit).Value = Convert.ToInt32(cbxClanskaKarta.IsChecked, CultureInfo.CurrentCulture);

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblKupac
                                      set ImeKupca=@ImeKupca, PrezimeKupca=@PrezimeKupca,
                                      AdresaKupca=@AdresaKupca, GradKupca=@GradKupca,KontaktKupca=@KontaktKupca,ClanskaKarta=@ClanskaKarta
                                      where KupacID=@id";
                    pomocniRed = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKupac(ImeKupca,PrezimeKupca,AdresaKupca,GradKupca,KontaktKupca,ClanskaKarta)
                                   values(@ImeKupca,@PrezimeKupca,@AdresaKupca,@GradKupca,@KontaktKupca,@ClanskaKarta)";
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
            this.Close();
        }
    }
}
