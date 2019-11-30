using System;
using System.Collections.Generic;
using System.Text;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System.Windows.Forms;
using System.IO;
namespace 霞山妇幼短信
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void 绩效短信发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSendMassage f = new FrmSendMassage("绩效");
            f.ShowDialog();
        }

        private void 基本工资短信发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSendMassage f = new FrmSendMassage("基本");
            f.ShowDialog();
        }

        private void 查看日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
        }

        private void 查看日志ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@".\log.txt"))
                System.Diagnostics.Process.Start(@".\log.txt");
            else
                MessageBox.Show("日志已清空，无法打开！");

        }

        private void 清空日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dir = MessageBox.Show("确定清除日志文件？");
            if (dir == DialogResult.Yes)
            {
                File.Delete(@".\log.txt");
            }

        }
    }
}
