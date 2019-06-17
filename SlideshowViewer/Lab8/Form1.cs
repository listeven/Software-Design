using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Slide Show Viewer by Steven Li";
        }

        private void button1_Click(object sender, EventArgs e)          // ADD
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                //textBox1.Text = openFileDialog1.FileName;
                foreach (string file in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)          // DELETE
        {
            for (int i = listBox1.SelectedIndices.Count - 1 ; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)          // SHOW
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No images to show.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    int interval = int.Parse(textBox1.Text);
                    if(interval >= 1)
                    {
                        Form2 frm = new Form2(listBox1.Items, interval);
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please enter an integer time interval > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Please enter an integer time interval > 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }



        private void openCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog(this) == DialogResult.OK)
            {
                StreamReader open = new StreamReader(openFileDialog2.OpenFile());
                string file;
                listBox1.Items.Clear();
                while((file = open.ReadLine()) != null)
                {
                    listBox1.Items.Add(file);
                }
                open.Close();
            }
        }

        private void saveCollectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
            {
                MessageBox.Show("No file names to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter save = new StreamWriter(saveFileDialog1.OpenFile());
                foreach (object file in listBox1.Items)
                {
                    save.WriteLine(file.ToString());
                }
                save.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
