using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{

    public partial class Form1 : Form
    {
        public List<Shape> shapeList = new List<Shape>();
        public bool firstClick = true;
        public Point p1, p2;
        public Color penColor, brushColor;
        public bool fill, outline;
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Lab 5 by Steven Li";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            listBox2.SelectedIndex = 0;
            listBox3.SelectedIndex = 0;
            radioButton1.Checked = true;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.White;
            panel1.Width = this.Width;
            panel1.Height = this.Height;
            Graphics g = e.Graphics;
            foreach (Shape shape in this.shapeList)
            {
                shape.Draw_Shape(g);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.shapeList.Clear();
            panel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.shapeList.Count != 0)
            {
                this.shapeList.RemoveAt(shapeList.Count - 1);
                panel1.Invalidate();
            }
                
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.BackColor = Color.LightGray;
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.White, 1);
            g.DrawRectangle(pen, 30, 55, 215, 178);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (firstClick == true)
                {
                    p1 = new Point(e.X, e.Y);
                    firstClick = false;
                }
                else
                {
                    p2 = new Point(e.X, e.Y);
                    firstClick = true;
                    switch(listBox1.SelectedIndex)
                    {
                        case 0: penColor = Color.Black;
                            break; 
                        case 1: penColor = Color.Red;
                            break;
                        case 2: penColor = Color.Blue;
                            break;
                        case 3: penColor = Color.Green;
                            break;
                    }

                    Pen pen1 = new Pen(penColor);

                    switch(listBox2.SelectedIndex)
                    {
                        case 0: brushColor = Color.White;
                            break;
                        case 1: brushColor = Color.Black;
                            break;
                        case 2: brushColor = Color.Red;
                            break;
                        case 3: brushColor = Color.Blue;
                            break;
                        case 4: brushColor = Color.Green;
                            break;
                    }

                    SolidBrush brush1 = new SolidBrush(penColor);
                    SolidBrush brush2 = new SolidBrush(brushColor);

                    switch(listBox3.SelectedIndex)
                    {
                        case 0: pen1.Width = 1;
                            break;
                        case 1: pen1.Width = 2;
                            break;
                        case 2: pen1.Width = 3;
                            break;
                        case 3: pen1.Width = 4;
                            break;
                        case 4: pen1.Width = 5;
                            break;
                        case 5: pen1.Width = 6;
                            break;
                        case 6: pen1.Width = 7;
                            break;
                        case 7: pen1.Width = 8;
                            break;
                        case 8: pen1.Width = 9;
                            break;
                        case 9: pen1.Width = 10;
                            break;

                    }
                    if (this.checkBox1.Checked)
                    {
                        fill = true;
                    }
                    else
                    {
                        fill = false;
                    }
                    if(this.checkBox2.Checked)
                    {
                        outline = true;
                    }
                    else
                    {
                        outline = false;
                    }
                    if (radioButton1.Checked == true)
                    {
                            Shape newLine = new line(pen1, p1, p2);
                            this.shapeList.Add(newLine);
                            panel1.Invalidate();
                    }
                    if (radioButton2.Checked == true)
                    {
                        if(fill || outline)
                        {
                            rectangle newRect = new rectangle(pen1, p1, p2, fill, outline, brush2);
                            this.shapeList.Add(newRect);
                            panel1.Invalidate();
                        }
                    }
                    if (radioButton3.Checked == true)
                    {
                        if(fill || outline)
                        {
                            ellipse newEllipse = new ellipse(pen1, p1, p2, fill, outline, brush2);
                            this.shapeList.Add(newEllipse);
                            panel1.Invalidate();
                        }
                    }
                    if (radioButton4.Checked == true)
                    {
                        string s1 = textBox1.Text;
                        text newText = new text(brush1, p1, p2, s1);
                        this.shapeList.Add(newText);
                        panel1.Invalidate();
                    }

}
            }

        }


    }
}

public class Shape
{
    public virtual void Draw_Shape(Graphics e)
    {

    }
}

public class line : Shape
{
    private Pen pen;
    private Point p1, p2;

    public line(Pen pen1, Point pa, Point pb)
    {
        pen = pen1;
        p1 = pa;
        p2 = pb;
    }

    public override void Draw_Shape(Graphics e)
    {
        e.DrawLine(pen, p1, p2);
    }
}

public class rectangle : Shape
{
    private Pen pen;
    private float x, y, width, height;
    private bool fill, outline;
    private SolidBrush brush;
    public rectangle(Pen pen1, Point p1, Point p2, bool fill1, bool outline1, SolidBrush brush1)
    {
        fill = fill1;
        outline = outline1;
        pen = pen1;
        brush = brush1;
        width = Math.Abs(p2.X - p1.X);
        height = Math.Abs(p2.Y - p1.Y);
        if(p1.X > p2.X)
        {
            x = p2.X;
        }
        else
        {
            x = p1.X;
        }
        if(p1.Y > p2.Y)
        {
            y = p2.Y;
        }
        else
        {
            y = p1.Y;
        }
    }

    public override void Draw_Shape(Graphics e)
    {
        if (outline)
        {
            e.DrawRectangle(pen, x, y, width, height);
            if(fill)
            {
                e.FillRectangle(brush, x+(pen.Width/2), y+ (pen.Width / 2), width- (pen.Width), height- (pen.Width));
            }
        }
        if (fill)
        {
            e.FillRectangle(brush, x, y, width, height);
        }

    }
}

public class ellipse : Shape
{
    private Pen pen;
    private float x, y, width, height;
    private bool fill, outline;
    private SolidBrush brush;

    public ellipse(Pen pen1, Point p1, Point p2, bool fill1, bool outline1, SolidBrush brush1)
    {
        brush = brush1;
        fill = fill1;
        outline = outline1;
        pen = pen1;
        width = Math.Abs(p2.X - p1.X);
        height = Math.Abs(p2.Y - p1.Y);
        if (p1.X > p2.X)
        {
            x = p2.X;
        }
        else
        {
            x = p1.X;
        }
        if (p1.Y > p2.Y)
        {
            y = p2.Y;
        }
        else
        {
            y = p1.Y;
        }
    }
    public override void Draw_Shape(Graphics e)
    {
        if (outline)
        {
            e.DrawEllipse(pen, x, y, width, height);
            if (fill)
            {
                e.FillEllipse(brush, x + (pen.Width / 2), y + (pen.Width / 2), width - (pen.Width), height - (pen.Width));
            }
        }
        if (fill)
        {
            e.FillEllipse(brush, x, y, width, height);
        }
        
    }
}

public class text : Shape
{
    private SolidBrush brush;
    private RectangleF rect;
    private string s;
    private float x, y, width, height;


    public text(SolidBrush brush1, Point p1, Point p2, string s1)
    {
        brush = brush1;
        s = s1;
        width = Math.Abs(p2.X - p1.X);
        height = Math.Abs(p2.Y - p1.Y);
        if (p1.X > p2.X)
        {
            x = p2.X;
        }
        else
        {
            x = p1.X;
        }
        if (p1.Y > p2.Y)
        {
            y = p2.Y;
        }
        else
        {
            y = p1.Y;
        }

        rect = new RectangleF(x, y, width, height);
    }
    public override void Draw_Shape(Graphics e)
    {
        Font font = new Font("Arial", 10);
        e.DrawString(s, font, brush, rect);
    }
}