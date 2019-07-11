namespace DcCrawler.WF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataToText = new System.Windows.Forms.TabPage();
            this.autoManagerBtn = new System.Windows.Forms.Button();
            this.serachBtn = new System.Windows.Forms.Button();
            this.userMergeBtn = new System.Windows.Forms.Button();
            this.callFileListBtn = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.userListView = new System.Windows.Forms.ListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.user = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cancelAllCheck = new System.Windows.Forms.Button();
            this.saveToFileBtn = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.programStatusLabel = new System.Windows.Forms.Label();
            this.gcrkCrawler = new System.Windows.Forms.TabPage();
            this.pageProgressBar = new System.Windows.Forms.ProgressBar();
            this.isMinor = new System.Windows.Forms.CheckBox();
            this.gallIdTextBox = new System.Windows.Forms.TextBox();
            this.gallCheckBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gcrkStart = new System.Windows.Forms.Button();
            this.isRangeDate = new System.Windows.Forms.CheckBox();
            this.initDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textConsole = new System.Windows.Forms.TextBox();
            this.initPageText = new System.Windows.Forms.TextBox();
            this.endPageText = new System.Windows.Forms.TextBox();
            this.tabPages = new System.Windows.Forms.TabControl();
            this.dataToText.SuspendLayout();
            this.gcrkCrawler.SuspendLayout();
            this.tabPages.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataToText
            // 
            this.dataToText.Controls.Add(this.programStatusLabel);
            this.dataToText.Controls.Add(this.fileNameTextBox);
            this.dataToText.Controls.Add(this.saveToFileBtn);
            this.dataToText.Controls.Add(this.cancelAllCheck);
            this.dataToText.Controls.Add(this.userListView);
            this.dataToText.Controls.Add(this.searchTextBox);
            this.dataToText.Controls.Add(this.callFileListBtn);
            this.dataToText.Controls.Add(this.userMergeBtn);
            this.dataToText.Controls.Add(this.serachBtn);
            this.dataToText.Controls.Add(this.autoManagerBtn);
            this.dataToText.Location = new System.Drawing.Point(4, 25);
            this.dataToText.Name = "dataToText";
            this.dataToText.Padding = new System.Windows.Forms.Padding(3);
            this.dataToText.Size = new System.Drawing.Size(790, 477);
            this.dataToText.TabIndex = 1;
            this.dataToText.Text = "동일닉 처리 및 텍스트 파일로 저장";
            this.dataToText.UseVisualStyleBackColor = true;
            // 
            // autoManagerBtn
            // 
            this.autoManagerBtn.Location = new System.Drawing.Point(701, 9);
            this.autoManagerBtn.Name = "autoManagerBtn";
            this.autoManagerBtn.Size = new System.Drawing.Size(82, 99);
            this.autoManagerBtn.TabIndex = 3;
            this.autoManagerBtn.Text = "동일 갤러 자동 처리";
            this.autoManagerBtn.UseVisualStyleBackColor = true;
            this.autoManagerBtn.Click += new System.EventHandler(this.autoManagerBtn_Click);
            // 
            // serachBtn
            // 
            this.serachBtn.Location = new System.Drawing.Point(708, 158);
            this.serachBtn.Name = "serachBtn";
            this.serachBtn.Size = new System.Drawing.Size(75, 42);
            this.serachBtn.TabIndex = 4;
            this.serachBtn.Text = "검색";
            this.serachBtn.UseVisualStyleBackColor = true;
            this.serachBtn.Click += new System.EventHandler(this.serachBtn_Click);
            // 
            // userMergeBtn
            // 
            this.userMergeBtn.Location = new System.Drawing.Point(701, 277);
            this.userMergeBtn.Name = "userMergeBtn";
            this.userMergeBtn.Size = new System.Drawing.Size(82, 72);
            this.userMergeBtn.TabIndex = 5;
            this.userMergeBtn.Text = "동일 갤러 합치기";
            this.userMergeBtn.UseVisualStyleBackColor = true;
            this.userMergeBtn.Click += new System.EventHandler(this.userMergeBtn_Click);
            // 
            // callFileListBtn
            // 
            this.callFileListBtn.Location = new System.Drawing.Point(7, 6);
            this.callFileListBtn.Name = "callFileListBtn";
            this.callFileListBtn.Size = new System.Drawing.Size(51, 107);
            this.callFileListBtn.TabIndex = 6;
            this.callFileListBtn.Text = "데이터   목록 불러오기";
            this.callFileListBtn.UseVisualStyleBackColor = true;
            this.callFileListBtn.Click += new System.EventHandler(this.callFileListBtn_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(663, 127);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(120, 25);
            this.searchTextBox.TabIndex = 7;
            // 
            // userListView
            // 
            this.userListView.CheckBoxes = true;
            this.userListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.count,
            this.user});
            this.userListView.FullRowSelect = true;
            this.userListView.Location = new System.Drawing.Point(64, 3);
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(593, 454);
            this.userListView.TabIndex = 8;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Tag = "랭킹";
            this.index.Text = "랭킹";
            this.index.Width = 70;
            // 
            // count
            // 
            this.count.Tag = "글 수";
            this.count.Text = "글 수";
            this.count.Width = 79;
            // 
            // user
            // 
            this.user.Tag = "갤러";
            this.user.Text = "갤러";
            this.user.Width = 432;
            // 
            // cancelAllCheck
            // 
            this.cancelAllCheck.Location = new System.Drawing.Point(701, 216);
            this.cancelAllCheck.Name = "cancelAllCheck";
            this.cancelAllCheck.Size = new System.Drawing.Size(82, 55);
            this.cancelAllCheck.TabIndex = 9;
            this.cancelAllCheck.Text = "모두 선택해제";
            this.cancelAllCheck.UseVisualStyleBackColor = true;
            this.cancelAllCheck.Click += new System.EventHandler(this.cancelAllCheck_Click);
            // 
            // saveToFileBtn
            // 
            this.saveToFileBtn.Location = new System.Drawing.Point(672, 438);
            this.saveToFileBtn.Name = "saveToFileBtn";
            this.saveToFileBtn.Size = new System.Drawing.Size(111, 33);
            this.saveToFileBtn.TabIndex = 10;
            this.saveToFileBtn.Text = "파일로 저장";
            this.saveToFileBtn.UseVisualStyleBackColor = true;
            this.saveToFileBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(664, 379);
            this.fileNameTextBox.Multiline = true;
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(119, 53);
            this.fileNameTextBox.TabIndex = 11;
            this.fileNameTextBox.Text = "result.txt";
            // 
            // programStatusLabel
            // 
            this.programStatusLabel.AutoSize = true;
            this.programStatusLabel.Location = new System.Drawing.Point(660, 361);
            this.programStatusLabel.Name = "programStatusLabel";
            this.programStatusLabel.Size = new System.Drawing.Size(87, 15);
            this.programStatusLabel.TabIndex = 12;
            this.programStatusLabel.Text = "저장 파일명";
            // 
            // gcrkCrawler
            // 
            this.gcrkCrawler.Controls.Add(this.endPageText);
            this.gcrkCrawler.Controls.Add(this.initPageText);
            this.gcrkCrawler.Controls.Add(this.textConsole);
            this.gcrkCrawler.Controls.Add(this.gallIdTextBox);
            this.gcrkCrawler.Controls.Add(this.label9);
            this.gcrkCrawler.Controls.Add(this.label8);
            this.gcrkCrawler.Controls.Add(this.label7);
            this.gcrkCrawler.Controls.Add(this.label6);
            this.gcrkCrawler.Controls.Add(this.label5);
            this.gcrkCrawler.Controls.Add(this.endDate);
            this.gcrkCrawler.Controls.Add(this.initDate);
            this.gcrkCrawler.Controls.Add(this.isRangeDate);
            this.gcrkCrawler.Controls.Add(this.gcrkStart);
            this.gcrkCrawler.Controls.Add(this.label4);
            this.gcrkCrawler.Controls.Add(this.label3);
            this.gcrkCrawler.Controls.Add(this.label2);
            this.gcrkCrawler.Controls.Add(this.label1);
            this.gcrkCrawler.Controls.Add(this.gallCheckBtn);
            this.gcrkCrawler.Controls.Add(this.isMinor);
            this.gcrkCrawler.Controls.Add(this.pageProgressBar);
            this.gcrkCrawler.Location = new System.Drawing.Point(4, 25);
            this.gcrkCrawler.Name = "gcrkCrawler";
            this.gcrkCrawler.Padding = new System.Windows.Forms.Padding(3);
            this.gcrkCrawler.Size = new System.Drawing.Size(790, 477);
            this.gcrkCrawler.TabIndex = 0;
            this.gcrkCrawler.Text = "갤창랭킹";
            this.gcrkCrawler.UseVisualStyleBackColor = true;
            // 
            // pageProgressBar
            // 
            this.pageProgressBar.Location = new System.Drawing.Point(161, 298);
            this.pageProgressBar.Name = "pageProgressBar";
            this.pageProgressBar.Size = new System.Drawing.Size(123, 23);
            this.pageProgressBar.TabIndex = 0;
            // 
            // isMinor
            // 
            this.isMinor.AutoSize = true;
            this.isMinor.Location = new System.Drawing.Point(7, 35);
            this.isMinor.Name = "isMinor";
            this.isMinor.Size = new System.Drawing.Size(124, 19);
            this.isMinor.TabIndex = 1;
            this.isMinor.Text = "마이너 갤러리";
            this.isMinor.UseVisualStyleBackColor = true;
            // 
            // gallIdTextBox
            // 
            this.gallIdTextBox.Location = new System.Drawing.Point(8, 61);
            this.gallIdTextBox.Name = "gallIdTextBox";
            this.gallIdTextBox.Size = new System.Drawing.Size(136, 25);
            this.gallIdTextBox.TabIndex = 2;
            // 
            // gallCheckBtn
            // 
            this.gallCheckBtn.Location = new System.Drawing.Point(161, 61);
            this.gallCheckBtn.Name = "gallCheckBtn";
            this.gallCheckBtn.Size = new System.Drawing.Size(91, 28);
            this.gallCheckBtn.TabIndex = 3;
            this.gallCheckBtn.Text = "갤 ID 확인";
            this.gallCheckBtn.UseVisualStyleBackColor = true;
            this.gallCheckBtn.Click += new System.EventHandler(this.gallCheckBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 15);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 15);
            this.label4.TabIndex = 9;
            // 
            // gcrkStart
            // 
            this.gcrkStart.Location = new System.Drawing.Point(8, 298);
            this.gcrkStart.Name = "gcrkStart";
            this.gcrkStart.Size = new System.Drawing.Size(114, 39);
            this.gcrkStart.TabIndex = 12;
            this.gcrkStart.Text = "갤창랭킹 시작";
            this.gcrkStart.UseVisualStyleBackColor = true;
            this.gcrkStart.Click += new System.EventHandler(this.gcrkStart_Click);
            // 
            // isRangeDate
            // 
            this.isRangeDate.AutoSize = true;
            this.isRangeDate.Checked = true;
            this.isRangeDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isRangeDate.Location = new System.Drawing.Point(10, 181);
            this.isRangeDate.Name = "isRangeDate";
            this.isRangeDate.Size = new System.Drawing.Size(336, 19);
            this.isRangeDate.TabIndex = 13;
            this.isRangeDate.Text = "범위를 날짜 기준으로(시작 페이지 입력 필수)";
            this.isRangeDate.UseVisualStyleBackColor = true;
            // 
            // initDate
            // 
            this.initDate.Location = new System.Drawing.Point(161, 220);
            this.initDate.Name = "initDate";
            this.initDate.Size = new System.Drawing.Size(200, 25);
            this.initDate.TabIndex = 14;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(161, 259);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(200, 25);
            this.endDate.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(251, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "갤창랭킹.ver.2.0 made by hanel2527";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "시작 페이지(필수)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "끝 페이지";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 19;
            this.label8.Text = "시작 날짜";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "끝 날짜";
            // 
            // textConsole
            // 
            this.textConsole.Location = new System.Drawing.Point(387, 35);
            this.textConsole.Multiline = true;
            this.textConsole.Name = "textConsole";
            this.textConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textConsole.Size = new System.Drawing.Size(397, 436);
            this.textConsole.TabIndex = 21;
            // 
            // initPageText
            // 
            this.initPageText.Location = new System.Drawing.Point(161, 95);
            this.initPageText.Name = "initPageText";
            this.initPageText.Size = new System.Drawing.Size(100, 25);
            this.initPageText.TabIndex = 22;
            this.initPageText.Text = "1";
            // 
            // endPageText
            // 
            this.endPageText.Location = new System.Drawing.Point(161, 138);
            this.endPageText.Name = "endPageText";
            this.endPageText.Size = new System.Drawing.Size(100, 25);
            this.endPageText.TabIndex = 23;
            // 
            // tabPages
            // 
            this.tabPages.Controls.Add(this.gcrkCrawler);
            this.tabPages.Controls.Add(this.dataToText);
            this.tabPages.Location = new System.Drawing.Point(1, 1);
            this.tabPages.Name = "tabPages";
            this.tabPages.SelectedIndex = 0;
            this.tabPages.Size = new System.Drawing.Size(798, 506);
            this.tabPages.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 501);
            this.Controls.Add(this.tabPages);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.dataToText.ResumeLayout(false);
            this.dataToText.PerformLayout();
            this.gcrkCrawler.ResumeLayout(false);
            this.gcrkCrawler.PerformLayout();
            this.tabPages.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage dataToText;
        private System.Windows.Forms.Label programStatusLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button saveToFileBtn;
        private System.Windows.Forms.Button cancelAllCheck;
        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.ColumnHeader count;
        private System.Windows.Forms.ColumnHeader user;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button callFileListBtn;
        private System.Windows.Forms.Button userMergeBtn;
        private System.Windows.Forms.Button serachBtn;
        private System.Windows.Forms.Button autoManagerBtn;
        private System.Windows.Forms.TabPage gcrkCrawler;
        private System.Windows.Forms.TextBox endPageText;
        private System.Windows.Forms.TextBox initPageText;
        private System.Windows.Forms.TextBox textConsole;
        private System.Windows.Forms.TextBox gallIdTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker initDate;
        private System.Windows.Forms.CheckBox isRangeDate;
        private System.Windows.Forms.Button gcrkStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button gallCheckBtn;
        private System.Windows.Forms.CheckBox isMinor;
        private System.Windows.Forms.ProgressBar pageProgressBar;
        private System.Windows.Forms.TabControl tabPages;
    }
}

