using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using TECForGames.Classes;

namespace TECForGames
{
    public partial class Level5 : Form
    {
        //Button1 represent menu, button2 represent shuffle button, button3 represent pause button,
        //and button4 represent next.

        //Similarly label2 indicate Moves Made and lable3 indicate Time spend.

        int inNullSliceIndex, inmoves = 0, dcmoves = 45;

        List<Bitmap> lstOriginalPictureList = new List<Bitmap>();

        WindowsMediaPlayer wMP = new WindowsMediaPlayer();

        ExceptionError ee = new ExceptionError();

        public Level5()
        {
            InitializeComponent();

            try
            {
                lstOriginalPictureList.AddRange(new Bitmap[] { Properties.Resources.DBZ1, Properties.Resources.DBZ2, Properties.Resources.DBZ3, Properties.Resources.DBZ4, Properties.Resources.DBZ5, Properties.Resources.DBZ6, Properties.Resources.DBZ7, Properties.Resources.DBZ8, Properties.Resources.DBZ9, Properties.Resources.null1 });

                label3.Text += inmoves;

                label2.Text += dcmoves;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void Level5_Load(object sender, EventArgs e)
        {
            try
            {
                Shuffle();

                wMP.URL = @"Music\The_Awakening.mp3";

                wMP.controls.play();
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

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                wMP.controls.stop();

                GameMenu gm = new GameMenu();

                gm.Show();

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
            button2.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Shuffle();

                label2.Text = "Total Moves: 45";

                inmoves = 0;

                dcmoves = 45;

                label3.Text = "Moves: 0";
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
            button3.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (button3.Text == "Pause")
                {
                    gbPuzzleBox.Visible = false;

                    button3.Text = "Resume";

                    wMP.controls.pause();
                }
                else
                {
                    gbPuzzleBox.Visible = true;

                    button3.Text = "Pause";

                    wMP.controls.play();
                }
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        private void Switch5(object sender, EventArgs e)
        {
            int inPictureBoxIndex = gbPuzzleBox.Controls.IndexOf(sender as Control);

            try
            {
                if (inNullSliceIndex != inPictureBoxIndex)
                {
                    List<int> FourBrothers = new List<int>(new int[] { ((inPictureBoxIndex % 3 == 0) ? -1 : inPictureBoxIndex - 1), inPictureBoxIndex - 3, (inPictureBoxIndex % 3 == 2) ? -1 : inPictureBoxIndex + 1, inPictureBoxIndex + 3 });
                    if (FourBrothers.Contains(inNullSliceIndex))
                    {
                        ((PictureBox)gbPuzzleBox.Controls[inNullSliceIndex]).Image = ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image;

                        ((PictureBox)gbPuzzleBox.Controls[inPictureBoxIndex]).Image = lstOriginalPictureList[9];

                        inNullSliceIndex = inPictureBoxIndex;

                        label3.Text = "Moves: " + (++inmoves);

                        label2.Text = "Total Moves: " + (--dcmoves);

                        if (CheckWin())
                        {
                            (gbPuzzleBox.Controls[8] as PictureBox).Image = lstOriginalPictureList[8];

                            DataBaseConnection.moves = inmoves;

                            SaveUserMoves sUM = new Stage5();

                            Complete c = new Complete();

                            c.Show();

                            wMP.controls.stop();
                        }

                        DecrementInMoves();
                    }
                }
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        void Shuffle()
        {
            try
            {
                wMP.controls.stop();

                wMP.controls.play();

                button3.Text = "Pause";

                gbPuzzleBox.Visible = true;

                do
                {
                    int j;

                    List<int> Indexes = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 9 });//8 is not present - since it is the last slice.

                    Random r = new Random();

                    for (int i = 0; i < 9; i++)
                    {
                        Indexes.Remove((j = Indexes[r.Next(0, Indexes.Count)]));

                        ((PictureBox)gbPuzzleBox.Controls[i]).Image = lstOriginalPictureList[j];

                        if (j == 9) inNullSliceIndex = i;//store empty picture box index
                    }

                } while (CheckWin());
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        bool CheckWin()
        {
            try
            {
                int i;

                for (i = 0; i < 8; i++)
                {
                    if ((gbPuzzleBox.Controls[i] as PictureBox).Image != lstOriginalPictureList[i]) break;
                }

                if (i == 8) return true;

                else return false;
            }
            catch (Exception)
            {
                ee.Show();

                throw;
            }
        }

        void DecrementInMoves()
        {
            try
            {
                if (dcmoves == 0)
                {
                    label3.Text = "Moves: 0";

                    label2.Text = "Total Moves: 45";

                    inmoves = 0;

                    dcmoves = 45;

                    Lose lo = new Lose();

                    lo.Show();

                    Shuffle();
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