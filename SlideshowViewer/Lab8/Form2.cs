using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form2 : Form
    {
        public int ind = 0;
        private Bitmap map;
        ListBox.ObjectCollection collectList;

        public Form2()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }
        public Form2(ListBox.ObjectCollection lst, int interval)
        {
            InitializeComponent();
            this.KeyPreview = true;
            timer1.Enabled = true;
            timer1.Interval = interval*1000;
            collectList = lst;

            
        }

        private void Form2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ind++;
            if (ind + 1 > collectList.Count)
            {
                this.Close();
            }
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            string path = collectList[ind].ToString();

            try
            {
                map = new Bitmap(path);
                SizeF size = this.ClientSize;
                float h = size.Height / map.Height;
                float w = size.Width / map.Width;
                float rat = Math.Min(h, w);
                float wR = map.Width * rat;
                float hR = map.Height * rat;
                g.DrawImage(map, (size.Width - wR) / 2f, (size.Height - hR) / 2f, wR, hR);
            }
            catch
            {
                Font newFont = new Font("Arial", 24);
                g.DrawString("Not an image file!", newFont, Brushes.Red, 10, 10);
            }
        }

    }
}
