using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DarkControls.Controls
{
    public partial class BMonthCalendar : MonthCalendar
    {
        private Font IconFont;
        public BMonthCalendar()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(95, 95, 95);
            this.ForeColor = Color.FromArgb(215, 215, 215);
            this.TitleBackColor = Color.FromArgb(65,65, 65);
            this.TitleForeColor = Color.FromArgb(215, 215, 215);
            this.TitleForeColor = Color.White;
            var iconbtn = new IconButton();
            IconFont = iconbtn.GetIconFont(9);
            
        }
        [DllImportAttribute("uxtheme.dll")]
        private static extern int SetWindowTheme(IntPtr hWnd, string appname, string idlist);

        protected override void OnHandleCreated(EventArgs e)
        {
            SetWindowTheme(this.Handle, "", "");
           // this.Controls
            base.OnHandleCreated(e);
        }
        protected static int WM_PAINT = 0x000F;
        public const int WM_ERASEBKGND = 0x0014;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (WM_ERASEBKGND != m.Msg)
                base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                Graphics graphics = Graphics.FromHwnd(this.Handle);
                PaintEventArgs pe = new PaintEventArgs(graphics, new Rectangle(0, 0, this.Width, this.Height));
                OnPaint(pe);
            }
        }
       
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(this.BackColor), 2, 2, this.Width - 4, 30);
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(13, 8, 22, 18));
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(this.Width - 32, 8, 22, 18));
            g.DrawString(char.ConvertFromUtf32((int)IconType.snajiaoLeft), IconFont, new SolidBrush(this.ForeColor), 10, 10);
            g.DrawString(char.ConvertFromUtf32((int)IconType.sanjaoRight), IconFont, new SolidBrush(this.ForeColor), this.Width - 32, 10);
            TextRenderer.DrawText(g, this.SelectionStart.ToShortDateString(), this.Font, new Rectangle(2, 2, this.Width - 4, 28), this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);

        }
    }
}
