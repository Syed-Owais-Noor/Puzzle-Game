using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TECForGames.Classes
{
    class Information
    {
        public Information(string search)
        {
            Alert a = new Alert();

            string db = @"Data Source=DESKTOP-A8DMMLS\SYEDOWAISNOOR;Initial Catalog=TECFMGame;Integrated Security=True";

            SqlConnection con = new SqlConnection();

            con = new SqlConnection(db);

            SqlDataAdapter adp = new SqlDataAdapter("select * from UserGameInfo where UserName='" + search + "'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["UserName"].ToString() == search)
                {
                    PlayersInfo pI = new PlayersInfo(search);
                }
                else
                {
                    a.ShowDialog();
                }
            }
            else
            {
                a.ShowDialog();
            }
        }
    }
}
