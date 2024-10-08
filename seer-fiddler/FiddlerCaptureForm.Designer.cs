﻿namespace seer_fiddler
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiddlerCaptureForm));
            this.requestListBox = new System.Windows.Forms.ListBox();
            this.tcpCaputureContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeAllItemBtn = new System.Windows.Forms.Button();
            this.startCapturecheckBox = new System.Windows.Forms.CheckBox();
            this.tcpCaputureContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // requestListBox
            // 
            this.requestListBox.ContextMenuStrip = this.tcpCaputureContextMenuStrip;
            this.requestListBox.FormattingEnabled = true;
            this.requestListBox.ItemHeight = 12;
            this.requestListBox.Location = new System.Drawing.Point(1, 0);
            this.requestListBox.Name = "requestListBox";
            this.requestListBox.Size = new System.Drawing.Size(397, 496);
            this.requestListBox.TabIndex = 0;
            // 
            // tcpCaputureContextMenuStrip
            // 
            this.tcpCaputureContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeAllToolStripMenuItem,
            this.copyToolStripMenuItem});
            this.tcpCaputureContextMenuStrip.Name = "tcpCaputureContextMenuStrip";
            this.tcpCaputureContextMenuStrip.Size = new System.Drawing.Size(101, 48);
            // 
            // removeAllToolStripMenuItem
            // 
            this.removeAllToolStripMenuItem.Name = "removeAllToolStripMenuItem";
            this.removeAllToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.removeAllToolStripMenuItem.Text = "清空";
            this.removeAllToolStripMenuItem.Click += new System.EventHandler(this.removeAllToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.copyToolStripMenuItem.Text = "复制";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FiddlerCaptureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "赛尔号封包捕获窗口";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FiddlerCaptureForm_FormClosing);
            this.Load += new System.EventHandler(this.FiddlerForm_Load);
            this.tcpCaputureContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox requestListBox;
        private System.Windows.Forms.Button removeAllItemBtn;
        private System.Windows.Forms.CheckBox startCapturecheckBox;
        private System.Windows.Forms.ContextMenuStrip tcpCaputureContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
    }
}

