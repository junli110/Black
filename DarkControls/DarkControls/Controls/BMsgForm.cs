using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class BMsgForm : BForm
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool MessageBeep(uint type);
        BButton btnNo=null;
        BButton btnOK = null;
        public BMsgForm()
        {
            InitializeComponent();
        }
        public BMsgForm(string msg, string title)
        {
            setMsg(msg, title, BMessageBox.MyButtons.OK, null);
        }
        public BMsgForm(string msg, string title,BMessageBox.MyButtons btns)
        {
            setMsg(msg, title, btns, null);
        }
        public BMsgForm(string msg, string title, BMessageBox.MyButtons btns,BMessageBox.MyIcon? icon)
        {
            setMsg(msg, title, btns, icon);
        }
        private void setMsg(string msg, string title, BMessageBox.MyButtons btns,BMessageBox.MyIcon? icon)
        {
            InitializeComponent();
            this.Title = title;
            this.bLabel1.TextAlign = StringAlignment.Center;
            this.bLabel1.Text = msg;
            if (icon == null)
            {
                IconBox.Visible = false;
                bLabel1.Location = new Point((this.Width-bLabel1.Width)/2,26);
                bLabel1.Width += 20;
                MessageBeep((uint)BMessageBox.MessageBeepType.Ok);
            }
            else if (icon == BMessageBox.MyIcon.Question)
            {
                MessageBeep((uint)BMessageBox.MessageBeepType.Question);
                IconBox.Image = ResourceFont.question;
            }
            else if (icon == BMessageBox.MyIcon.Information)
            {
                MessageBeep((uint)BMessageBox.MessageBeepType.Information);
                IconBox.Image = ResourceFont.info;
            }
            else if (icon == BMessageBox.MyIcon.Error)
            {
                MessageBeep((uint)BMessageBox.MessageBeepType.Error);
                IconBox.Image = ResourceFont.error;
            }
            else
            {
                MessageBeep((uint)BMessageBox.MessageBeepType.Ok);
                IconBox.Visible = false;
                bLabel1.Location = new Point((this.Width - bLabel1.Width) / 2, 26);
            }
            if (btns == BMessageBox.MyButtons.OK)
            {
                btnOK = new BButton();
                btnOK.Text = "确定";
                btnOK.Size = new System.Drawing.Size(80, 25);
                btnOK.BackColor = System.Drawing.Color.FromArgb(69, 69, 69);
                btnOK.HoverColor = System.Drawing.Color.FromArgb(79, 79, 79);
                btnOK.ForeColor = SystemColors.Control;
                btnOK.BorderColor = System.Drawing.Color.Black;
                btnOK.Location = new Point((this.Width - btnOK.Width) / 2, 80);
                btnOK.Click += new EventHandler(btnOK_Click);
                this.NewControls.Add(btnOK);
                
            }
            if (btns == BMessageBox.MyButtons.YesNo)
            {
                BButton btnYes = new BButton();
                btnYes.Text = "是";
                btnYes.Size = new System.Drawing.Size(80, 25);
                btnYes.BackColor = System.Drawing.Color.FromArgb(69, 69, 69);
                btnYes.HoverColor = System.Drawing.Color.FromArgb(79, 79, 79);
                btnYes.BorderColor = System.Drawing.Color.Black;
                btnYes.ForeColor = SystemColors.Control;
                btnYes.Location = new Point((this.Width - 2 * btnYes.Width-10) / 2, 80);
                btnYes.Click += new EventHandler(btnYes_Click);

                btnNo = new BButton();
                btnNo.Text = "否";
                btnNo.Size = new System.Drawing.Size(80, 25);
                btnNo.BackColor = System.Drawing.Color.FromArgb(69, 69, 69);
                btnNo.HoverColor = System.Drawing.Color.FromArgb(79, 79, 79);
                btnNo.BorderColor = System.Drawing.Color.Black;
                btnNo.ForeColor = SystemColors.Control;
                btnNo.TabStop = false;
                btnNo.Location = new Point((this.Width - 2 * btnNo.Width - 10) / 2 + btnNo.Width+10, 80);
                btnNo.Click += new EventHandler(btnNo_Click);
                this.NewControls.Add(btnYes);
                this.NewControls.Add(btnNo);
                
            }


        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.No;
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.Yes;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CYReturnButton = DialogResult.OK;
            this.Close();
        }

        public DialogResult CYReturnButton { get; set; }

        private void BMsgForm_Activated(object sender, EventArgs e)
        {
            if (btnNo != null)
            {
                btnNo.Focus();
            }
            else if (btnOK != null) {

                btnOK.Focus();
            }
        }
    }
}
