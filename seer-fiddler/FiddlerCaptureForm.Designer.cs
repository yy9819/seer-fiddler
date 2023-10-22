namespace seer_fiddler
{
    partial class FiddlerCaptureForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiddlerCaptureForm));
            this.requestListBox = new System.Windows.Forms.ListBox();
            this.removeAllItemBtn = new System.Windows.Forms.Button();
            this.startCapturecheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // requestListBox
            // 
            this.requestListBox.FormattingEnabled = true;
            this.requestListBox.ItemHeight = 12;
            this.requestListBox.Location = new System.Drawing.Point(1, 0);
            this.requestListBox.Name = "requestListBox";
            this.requestListBox.Size = new System.Drawing.Size(397, 496);
            this.requestListBox.TabIndex = 0;
            // 
            // removeAllItemBtn
            // 
            this.removeAllItemBtn.Location = new System.Drawing.Point(404, 458);
            this.removeAllItemBtn.Name = "removeAllItemBtn";
            this.removeAllItemBtn.Size = new System.Drawing.Size(72, 38);
            this.removeAllItemBtn.TabIndex = 1;
            this.removeAllItemBtn.Text = "清空";
            this.removeAllItemBtn.UseVisualStyleBackColor = true;
            this.removeAllItemBtn.Click += new System.EventHandler(this.removeAllItemBtn_Click);
            // 
            // startCapturecheckBox
            // 
            this.startCapturecheckBox.AutoSize = true;
            this.startCapturecheckBox.Checked = true;
            this.startCapturecheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startCapturecheckBox.Location = new System.Drawing.Point(404, 436);
            this.startCapturecheckBox.Name = "startCapturecheckBox";
            this.startCapturecheckBox.Size = new System.Drawing.Size(72, 16);
            this.startCapturecheckBox.TabIndex = 2;
            this.startCapturecheckBox.Text = "开始捕获";
            this.startCapturecheckBox.UseVisualStyleBackColor = true;
            // 
            // FiddlerCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 499);
            this.Controls.Add(this.startCapturecheckBox);
            this.Controls.Add(this.removeAllItemBtn);
            this.Controls.Add(this.requestListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FiddlerCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "赛尔号封包捕获窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiddlerCaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.FiddlerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox requestListBox;
        private System.Windows.Forms.Button removeAllItemBtn;
        private System.Windows.Forms.CheckBox startCapturecheckBox;
    }
}

