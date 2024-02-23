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
    /// Interaction logic for FrmRačun.xaml
    /// </summary>
    public partial class FrmRačun : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmRačun(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            cbKorisnik.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();


        }

        public FrmRačun()
        {
            InitializeComponent();
            cbKorisnik.Focus();
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();



        }
        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                string vratiKorisnika = @"select KorisnikID,PrezimeKorisnika from tblKorisnik";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vratiKorisnika, konekcija);

                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();

                string vratiKupca = @"select KupacID,PrezimeKupca from tblKupac";
                DataTable dtKupac = new DataTable();
                SqlDataAdapter daKupac = new SqlDataAdapter(vratiKupca, konekcija);

                daKupac.Fill(dtKupac);
                cbKupac.ItemsSource = dtKupac.DefaultView;
                dtKupac.Dispose();
                daKupac.Dispose();
            }
            catch(SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            finally
            {
                if (konekcija != null)
                {

                    konekcija.Close();

                }

            }

        }

        private void txtbtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
          try
            {
                konekcija = kon.KreirajKonekciju();
                konekcija.Open();

                DateTime date = (DateTime)dpDatumIzdavanja.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@KorisnikID",SqlDbType.Int).Value=cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@KupacID", SqlDbType.Int).Value = cbKupac.SelectedValue;
                cmd.Parameters.Add("@datumIzdavanja", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@CijenaProdaje", SqlDbType.Money).Value = txtCijenaProdaje.Text;

                if (this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblRacun
                                       set KorisnikID=@KorisnikID, KupacID=@KupacID, DatumIzdavanja=@datumIzdavanja, CijenaProdaje=@CijenaProdaje
                                         where RacunID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblRacun(KorisnikID,KupacID,DatumIzdavanja,CijenaProdaje)
                                        values(@KorisnikID,@KupacID,@datumIzdavanja,@CijenaProdaje)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            

            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Greska prilikom konverzije podataka!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                konekcija.Close();
            }
        }

        private void txtbtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
