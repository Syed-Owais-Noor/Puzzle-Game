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
    public partial class GameMenu : Form
    {
        ExceptionError ee = new ExceptionError();

        public GameMenu()
        {
            InitializeComponent();
        }

        private void GameMenu_Load(object sender, EventArgs e)
        {
            try
            {
                Slidepanel.Height = button2.Height;

                Slidepanel.Top = button2.Top;

                Slidepanel.BringToFront();

                aboutGame1.BringToFront();
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
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Slidepanel.Height = button1.Height;

                Slidepanel.Top = button1.Top;

                Slidepanel.BringToFront();

                level11.BringToFront();
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
                Slidepanel.Height = button2.Height;

                Slidepanel.Top = button2.Top;

                Slidepanel.BringToFront();

                aboutGame1.BringToFront();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Slidepanel.Height = button3.Height;

                Slidepanel.Top = button3.Top;

                Slidepanel.BringToFront();

                playersInfo1.BringToFront();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(128, 128, 255);
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Slidepanel.Height = button4.Height;

                Slidepanel.Top = button4.Top;

                Slidepanel.BringToFront();

                SignOut sO = new SignOut();

                sO.Show();
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }
    }
}
