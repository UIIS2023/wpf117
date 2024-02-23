using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPFKnjižara
{
    class Konekcija
    {
        public SqlConnection KreirajKonekciju()
        {

            SqlConnectionStringBuilder ccnSb =
                new SqlConnectionStringBuilder
                {
                    DataSource = @"DESKTOP-GP876LR\SQLEXPRESS",
                    InitialCatalog = "Knjizara",
                    IntegratedSecurity = true,


                };

            string con = ccnSb.ToString();
            SqlConnection konekcija = new SqlConnection(con);
            return konekcija;
        }

    }
}







