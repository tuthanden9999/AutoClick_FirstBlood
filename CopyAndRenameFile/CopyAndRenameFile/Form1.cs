using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CopyAndRenameFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //Stream stream = null;
            try
            {
                string fileName = openFileDialog1.FileName;
                textBox1.Text = fileName;
                //if ((stream = openFileDialog1.OpenFile()) != null)
                //{
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                string filesName = textBox2.Text;
                char[] delimiterChars = { ' ', ',', ';', ':' };
                string[] partFilesNameList = filesName.Split(delimiterChars);
                foreach (string partFilesName in partFilesNameList)
                {
                    //MessageBox.Show(Path.GetDirectoryName(textBox1.Text) + "\\" + partFilesName + Path.GetExtension(textBox1.Text));
                    File.Copy(textBox1.Text, Path.GetDirectoryName(textBox1.Text) + "\\" + partFilesName + Path.GetExtension(textBox1.Text), true);
                }
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Missing file name");
            }
        }
    }
}
