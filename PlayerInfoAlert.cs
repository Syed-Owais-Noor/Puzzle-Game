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
    public partial class PlayerInfoAlert : Form
    {
        public PlayerInfoAlert()
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
            ExceptionError ee = new ExceptionError();

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
    }
}
