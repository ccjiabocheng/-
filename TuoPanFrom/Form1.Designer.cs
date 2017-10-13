namespace TuoPanFrom
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.mainNotifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择进程ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.启动MS服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭MS服务ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.关闭MS服务ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.开启关闭自启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainNotifyContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainNotifyIcon
            // 
            this.mainNotifyIcon.ContextMenuStrip = this.mainNotifyContextMenuStrip;
            this.mainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("mainNotifyIcon.Icon")));
            this.mainNotifyIcon.Text = "SQL Server 服务托盘";
            this.mainNotifyIcon.Visible = true;
            // 
            // mainNotifyContextMenuStrip
            // 
            this.mainNotifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择进程ToolStripMenuItem,
            this.toolStripSeparator3,
            this.启动MS服务ToolStripMenuItem,
            this.关闭MS服务ToolStripMenuItem,
            this.关闭MS服务ToolStripMenuItem1,
            this.toolStripSeparator1,
            this.开启关闭自启动ToolStripMenuItem,
            this.toolStripSeparator2,
            this.关闭ToolStripMenuItem});
            this.mainNotifyContextMenuStrip.Name = "mainNotifyContextMenuStrip";
            this.mainNotifyContextMenuStrip.Size = new System.Drawing.Size(166, 138);
            // 
            // 选择进程ToolStripMenuItem
            // 
            this.选择进程ToolStripMenuItem.Image = global::TuoPanFrom.Properties.Resources._9f3f8b01a18b87d65587fdc10e0828381d30fdce;
            this.选择进程ToolStripMenuItem.Name = "选择进程ToolStripMenuItem";
            this.选择进程ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.选择进程ToolStripMenuItem.Text = "选择进程";
            this.选择进程ToolStripMenuItem.Click += new System.EventHandler(this.选择进程ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // 启动MS服务ToolStripMenuItem
            // 
            this.启动MS服务ToolStripMenuItem.Name = "启动MS服务ToolStripMenuItem";
            this.启动MS服务ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.启动MS服务ToolStripMenuItem.Text = "启动MS服务";
            this.启动MS服务ToolStripMenuItem.Click += new System.EventHandler(this.启动MS服务ToolStripMenuItem_Click);
            // 
            // 关闭MS服务ToolStripMenuItem
            // 
            this.关闭MS服务ToolStripMenuItem.Name = "关闭MS服务ToolStripMenuItem";
            this.关闭MS服务ToolStripMenuItem.Size = new System.Drawing.Size(162, 6);
            // 
            // 关闭MS服务ToolStripMenuItem1
            // 
            this.关闭MS服务ToolStripMenuItem1.Name = "关闭MS服务ToolStripMenuItem1";
            this.关闭MS服务ToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.关闭MS服务ToolStripMenuItem1.Text = "关闭MS服务";
            this.关闭MS服务ToolStripMenuItem1.Click += new System.EventHandler(this.关闭MS服务ToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // 开启关闭自启动ToolStripMenuItem
            // 
            this.开启关闭自启动ToolStripMenuItem.Name = "开启关闭自启动ToolStripMenuItem";
            this.开启关闭自启动ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.开启关闭自启动ToolStripMenuItem.Text = "开启/关闭自启动";
            this.开启关闭自启动ToolStripMenuItem.Click += new System.EventHandler(this.开启关闭自启动ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // 关闭ToolStripMenuItem
            // 
            this.关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            this.关闭ToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.关闭ToolStripMenuItem.Text = "关闭";
            this.关闭ToolStripMenuItem.Click += new System.EventHandler(this.关闭ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 261);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.mainNotifyContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mainNotifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 启动MS服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator 关闭MS服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭MS服务ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon mainNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 选择进程ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 开启关闭自启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

