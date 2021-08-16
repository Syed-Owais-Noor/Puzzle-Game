using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TECForGames.Classes
{
    class DataBaseConnection
    {
        string db = @"Data Source=DESKTOP-MOAIT5T\SYEDOWAISNOOR;Initial Catalog=DevX;Integrated Security=True";

        SqlConnection con;

        public static int moves;

        ExceptionError ee = new ExceptionError();

        public SqlConnection Getcon()
        {
            try
            {
                con = new SqlConnection(db);

                con.Open();

                return con;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }
}
