using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
    public partial class Form1 : Form
    {
        public string version = "v2.0.9.3";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.updateLinkLabel.Text = "현재 버전: " + version;
            hdc.GallchangrankingCrawler tempGcrk = new GallchangrankingCrawler();
            try
            {
                tempGcrk.NewVersionUpdateExist += UpdateUpdateLinkLabel;
                tempGcrk.UpdateChecker(this.version);
            }
            catch
            {
                updateLinkLabel.Text = "현재 버전: " + version + ", 업데이트를 확인할 수 없습니다";
            }

        }
        private void UpdateUpdateLinkLabel(object text, EventArgs e)
        {
            updateLinkLabel.Text = (string)text;
        }
        private void gallCheckBtn_Click(object sender, EventArgs e)
        {
            hdc.GallchangrankingCrawler tempGcrk = new hdc.GallchangrankingCrawler(1, 2, gallIdTextBox.Text, isMinor.Checked);
            tempGcrk.GallCheck(tempGcrk.gallUrl);
            textConsole.AppendText(tempGcrk.gallName);
        }

        private void NewPageUpdate(object sender, EventArgs e)
        {
            System.Collections.ArrayList arr = (System.Collections.ArrayList)sender;
            if((int)arr[2] % 1000 == 0)
            {
                textConsole.Clear();
            }
            textConsole.AppendText((string)arr[0] + "\r\n");

            if (isRangeDate.Checked)
            {
                TimeSpan timeSpan = endDate.Value - (DateTime)arr[1];
                if(timeSpan.Days < 0)
                {
                    pageProgressBar.Value = 0;
                }
                else
                {
                    pageProgressBar.Value = timeSpan.Days;
                } 
            }
            else
            {
                pageProgressBar.Value = (int)arr[2];
            }
        }
        private void UserListUpdate(object sender, EventArgs e)
        {
            pageProgressBar.Value = pageProgressBar.Maximum;
            string str =
                "################################\r\n" +
                "갤창랭킹 완료!\r\n" +
                "################################\r\n";
            textConsole.AppendText(str);
            List<hdc.UserRank> userList = (List<hdc.UserRank>)sender;
            foreach(hdc.UserRank user in userList)
            {
                textConsole.AppendText(user.ToString() + ": " + user.count.ToString() + "\r\n");
            }
        }

        private void gcrkStart_Click(object sender, EventArgs e)
        {
            textConsole.AppendText("\r\n갤창랭킹 시작\r\n");
            pageProgressBar.Visible = true;
            hdc.GallchangrankingCrawler gcrk;
            if (isRangeDate.Checked)
            {
                TimeSpan timeSpan = endDate.Value - initDate.Value;
                pageProgressBar.Maximum = timeSpan.Days;
                pageProgressBar.Step = 1;
                DateTime modifiedInitDate = new DateTime(initDate.Value.Year, initDate.Value.Month, initDate.Value.Day, 0, 0, 0);
                DateTime modifiedEndDate = new DateTime(endDate.Value.Year, endDate.Value.Month, endDate.Value.Day, 23, 59, 59);
                 gcrk = new hdc.GallchangrankingCrawler(
                    modifiedInitDate, modifiedEndDate, gallIdTextBox.Text, isMinor.Checked, int.Parse(initPageText.Text));
            }
            else
            {
                pageProgressBar.Maximum = int.Parse(endPageText.Text) - int.Parse(initPageText.Text) + 1;
                pageProgressBar.Step = 1;
                gcrk = new hdc.GallchangrankingCrawler(
                    int.Parse(initPageText.Text), int.Parse(endPageText.Text), gallIdTextBox.Text, isMinor.Checked);
            }
            textConsole.AppendText("갤창랭킹\r\n");
            gcrk.newPageHappened += NewPageUpdate;
            gcrk.CrawlingEnded += UserListUpdate;
            gcrk.ErrorOccured += ErrorMessage;
            gcrk.Crawler();
        }
        private void ErrorMessage(object sender, EventArgs e)
        {
            textConsole.AppendText((string)sender);
        }
        string filename = "";
        hdc.DataToText dtt;
        private void callFileListBtn_Click(object sender, EventArgs e)
        {
            tempDataFileSelect tdfs = new tempDataFileSelect();
            if(tdfs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = tdfs.filename;
            }

            dtt = new hdc.DataToText(filename);
            this.UpdateUserListView();
        }
        private void UpdateUserListView()
        {
            userListView.Items.Clear();
            int i = 0;
            string strss = dtt.userList[0].ToString();
            foreach (hdc.UserRank user in dtt.userList)
            {
                i++;
                string[] arr = {i.ToString() + "위 ", user.count.ToString() + "글",
                    user.ToString() };
                ListViewItem item = new ListViewItem(arr);
                userListView.Items.Add(item);
            }
            userListView.Refresh();
        }
        private void autoManagerBtn_Click(object sender, EventArgs e)
        {
            dtt.AutoUserManager();
            this.UpdateUserListView();
        }
        private void serachBtn_Click(object sender, EventArgs e)
        {
            string str = searchTextBox.Text;
            foreach(ListViewItem user in userListView.Items)
            {
                if (user.SubItems[2].Text.Contains(str))
                {
                    user.Checked = true;
                }
            }
            userListView.Refresh();
        }

        private void userMergeBtn_Click(object sender, EventArgs e)
        {
            List<int> sameUsers = new List<int>();
            foreach (ListViewItem user in userListView.Items)
            {
                if(user.Checked)
                    sameUsers.Add(user.Index);
            }
            userListView.Items.Clear();
            dtt.MultiUserMerge(sameUsers.ToArray());
            dtt.RankingUpdate();
            this.UpdateUserListView();
        }

        private void cancelAllCheck_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem user in userListView.Items)
            {
                user.Checked = false;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://gall.dcinside.com/board/view/?id=retouching&no=7413");
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel2.LinkVisited = true;
            System.Diagnostics.Process.Start("https://gall.dcinside.com/board/lists?id=retouching");
        }

        private void updateLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.updateLinkLabel.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/hanel2527/dcinisde-crawler.ver.2/releases/latest");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string gallId = filename.Split('_')[0];
            string newFilename = gallId + DateTime.Now.ToString("_yyyy-MM-dd_HH-mm-ss") + ".result.txt";
            saveFileForm sff = new saveFileForm(newFilename, dtt);
            sff.ShowDialog();
        }
    }
}
