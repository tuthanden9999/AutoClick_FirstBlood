using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoClick_FirstBlood
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1.Instance.Enabled = true;
        }
    }
}
