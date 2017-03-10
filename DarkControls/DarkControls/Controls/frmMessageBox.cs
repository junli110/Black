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
    public enum MessageBoxStyle
    {
        info=0,
        question=1,
        error=2
    };

    public partial class frmMessageBox : Form
    {
        public frmMessageBox(MessageBoxStyle messageBoxStyle,string msg)
        {
            InitializeComponent();

            if (messageBoxStyle == MessageBoxStyle.info)
            {
                picICO.Image = ResourceFont.info;
                this.Text = "提示";
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (messageBoxStyle == MessageBoxStyle.question)
            {
                picICO.Image = ResourceFont.question;
                this.Text = "询问";
                panel1.Visible = false;
                panel2.Visible = true;
            }
            else if (messageBoxStyle == MessageBoxStyle.error)
            {
                picICO.Image = ResourceFont.error;
                this.Text = "错误";
                panel1.Visible = true;
                panel2.Visible = false;
            }

            this.labInfo.Text = msg;

            SizeF size = TextRenderer.MeasureText(msg, new Font("宋体", 15, FontStyle.Regular));
            
            int TempWidth = (int)size.Width;
            if (TempWidth <= 249) { return; }

            this.Width = (int)size.Width + 130;
            this.panel1.Width = TempWidth-20;
            this.panel2.Width = TempWidth-20;
            btnYes.Width = TempWidth / 2 - 20;
            btnNo.Width = TempWidth / 2 - 20;
        }
    }
}
