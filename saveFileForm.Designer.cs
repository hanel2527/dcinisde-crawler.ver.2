namespace DcCrawler.WF
{
    partial class saveFileForm
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
            this.SaveAsText = new System.Windows.Forms.Button();
            this.SaveAsTable = new System.Windows.Forms.Button();
            this.filenameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.explainLinkLabel = new System.Windows.Forms.LinkLabel();
            this.maximumRankTextBox = new System.Windows.Forms.TextBox();
            this.minimumCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveAsText
            // 
            this.SaveAsText.Location = new System.Drawing.Point(12, 170);
            this.SaveAsText.Name = "SaveAsText";
            this.SaveAsText.Size = new System.Drawing.Size(120, 49);
            this.SaveAsText.TabIndex = 0;
            this.SaveAsText.Text = "텍스트 파일로 저장";
            this.SaveAsText.UseVisualStyleBackColor = true;
            this.SaveAsText.Click += new System.EventHandler(this.SaveAsText_Click);
            // 
            // SaveAsTable
            // 
            this.SaveAsTable.Location = new System.Drawing.Point(150, 170);
            this.SaveAsTable.Name = "SaveAsTable";
            this.SaveAsTable.Size = new System.Drawing.Size(120, 49);
            this.SaveAsTable.TabIndex = 1;
            this.SaveAsTable.Text = "표로 저장(html)";
            this.SaveAsTable.UseVisualStyleBackColor = true;
            this.SaveAsTable.Click += new System.EventHandler(this.SaveAsTable_Click);
            // 
            // filenameTextBox
            // 
            this.filenameTextBox.Location = new System.Drawing.Point(12, 31);
            this.filenameTextBox.Name = "filenameTextBox";
            this.filenameTextBox.Size = new System.Drawing.Size(375, 25);
            this.filenameTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "파일명(results 폴더 안에 저장)";
            // 
            // explainLinkLabel
            // 
            this.explainLinkLabel.AutoSize = true;
            this.explainLinkLabel.Location = new System.Drawing.Point(289, 204);
            this.explainLinkLabel.Name = "explainLinkLabel";
            this.explainLinkLabel.Size = new System.Drawing.Size(137, 15);
            this.explainLinkLabel.TabIndex = 6;
            this.explainLinkLabel.TabStop = true;
            this.explainLinkLabel.Text = "표로 저장 사용방법";
            this.explainLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.explainLinkLabel_LinkClicked);
            // 
            // maximumRankTextBox
            // 
            this.maximumRankTextBox.Location = new System.Drawing.Point(16, 85);
            this.maximumRankTextBox.Name = "maximumRankTextBox";
            this.maximumRankTextBox.Size = new System.Drawing.Size(100, 25);
            this.maximumRankTextBox.TabIndex = 9;
            this.maximumRankTextBox.Text = "300";
            // 
            // minimumCountTextBox
            // 
            this.minimumCountTextBox.Location = new System.Drawing.Point(16, 139);
            this.minimumCountTextBox.Name = "minimumCountTextBox";
            this.minimumCountTextBox.Size = new System.Drawing.Size(100, 25);
            this.minimumCountTextBox.TabIndex = 10;
            this.minimumCountTextBox.Text = "3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "일정 랭킹 이하만 출력";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "일정 글 수 이상만 출력";
            // 
            // saveFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 242);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.minimumCountTextBox);
            this.Controls.Add(this.maximumRankTextBox);
            this.Controls.Add(this.explainLinkLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filenameTextBox);
            this.Controls.Add(this.SaveAsTable);
            this.Controls.Add(this.SaveAsText);
            this.Name = "saveFileForm";
            this.Text = "saveFileForm";
            this.Load += new System.EventHandler(this.saveFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveAsText;
        private System.Windows.Forms.Button SaveAsTable;
        private System.Windows.Forms.TextBox filenameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel explainLinkLabel;
        private System.Windows.Forms.TextBox maximumRankTextBox;
        private System.Windows.Forms.TextBox minimumCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}