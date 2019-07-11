namespace DcCrawler.WF
{
    partial class tempDataFileSelect
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
            this.fileSelectListBox = new System.Windows.Forms.ListBox();
            this.selectBtn = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileSelectListBox
            // 
            this.fileSelectListBox.FormattingEnabled = true;
            this.fileSelectListBox.ItemHeight = 15;
            this.fileSelectListBox.Location = new System.Drawing.Point(13, 13);
            this.fileSelectListBox.Name = "fileSelectListBox";
            this.fileSelectListBox.Size = new System.Drawing.Size(775, 349);
            this.fileSelectListBox.TabIndex = 0;
            // 
            // selectBtn
            // 
            this.selectBtn.Location = new System.Drawing.Point(13, 369);
            this.selectBtn.Name = "selectBtn";
            this.selectBtn.Size = new System.Drawing.Size(134, 69);
            this.selectBtn.TabIndex = 1;
            this.selectBtn.Text = "확인";
            this.selectBtn.UseVisualStyleBackColor = true;
            this.selectBtn.Click += new System.EventHandler(this.selectBtn_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(637, 369);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(151, 69);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "취소";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // tempDataFileSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.selectBtn);
            this.Controls.Add(this.fileSelectListBox);
            this.Name = "tempDataFileSelect";
            this.Text = "tempDataFileSelect";
            this.Load += new System.EventHandler(this.tempDataFileSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox fileSelectListBox;
        private System.Windows.Forms.Button selectBtn;
        private System.Windows.Forms.Button cancel;
    }
}