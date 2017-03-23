using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SplitSSH
{
    public partial class Form1 : Form
    {
        private List<string> lines = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = "...............";
            label4.ForeColor = Color.Black;
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            lines.Clear();
                            StreamReader sr = new StreamReader(myStream);
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                if(line != "") lines.Add(line);
                                //System.Console.WriteLine(line);
                            }
                            sr.Close();
                        }
                        myStream.Close();
                    }
                    textBox1.Text = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int linesCountOfPart = lines.Count / Int32.Parse(textBox2.Text);
                int count = 0;
                int fileCount = 1;
                StreamWriter writer = null;
                for (int i = 0; i < lines.Count; i++)
                {
                    if (writer == null || count > linesCountOfPart)
                    {
                        if (writer != null)
                        {
                            writer.Close();
                            writer = null;
                        }
                        string resultFile = Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + "_" + fileCount + Path.GetExtension(textBox1.Text);
                        writer = new StreamWriter(resultFile);
                        count = 0;
                        fileCount++;
                    }
                    writer.WriteLine(lines[i]);
                    count++;
                }
                if (writer != null) writer.Close();
                label4.Text = "Success.";
                label4.ForeColor = Color.Blue;
            }
            catch (Exception)
            {
                label4.Text = "Fail.";
                label4.ForeColor = Color.Red;
            }
        }
    }
}
