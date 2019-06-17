using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        //dimensions
        private const float clientSize = 100;
        private const float lineLength = 80;
        private const float block = lineLength / 3;
        private const float offset = 10;
        private const float delta = 5;

        private float scale; //current scale factor
        bool Game_Over = false;

        public Form1()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        GameEng game = new GameEng();

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            ApplyTransform(g);
            //draw board
            g.DrawLine(Pens.Black, block, 0, block, lineLength);
            g.DrawLine(Pens.Black, 2 * block, 0, 2 * block, lineLength);
            g.DrawLine(Pens.Black, 0, block, lineLength, block);
            g.DrawLine(Pens.Black, 0, 2 * block, lineLength, 2 * block);

            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < 3; ++j)
                    if (game.grid[i, j] == GameEng.CellSelection.O)
                        DrawO(i, j, g);
                    else if (game.grid[i, j] == GameEng.CellSelection.X)
                        DrawX(i, j, g);
            if (game.Game_Tie == true && Game_Over == false)
            {
                Game_Over = true;
                MessageBox.Show("Tie Game!", "Game Result");
            }
            if (game.User_Win == true && Game_Over == false)
            {
                Game_Over = true;
                MessageBox.Show("You win!", "Game Result");
            }
            if (game.Comp_Win == true && Game_Over == false)
            {
                Game_Over = true;
                MessageBox.Show("You lose!", "Game Result");
            }

        }
        private void ApplyTransform(Graphics g)
        {
            scale = Math.Min(ClientRectangle.Width / clientSize, ClientRectangle.Height / clientSize);
            if (scale == 0f) return;
            g.ScaleTransform(scale, scale);
            g.TranslateTransform(offset, offset);
        }
        private void DrawX(int i, int j, Graphics g)
        {
            g.DrawLine(Pens.Black, i * block + delta, j * block + delta, (i * block) + block - delta, (j * block) + block - delta);
            g.DrawLine(Pens.Black, (i * block) + block - delta, j * block + delta, (i * block) + delta, (j * block) + block - delta);
        }
        private void DrawO(int i, int j, Graphics g)
        {
            g.DrawEllipse(Pens.Black, i * block + delta, j * block + delta, block - 2 * delta, block - 2 * delta);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Graphics g = CreateGraphics();
            ApplyTransform(g);
            PointF[] p = { new Point(e.X, e.Y) };
            g.TransformPoints(CoordinateSpace.World, CoordinateSpace.Device, p);
            if (p[0].X < 0 || p[0].Y < 0)
                return;
            int i = (int)(p[0].X / block);
            int j = (int)(p[0].Y / block);
            if (i > 2 || j > 2)
                return;
            if (e.Button == MouseButtons.Left)
                game.User_Move(i, j);
            computerStartsToolStripMenuItem.Enabled = false;
            Invalidate();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new GameEng();
            Game_Over = false;
            computerStartsToolStripMenuItem.Enabled = true;
            Invalidate();
        }

        private void computerStartsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.Comp_First = true;
            game.Comp_Turn();
            computerStartsToolStripMenuItem.Enabled = false;
            Invalidate();
        }
    }
}
