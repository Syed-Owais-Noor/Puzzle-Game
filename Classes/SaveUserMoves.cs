using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TECForGames.Classes
{
    class SaveUserMoves : SiSuAndFpClass
    { }

    class Stage1 : SaveUserMoves
    {

        DataBaseConnection cons = new DataBaseConnection();

        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public Stage1()
        {
            Save();
        }

        public void Save()
        {
            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("update UserGameInfo set Level1 = '" + DataBaseConnection.moves.ToString() + "' where UserName = '" + name + "' and UserPassword = '" + password + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }

    class Stage2 : SaveUserMoves
    {
        DataBaseConnection cons = new DataBaseConnection();

        SqlConnection con;

        ExceptionError ee = new ExceptionError();
     
        public Stage2()
        {
            Save();
        }

        public void Save()
        {
            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("update UserGameInfo set Level2 = '" + DataBaseConnection.moves.ToString() + "' where UserName = '" + name + "' and UserPassword = '" + password + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);
            }
            catch (Exception)
            {

                ee.Show();

                throw;
            }
        }
    }

    class Stage3 : SaveUserMoves
    {
        DataBaseConnection cons = new DataBaseConnection();

        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public Stage3()
        {
            Save();
        }

        public void Save()
        {

            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("update UserGameInfo set Level3 = '" + DataBaseConnection.moves.ToString() + "' where UserName = '" + name + "' and UserPassword = '" + password + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);
            }
            catch (Exception)
            {

                ee.Show();

                throw;
            }
        }
    }

    class Stage4 : SaveUserMoves
    {
        DataBaseConnection cons = new DataBaseConnection();

        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public Stage4()
        {
            Save();
        }

        public void Save()
        {
            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("update UserGameInfo set Level4 = '" + DataBaseConnection.moves.ToString() + "' where UserName = '" + name + "' and UserPassword = '" + password + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }

    class Stage5 : SaveUserMoves
    {
        DataBaseConnection cons = new DataBaseConnection();

        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public Stage5()
        {
            Save();
        }

        public void Save()
        {
            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("update UserGameInfo set Level5 = '" + DataBaseConnection.moves.ToString() + "' where UserName = '" + name + "' and UserPassword = '" + password + "'", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);
            }
            catch (Exception)
            {

                ee.Show();

                throw;
            }
        }
    }
}
