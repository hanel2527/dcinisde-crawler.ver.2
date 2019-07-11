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
        public static Form1 getform1;
        public Form1 GetThisForm()
        {
            getform1 = this;
            return getform1;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void gallCheckBtn_Click(object sender, EventArgs e)
        {
            hdc.GallchangrankingCrawler tempGcrk = new hdc.GallchangrankingCrawler(1, 2, gallIdTextBox.Text, isMinor.Checked);
            tempGcrk.GallCheck(tempGcrk.gallUrl);
            textConsole.AppendText(tempGcrk.gallName);
        }

        private void NewPageUpdate(object sender, EventArgs e)
        {
            textConsole.AppendText((string)sender + "\r\n");
        }
        private void UserListUpdate(object sender, EventArgs e)
        {
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

            hdc.GallchangrankingCrawler gcrk;
            if (isRangeDate.Checked)
            {
                DateTime modifiedInitDate = new DateTime(initDate.Value.Year, initDate.Value.Month, initDate.Value.Day, 0, 0, 0);
                DateTime modifiedEndDate = new DateTime(endDate.Value.Year, endDate.Value.Month, endDate.Value.Day, 23, 59, 59);
                 gcrk = new hdc.GallchangrankingCrawler(
                    modifiedInitDate, modifiedEndDate, gallIdTextBox.Text, isMinor.Checked, int.Parse(initPageText.Text));
            }
            else
            {
                gcrk = new hdc.GallchangrankingCrawler(
                    int.Parse(initPageText.Text), int.Parse(endPageText.Text), gallIdTextBox.Text, isMinor.Checked);
            }
            textConsole.AppendText("갤창랭킹\r\n");
            gcrk.newPageHappened += NewPageUpdate;
            gcrk.CrawlingEnded += UserListUpdate;
            gcrk.Crawler();
        }

        hdc.DataToText dtt;
        private void callFileListBtn_Click(object sender, EventArgs e)
        {
            string filename = "";
            tempDataFileSelect tdfs = new tempDataFileSelect();
            if(tdfs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = tdfs.filename;
            }

            dtt = new hdc.DataToText(filename);
            this.UpdateUserListView();
            string newFilename = "";
            for (int i = 0; i < dtt.filename.Split('.').Count() - 1; i++)
            {
                newFilename += dtt.filename.Split('.')[i] + ".";
            }
            newFilename += "result.txt";
            fileNameTextBox.Text = newFilename;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = fileNameTextBox.Text;
            dtt.SaveToText(filename);
            programStatusLabel.Text = "저장 완료";
        }
    }
}
