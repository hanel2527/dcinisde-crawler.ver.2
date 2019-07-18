using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hdc = DcCrawler;

namespace DcCrawler.WF
{
    public partial class saveFileForm : Form
    {
        hdc.DataToText dtt;
        public saveFileForm(string filename, hdc.DataToText dtt)
        {
            InitializeComponent();
            filenameTextBox.Text = filename;
            this.dtt = dtt;
        }

        private void saveFileForm_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void SaveAsText_Click(object sender, EventArgs e)
        {
            int maximumRank = int.Parse(maximumRankTextBox.Text);
            int minimumCount = int.Parse(minimumCountTextBox.Text);
            dtt.SaveToText(this.filenameTextBox.Text, maximumRank, minimumCount);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            
        }

        private void SaveAsTable_Click(object sender, EventArgs e)
        {
            int maximumRank = int.Parse(maximumRankTextBox.Text);
            int minimumCount = int.Parse(minimumCountTextBox.Text);
            dtt.SaveToTable(this.filenameTextBox.Text, maximumRank, minimumCount);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;

        }

        private void explainLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.explainLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://gall.dcinside.com/board/view/?id=retouching&no=7416");
        }
    }
}
