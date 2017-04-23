using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MixtureSSH
{
    public partial class Form1 : Form
    {
        private List<string> lines = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Text = "...............";
            label3.ForeColor = Color.Black;
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
                                if (line != "") lines.Add(line);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int resultFilesCount = Int32.Parse(textBox2.Text);
                int recycleLinesCount = lines.Count / resultFilesCount;
                StreamWriter writer = null;

                for(int i = 0; i < resultFilesCount; i++)
                {
                    lines = new List<string>(mixLines(lines, recycleLinesCount));
                    string resultFile = Path.GetDirectoryName(textBox1.Text) + "\\" + Path.GetFileNameWithoutExtension(textBox1.Text) + "_" + (i+1) + Path.GetExtension(textBox1.Text);
                    writer = new StreamWriter(resultFile);
                    foreach(string line in lines)
                    {
                        writer.WriteLine(line);
                    }
                    writer.Close();
                }
                label3.Text = "Success.";
                label3.ForeColor = Color.Blue;
            }
            catch (Exception)
            {
                label3.Text = "Fail.";
                label3.ForeColor = Color.Red;
            }
        }

        public List<string> mixLines(List<string> tmpLines, int recycleLinesCount)
        {
            if (recycleLinesCount > tmpLines.Count) return tmpLines;
            for(int i = 0; i < recycleLinesCount; i++)
            {
                string firstLine = tmpLines[0];
                tmpLines.RemoveAt(0);
                tmpLines.Add(firstLine);
            }
            return tmpLines;
        }
    }
}
