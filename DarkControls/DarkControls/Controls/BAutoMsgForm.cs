using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class BAutoMsgForm : BMsgForm
    {
        private System.Threading.Timer _timeoutTimer;
        public int timeout = 500;
        public BAutoMsgForm()
        {
            InitializeComponent();
        }
         public BAutoMsgForm(string msg, string title):base(msg, title, BMessageBox.MyButtons.OK, null)
        {
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
        }
        public BAutoMsgForm(string msg, string title,BMessageBox.MyButtons btns):base(msg, title, btns, null)
        {
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
        }
        public BAutoMsgForm(string msg, string title, BMessageBox.MyButtons btns,BMessageBox.MyIcon? icon):base(msg, title, btns, icon)
        {
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
        }
        
        void OnTimerElapsed(object state)
        {
            if (!this.IsDisposed && IsHandleCreated)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.Close(); }));
                }
                else
                {
                    this.Close();
                }
            }
            _timeoutTimer.Dispose();
        }
    }
}
