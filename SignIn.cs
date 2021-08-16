using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECForGames.Classes;

namespace TECForGames
{
    public partial class SignIn : UserControl
    {
        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public SignIn()
        {
            InitializeComponent();
        }

        private void SignIn_Load(object sender, EventArgs e)
        {
            try
            {
                DataBaseConnection cons = new DataBaseConnection();

                con = cons.Getcon();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ForgetPassword fP = new ForgetPassword();

                fP.Show();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button2_MouseHover_1(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Black;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string userName = textBox1.Text;

            string userPassword = textBox2.Text;

            SignInAlert sIA = new SignInAlert();

            try
            {
                if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 15 && textBox2.Text.Length > 0 && textBox2.Text.Length <= 8)
                {
                    SiSuAndFpClass sI = new SiSuAndFpClass(userName, userPassword);

                    SqlDataAdapter adp = new SqlDataAdapter("select * from UserGameInfo where UserName='" + textBox1.Text + "' and  UserPassword='" + textBox2.Text + "'", con);

                    DataTable dt = new DataTable();

                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["UserName"].ToString() == textBox1.Text && dt.Rows[0]["UserPassword"].ToString() == textBox2.Text)
                        {
                            Load l = new Load();

                            l.Show();
                        }
                        else
                        {
                            sIA.Show();
                        }
                    }
                    else
                    {
                        sIA.Show();
                    }
                }
                else
                {
                    sIA.Show();
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
