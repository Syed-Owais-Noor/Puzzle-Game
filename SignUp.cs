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
    public partial class SignUp : UserControl
    {
        SqlConnection con;

        ExceptionError ee = new ExceptionError();

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
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

            string userPassword = textBox2.Text;

            string userGmail = textBox4.Text;

            SignUpAlert sUA = new SignUpAlert();

            try
            {
                if (textBox1.Text.Length > 0 && textBox1.Text.Length <= 15 && textBox2.Text.Length > 0 && textBox2.Text.Length <= 8 && textBox3.Text.Length > 0 && textBox3.Text.Length <= 8)
                {
                    if (textBox4.Text.Length > 0 && textBox4.Text.Length <= 25 && textBox2.Text == textBox3.Text && checkBox1.Checked == true)
                    {
                        SiSuAndFpClass sU = new SiSuAndFpClass(userName, userPassword, userGmail);

                        SqlCommand cmd = new SqlCommand("insert into UserGameInfo(UserName,UserPassword,Gmail) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "')", con);

                        SqlDataAdapter adp = new SqlDataAdapter(cmd);

                        DataTable dt = new DataTable();

                        adp.Fill(dt);

                        Load l = new Load();

                        l.Show();
                    }
                    else
                    {
                        sUA.Show();
                    }
                }
                else
                {
                    sUA.Show();
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
