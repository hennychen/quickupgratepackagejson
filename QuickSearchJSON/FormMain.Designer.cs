namespace QuickSearchJSON
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonSelectSource = new System.Windows.Forms.Button();
            this.buttonSelectTarget = new System.Windows.Forms.Button();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.listBoxCommonKeys = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonSelectSource
            // 
            this.buttonSelectSource.Location = new System.Drawing.Point(36, 23);
            this.buttonSelectSource.Name = "buttonSelectSource";
            this.buttonSelectSource.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectSource.TabIndex = 0;
            this.buttonSelectSource.Text = "旧版package.json";
            this.buttonSelectSource.UseVisualStyleBackColor = true;
            this.buttonSelectSource.Click += new System.EventHandler(this.buttonSelectSource_Click);
            // 
            // buttonSelectTarget
            // 
            this.buttonSelectTarget.Location = new System.Drawing.Point(117, 23);
            this.buttonSelectTarget.Name = "buttonSelectTarget";
            this.buttonSelectTarget.Size = new System.Drawing.Size(68, 23);
            this.buttonSelectTarget.TabIndex = 1;
            this.buttonSelectTarget.Text = "新版package.json";
            this.buttonSelectTarget.UseVisualStyleBackColor = true;
            this.buttonSelectTarget.Click += new System.EventHandler(this.buttonSelectTarget_Click);
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(268, 23);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(88, 23);
            this.buttonConvert.TabIndex = 2;
            this.buttonConvert.Text = "升级输出";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // listBoxCommonKeys
            // 
            this.listBoxCommonKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxCommonKeys.FormattingEnabled = true;
            this.listBoxCommonKeys.ItemHeight = 17;
            this.listBoxCommonKeys.Location = new System.Drawing.Point(46, 84);
            this.listBoxCommonKeys.Name = "listBoxCommonKeys";
            this.listBoxCommonKeys.Size = new System.Drawing.Size(309, 310);
            this.listBoxCommonKeys.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 450);
            this.Controls.Add(this.listBoxCommonKeys);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonSelectTarget);
            this.Controls.Add(this.buttonSelectSource);
            this.Name = "FormMain";
            this.Text = "快捷查找两个文件相同key";
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonSelectSource;
        private Button buttonSelectTarget;
        private Button buttonConvert;
        private ListBox listBoxCommonKeys;
    }
}