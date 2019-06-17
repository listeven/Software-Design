using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private int count;
        private int[,] loc = new int[8, 8];

        public Form1()
        {
            InitializeComponent();
            this.Text = "Eight Queens by Steven Li";
            this.ClientSize = new Size(600, 600);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {   
            Graphics g = e.Graphics;
            Font font = new Font("Arial", 30, FontStyle.Bold);
            Color color1, color2;
            Pen pen = new Pen(Color.Black, 2);
            String queenCount = "You have " + count.ToString() + " queens on the board.";
            g.DrawString(queenCount, Font, Brushes.Black, 200, 36);
            for (int i = 0; i < 8; i++)
            {
                if (i % 2 == 0)
                {
                    color1 = Color.White;
                    color2 = Color.Black;
                }
                else
                {
                    color1 = Color.Black;
                    color2 = Color.White;
                }
                SolidBrush brush1 = new SolidBrush(color1);
                SolidBrush brush2 = new SolidBrush(color2);
                
                for (int j = 0; j < 8; j++)
                {
                    g.DrawRectangle(pen, (i * 50) + 100, (j * 50) + 100, 50, 50);
                    if (j % 2 == 0)
                        g.FillRectangle(brush1, (i * 50) + 100, (j * 50) + 100, 50, 50);
                    else
                        g.FillRectangle(brush2, (i * 50) + 100, (j * 50) + 100, 50, 50);
                    if (loc[i,j] == 1)
                    {
                        Rectangle rectangle = new Rectangle((i * 50) + 100, (j * 50) + 100, 50, 50);
                        if (j % 2 == 0)
                        {
                            g.DrawString("Q", font, brush2, rectangle);
                        }
                        else
                        {
                            g.DrawString("Q", font, brush1, rectangle);
                        }
                    }
                }

                for (int k = 0; k < 8; k++)
                {
                    if (this.checkBox1.Checked && (safeCell(i,k) == false))
                    {
                        g.FillRectangle(Brushes.Red, (i * 50) + 100, (k * 50) + 100, 50, 50);
                        if (loc[i, k] == 1)
                        {
                            Rectangle rectangle = new Rectangle((i * 50) + 100, (k * 50) + 100, 50, 50);
                            g.DrawString("Q", font, Brushes.Black, rectangle);
                        }
                        g.DrawRectangle(pen, (i * 50) + 100, (k * 50) + 100, 50, 50);
                    }
                }

            }
        }

        private bool safeCell(int x, int y)
        {
 
            for (int i = 0; i < 8; i++)
            {
                if (loc[i,y] == 1)
                {
                    return false;
                }
            }
            for (int j = 0; j < 8; j++)
            {
                if (loc[x,j] == 1)
                {
                    return false;
                }
            }

            for (int y2 = y, x2 = x; (x2 < 8) && (y2 < 8); y2++, x2++)
            {
                if (loc[x2, y2] == 1)
                {
                    return false;
                }
            }

            for (int y2 = y, x2 = x; (x2 < 8) && (y2 >= 0); y2--, x2++)
            {
                if (loc[x2, y2] == 1)
                {
                    return false;
                }

            }

            for (int y2 = y, x2 = x; (x2 >= 0) && (y2 < 8); y2++, x2--)
            {
                if (loc[x2, y2] == 1)
                {
                    return false;
                }

            }

            for (int y2 = y, x2 = x; (x2 >= 0) && (y2 >= 0); y2--, x2--)
            {
                if (loc[x2, y2] == 1)
                {
                    return false;
                }

            }
            return true;
        }



        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            int y = e.Y;

            if (( (x >= 100) && (y >= 100)) && ((x <= 500) && (y <= 500)) )
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (safeCell( (x - 100) / 50 , (y - 100) / 50) )
                    {
                        loc[(x - 100) / 50, (y - 100) / 50] = 1;
                        count++;
                        this.Invalidate();
                        if (count == 8)
                        {
                            MessageBox.Show("You did it!");
                        }
                    }
                    else
                        System.Media.SystemSounds.Beep.Play();

                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (loc[(x - 100) / 50, (y - 100) / 50] == 1)
                    {
                        loc[(x - 100) / 50, (y - 100) / 50] = 0;
                        count--;
                        this.Invalidate();
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    loc[i, j] = 0;
                }
            }
            this.Invalidate();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
