using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public byte[] key;
        public Form1()
        {
            InitializeComponent();
            this.Text = "File Encrypt/Decrypt by Steven Li";
        }
        

        private void button1_Click(object sender, EventArgs e)                  // Open File
        {
            if(openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        
        private static void EncryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fin.Length;
            int len;

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateEncryptor(desKey, desIV), CryptoStreamMode.Write);

            while(rdlen < totlen)
            {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
            }

            encStream.Close();
            fout.Close();
            fin.Close();
        }

        private void button2_Click(object sender, EventArgs e)          // Encrypt
        {
            string inName = textBox1.Text;
            if(textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(!File.Exists(inName))
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                generateKey();
                string destName = inName + ".des";
                if (File.Exists(destName))
                {
                    DialogResult dResult = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(dResult == DialogResult.No)
                    {
                        return;
                    }
                }
                EncryptData(inName, destName, key, key);
            }

        }


        private static void DecryptData(String inName, String outName, byte[] desKey, byte[] desIV)
        {
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);

            byte[] bin = new byte[100];
            long rdlen = 0;
            long totlen = fin.Length;
            int len;

            DES des = new DESCryptoServiceProvider();
            CryptoStream encStream = new CryptoStream(fout, des.CreateDecryptor(desKey, desIV), CryptoStreamMode.Write);

            try
            {
                while (rdlen < totlen)
                {
                    len = fin.Read(bin, 0, 100);
                    encStream.Write(bin, 0, len);
                    rdlen = rdlen + len;
                }
                encStream.Close();
                fout.Close();
                fin.Close();
            }
            catch
            {
                MessageBox.Show("Bad key or file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fout.Close();
                fin.Close();
                File.Delete(outName);
            }
        }

        private void generateKey()
        {
            int temp;
            key = new byte[8];
            for(int i = 0; i < textBox2.Text.Length; i++)
            {
                temp = i % 8;
                key[temp] = (byte)(key[temp] + (byte)textBox2.Text[i]);
            }
        }

        private void button3_Click(object sender, EventArgs e)          // Decrypt
        {
            string inName = textBox1.Text;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!inName.EndsWith(".des"))
            {
                MessageBox.Show("Not a .des file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!File.Exists(inName))
            {
                MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                generateKey();
                string destName = inName.Substring(0, inName.Length - 3);
                if (File.Exists(destName))
                {
                    DialogResult dResult = MessageBox.Show("Output file exists. Overwrite?", "File Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dResult == DialogResult.No)
                    {
                        return;
                    }
                }
                DecryptData(inName, destName, key, key);
            }
        }
    }

    
}
