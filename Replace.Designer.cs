namespace wordpad
{
    partial class Replace
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
            this.tbFinder = new System.Windows.Forms.TextBox();
            this.tbReplace = new System.Windows.Forms.TextBox();
            this.chkWholeWord = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.btReplace = new System.Windows.Forms.Button();
            this.btReplaceAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbFinder
            // 
            this.tbFinder.Location = new System.Drawing.Point(37, 25);
            this.tbFinder.Multiline = true;
            this.tbFinder.Name = "tbFinder";
            this.tbFinder.Size = new System.Drawing.Size(190, 23);
            this.tbFinder.TabIndex = 1;
            // 
            // tbReplace
            // 
            this.tbReplace.Location = new System.Drawing.Point(37, 54);
            this.tbReplace.Multiline = true;
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.Size = new System.Drawing.Size(190, 23);
            this.tbReplace.TabIndex = 2;
            // 
            // chkWholeWord
            // 
            this.chkWholeWord.AutoSize = true;
            this.chkWholeWord.Location = new System.Drawing.Point(37, 107);
            this.chkWholeWord.Name = "chkWholeWord";
            this.chkWholeWord.Size = new System.Drawing.Size(150, 17);
            this.chkWholeWord.TabIndex = 8;
            this.chkWholeWord.Text = "Search for the whole word";
            this.chkWholeWord.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(37, 83);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(82, 17);
            this.chkMatchCase.TabIndex = 7;
            this.chkMatchCase.Text = "Match case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(260, 101);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(260, 25);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 5;
            this.btNext.Text = "Next";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // btReplace
            // 
            this.btReplace.Location = new System.Drawing.Point(260, 52);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(75, 23);
            this.btReplace.TabIndex = 9;
            this.btReplace.Text = "Replace";
            this.btReplace.UseVisualStyleBackColor = true;
            this.btReplace.Click += new System.EventHandler(this.btReplace_Click);
            // 
            // btReplaceAll
            // 
            this.btReplaceAll.Location = new System.Drawing.Point(260, 77);
            this.btReplaceAll.Name = "btReplaceAll";
            this.btReplaceAll.Size = new System.Drawing.Size(75, 23);
            this.btReplaceAll.TabIndex = 10;
            this.btReplaceAll.Text = "Replace all";
            this.btReplaceAll.UseVisualStyleBackColor = true;
            // 
            // Replace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 139);
            this.Controls.Add(this.btReplaceAll);
            this.Controls.Add(this.btReplace);
            this.Controls.Add(this.chkWholeWord);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.tbReplace);
            this.Controls.Add(this.tbFinder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Replace";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Replace";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox tbFinder;
        public System.Windows.Forms.TextBox tbReplace;
        public System.Windows.Forms.CheckBox chkWholeWord;
        public System.Windows.Forms.CheckBox chkMatchCase;
        public System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.Button btNext;
        public System.Windows.Forms.Button btReplace;
        public System.Windows.Forms.Button btReplaceAll;
    }
}