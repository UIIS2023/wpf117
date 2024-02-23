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
    /// Interaction logic for FrmNabavka.xaml
    /// </summary>
    public partial class FrmNabavka : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmNabavka(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            cbKorisnik.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();
            PopuniPadajuceListe();


        }

        public FrmNabavka()
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

                string vartiKorisnika = @"select KorisnikID,PrezimeKorisnika from tblKorisnik";
                DataTable dtKorisnik = new DataTable();
                SqlDataAdapter daKorisnik = new SqlDataAdapter(vartiKorisnika, konekcija);

                daKorisnik.Fill(dtKorisnik);
                cbKorisnik.ItemsSource = dtKorisnik.DefaultView;
                dtKorisnik.Dispose();
                daKorisnik.Dispose();
            }
            catch (SqlException)
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

                DateTime date = (DateTime)dpDatumNabavke.SelectedDate;
                string datum = date.ToString("yyyy-MM-dd");

                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
               
                cmd.Parameters.Add("@KorisnikID", SqlDbType.Int).Value = cbKorisnik.SelectedValue;
                cmd.Parameters.Add("@datumNabavke", SqlDbType.Date).Value = datum;
                cmd.Parameters.Add("@CijenaNabavke", SqlDbType.Money).Value = txtCijenaNabavke.Text;

                if (this.azuriraj)
                {
                    DataRowView red =this. pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblNabavka
                                       set KorisnikID=@KorisnikID, DatumNabavke=@datumNabavke, CijenaNabavke=@CijenaNabavke
                                         where NabavkaID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblNabavka(KorisnikID,DatumNabavke,CijenaNabavke)
                                        values(@KorisnikID,@datumNabavke,@CijenaNabavke)";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Close();
            }
            catch(SqlException)
            {
                MessageBox.Show("Unos odredjenih vrijednosti nije validan", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(InvalidOperationException)
            {
                MessageBox.Show("Odaberite datum!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(FormatException)
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
