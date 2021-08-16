using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TECForGames.Classes;

namespace TECForGames
{
    public partial class ForgetPassword : Form
    {
        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public ForgetPassword()
        {
            InitializeComponent();
        }

        private void ForgetPassword_Load(object sender, EventArgs e)
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
            string userName = textBox1.Text;

            string userPassword = textBox3.Text;

            string userGmail = textBox5.Text;

            ForgetPasswordAlert fPA = new ForgetPasswordAlert();

            try
            {
                if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 15 && textBox2.Text.Length > 0 && textBox2.Text.Length <= 8 && textBox3.Text.Length > 0 && textBox3.Text.Length <= 8)
                {
                    if (textBox4.Text.Length > 0 && textBox4.Text.Length <= 8 && textBox5.Text.Length > 0 && textBox5.Text.Length <= 25 && textBox3.Text == textBox4.Text)
                    {
                        SqlCommand cmd = new SqlCommand("select * from UserGameInfo", con);

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        adp.Fill(dt);

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["UserPassword"].ToString() == textBox2.Text)
                            {
                                SiSuAndFpClass fP = new SiSuAndFpClass(userName, userPassword, userGmail);

                                cmd = new SqlCommand("update UserGameInfo set UserPassword = '" + textBox3.Text + "' where UserName = '" + userName + "' and Gmail = '" + userGmail + "'", con);

                                adp = new SqlDataAdapter(cmd);

                                dt = new DataTable();

                                adp.Fill(dt);

                                Load l = new Load();

                                l.Show();

                                Hide();
                            }
                            else
                            {
                                fPA.Show();
                            }
                        }
                        else
                        {
                            fPA.Show();
                        }
                    }
                    else
                    {
                        fPA.Show();
                    }
                }
                else
                {
                    fPA.Show();
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
