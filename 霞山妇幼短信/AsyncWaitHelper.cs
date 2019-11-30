using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 霞山妇幼短信
{
    public static class AsyncWaitHelper
    {
        /// <summary>
        /// 窗体异步等待执行
        /// </summary>
        /// <param name="from">需要异步等待的窗体</param>
        /// <param name="waitMethod">等待执行的方法（注：方法中不能含有对UI线程控件的操作）</param>
        /// <param name="callBackMethod">等待执行完成回调方法</param>
        public static void AsyncWaitDo(this Form form, Action waitMethod, Action callBackMethod)
        {
            List<Control> controlList = new List<Control>();
            foreach (Control control in form.Controls)
            {
                if (control.Enabled)
                {
                    control.Enabled = false;
                    controlList.Add(control);
                }
            }

            AsyncWaitControl waitControl = new AsyncWaitControl();
            waitControl.Location = new Point((form.Width - waitControl.Width) / 2, (form.Height - waitControl.Height) / 2);
            waitControl.Anchor = AnchorStyles.None;
            form.Controls.Add(waitControl);
            form.ActiveControl = waitControl;
            waitControl.BringToFront();
            form.Refresh();

            Task.Factory.StartNew(() =>
            {
                waitMethod();
            }).ContinueWith((t) =>
            {
                #region waitMethod执行完成后
                if (form.IsHandleCreated)
                {
                    form.BeginInvoke(new Action(() =>
                    {
                        if (t.Exception != null)
                        {
                            #region waitMethod发生异常时
                            form.Controls.Remove(waitControl);
                            waitControl.Dispose();
                            Exception ex = t.Exception.InnerException;
                            MessageBox.Show(ex.Message);
                            #endregion
                        }
                        else
                        {
                            #region waitMethod未发生异常
                            try
                            {
                                if (callBackMethod != null)
                                {
                                    callBackMethod();
                                }
                            }
                            finally
                            {
                                form.Controls.Remove(waitControl);
                                waitControl.Dispose();
                                controlList.ForEach(f => f.Enabled = true);
                            }
                            #endregion
                        }
                    }));
                }
                else if (t.Exception != null)
                {
                    MessageBox.Show(t.Exception.InnerException.Message);
                }
                #endregion
            });
        }
    }
}
