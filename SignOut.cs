using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TECForGames
{
    public partial class SignOut : Form
    {
        ExceptionError ee = new ExceptionError();

        public SignOut()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Hide();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MainMenu mm = new MainMenu();

                mm.Show();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }
}
