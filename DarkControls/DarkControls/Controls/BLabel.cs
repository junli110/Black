using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public class BLabel : Control
    {
        public StringAlignment? TextAlign;
        public BLabel()
        {
            this.DoubleBuffered = true;
        }
 
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (this.DesignMode)
            {
                base.OnPaintBackground(e);
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat format = new StringFormat();
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            format.LineAlignment = StringAlignment.Center; format.Alignment = TextAlign??StringAlignment.Near;
            e.Graphics.FillRectangle(new SolidBrush(BackColor), this.ClientRectangle);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(ForeColor), this.ClientRectangle, format);
        }
    }
}
