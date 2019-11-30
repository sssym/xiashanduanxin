namespace 霞山妇幼短信
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.短信发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.绩效短信发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.基本工资短信发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看日志ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.短信发送ToolStripMenuItem,
            this.查看日志ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(821, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 短信发送ToolStripMenuItem
            // 
            this.短信发送ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.绩效短信发送ToolStripMenuItem,
            this.基本工资短信发送ToolStripMenuItem});
            this.短信发送ToolStripMenuItem.Name = "短信发送ToolStripMenuItem";
            this.短信发送ToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.短信发送ToolStripMenuItem.Text = "短信发送";
            // 
            // 绩效短信发送ToolStripMenuItem
            // 
            this.绩效短信发送ToolStripMenuItem.Name = "绩效短信发送ToolStripMenuItem";
            this.绩效短信发送ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.绩效短信发送ToolStripMenuItem.Text = "绩效短信发送";
            this.绩效短信发送ToolStripMenuItem.Click += new System.EventHandler(this.绩效短信发送ToolStripMenuItem_Click);
            // 
            // 基本工资短信发送ToolStripMenuItem
            // 
            this.基本工资短信发送ToolStripMenuItem.Name = "基本工资短信发送ToolStripMenuItem";
            this.基本工资短信发送ToolStripMenuItem.Size = new System.Drawing.Size(190, 24);
            this.基本工资短信发送ToolStripMenuItem.Text = "基本工资短信发送";
            this.基本工资短信发送ToolStripMenuItem.Click += new System.EventHandler(this.基本工资短信发送ToolStripMenuItem_Click);
            // 
            // 查看日志ToolStripMenuItem
            // 
            this.查看日志ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看日志ToolStripMenuItem1,
            this.清空日志ToolStripMenuItem});
            this.查看日志ToolStripMenuItem.Name = "查看日志ToolStripMenuItem";
            this.查看日志ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.查看日志ToolStripMenuItem.Text = "日志";
            this.查看日志ToolStripMenuItem.Click += new System.EventHandler(this.查看日志ToolStripMenuItem_Click);
            // 
            // 查看日志ToolStripMenuItem1
            // 
            this.查看日志ToolStripMenuItem1.Name = "查看日志ToolStripMenuItem1";
            this.查看日志ToolStripMenuItem1.Size = new System.Drawing.Size(134, 24);
            this.查看日志ToolStripMenuItem1.Text = "查看日志";
            this.查看日志ToolStripMenuItem1.Click += new System.EventHandler(this.查看日志ToolStripMenuItem1_Click);
            // 
            // 清空日志ToolStripMenuItem
            // 
            this.清空日志ToolStripMenuItem.Name = "清空日志ToolStripMenuItem";
            this.清空日志ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.清空日志ToolStripMenuItem.Text = "清空日志";
            this.清空日志ToolStripMenuItem.Click += new System.EventHandler(this.清空日志ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 612);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "湛江市霞山区妇幼保健院工资短信发送平台";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 短信发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 绩效短信发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 基本工资短信发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看日志ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看日志ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem;
    }
}

