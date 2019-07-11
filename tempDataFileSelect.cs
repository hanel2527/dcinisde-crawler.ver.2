using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DcCrawler.WF
{
    public partial class tempDataFileSelect : Form
    {
        public string filename;

        public tempDataFileSelect()
        {
            InitializeComponent();
            this.callFileList();
        }
        private void tempDataFileSelect_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void callFileList()
        {
            string tempDataDir = Directory.GetCurrentDirectory() + "\\temp-data";
            var fileArray = Directory.GetFiles(tempDataDir, "*").Select(filename => Path.GetFileName(filename));
            List<string> filenames = new List<string>();
            Regex regex = new Regex(@".+_\d+\-\d+\-\d+_\d+\-\d+\-\d+\.json");
            foreach (string file in fileArray)
            {
                Match match = regex.Match(file);
                if (match.Success)
                {
                    fileSelectListBox.Items.Add(file);
                }
            }
        }
        private void selectBtn_Click(object sender, EventArgs e)
        {
            this.filename = this.fileSelectListBox.GetItemText(fileSelectListBox.SelectedItem);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
