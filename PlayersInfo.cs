using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using TECForGames.Classes;

namespace TECForGames
{
    public partial class PlayersInfo : UserControl
    {
        SqlConnection con;

        DataBaseConnection cons = new DataBaseConnection();

        ExceptionError ee = new ExceptionError();

        PlayerInfoAlert pIA = new PlayerInfoAlert();

        public PlayersInfo()
        {
            InitializeComponent();
        }

        private void PlayersInfo_Load(object sender, EventArgs e)
        {
            try
            {
                con = cons.Getcon();

                SqlCommand cmd = new SqlCommand("select * from UserGameInfo", con);

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                adp.Fill(dt);

                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button1_MouseHover_1(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 15)
                {
                    SqlDataAdapter adp = new SqlDataAdapter("select * from UserGameInfo where UserName='" + textBox1.Text + "'", con);

                    DataTable dt = new DataTable();

                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UserName"].ToString() == textBox1.Text)
                        {
                            dataGridView1.DataSource = dt;
                        }
                        else
                        {
                            pIA.Show();
                        }
                    }
                    else
                    {
                        pIA.Show();
                    }
                }
                else
                {
                    pIA.Show();
                }
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }
}
