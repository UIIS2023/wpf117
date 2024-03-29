﻿using System;
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
using System.Runtime.InteropServices;

namespace WPFKnjižara.Forme
{
    /// <summary>
    /// Interaction logic for FrmPisac.xaml
    /// </summary>
    public partial class FrmPisac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        bool azuriraj;
        DataRowView pomocniRed;

        public FrmPisac(bool azuriraj, DataRowView pomocniRed)
        {
            InitializeComponent();
            txtPisacIme.Focus();
            this.azuriraj = azuriraj;
            this.pomocniRed = pomocniRed;
            konekcija = kon.KreirajKonekciju();


        }

        public FrmPisac()
        {
            InitializeComponent();
            txtPisacIme.Focus();
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
                cmd.Parameters.Add("@ImePisca", SqlDbType.NVarChar).Value = txtPisacIme.Text;
                cmd.Parameters.Add("@PrezimePisca", SqlDbType.NVarChar).Value = txtPisacPrezime.Text;

                if(this.azuriraj)
                {
                    DataRowView red = this.pomocniRed;
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                    cmd.CommandText = @"update tblPisac
                                     set ImePisca=@ImePisca, PrezimePisca=@PrezimePisca where PisacID=@id";
                    pomocniRed = null;

                }
                else
                {
                    cmd.CommandText = @"insert into tblPisac(ImePisca,PrezimePisca) 
                                           values(@ImePisca,@PrezimePisca);";

                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();

            }
            catch(SqlException)
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
