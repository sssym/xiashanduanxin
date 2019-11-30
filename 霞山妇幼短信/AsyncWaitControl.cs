using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace 霞山妇幼短信
{
    public partial class AsyncWaitControl : UserControl
    {
        [ToolboxItem(false)]
        public AsyncWaitControl()
        {
            InitializeComponent();
            waitControlOriginalWidth = this.Width;
            lbHintOriginalWidth = LbHint.Width;
            timer1.Enabled = true;
        }

        private int waitControlOriginalWidth { get; set; }

        private int lbHintOriginalWidth { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = FrmSendMassage.i_sendcount.ToString() + "/" + FrmSendMassage.i_rowcount.ToString();
        }
    }
}
