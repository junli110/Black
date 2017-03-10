using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class BButton : Button
    {
        private Color borderColor;
        private Color hoverColor;
        public Color BorderColor { 
            get { return borderColor; } 
            set { borderColor = value; this.Invalidate(); } }
        public Color HoverColor { get { return hoverColor; } set { hoverColor = value; this.Invalidate(); } }
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
                myPen = base.BackColor;
            }
        }
        private Color myPen;
        public BButton()
        {
            InitializeComponent();
            borderColor = Color.Black;
            hoverColor = Color.Black;
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            this.DoubleBuffered = true;
            
        }
        protected override void OnMouseLeave(EventArgs e)
       {
           base.OnMouseLeave(e);
           myPen = this.BackColor;
       }

       protected override void OnMouseEnter(EventArgs e)
       {
           base.OnMouseEnter(e);
           myPen = HoverColor;
       }
       protected override void OnKeyDown(KeyEventArgs kevent)
       {
           
           base.OnKeyDown(kevent);
           if (kevent.KeyCode == Keys.Enter)
           {
               this.PerformClick();
           }
       }
       
         protected override void OnPaint(PaintEventArgs pevent)
         {
             //base.OnPaint(pevent);
             Graphics g = pevent.Graphics;
             g.FillRectangle(new SolidBrush(myPen), this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width, this.ClientRectangle.Height);
             g.DrawRectangle(new Pen(BorderColor), this.ClientRectangle.X, this.ClientRectangle.Y, this.ClientRectangle.Width-1, this.ClientRectangle.Height-1);
             Rectangle rect = this.ClientRectangle;
             if (Image != null)
             {
                 g.DrawImage(this.Image, new Rectangle(2, this.ClientRectangle.Y + (this.Height - Image.Height) / 2, Image.Width, Image.Height));
                 rect = new Rectangle(this.ClientRectangle.X + Image.Width + 2, this.ClientRectangle.Y, this.Width - Image.Width - 2, this.Height);
             }
             StringFormat strF = new StringFormat();
             strF.Alignment = StringAlignment.Center;
             strF.LineAlignment = StringAlignment.Center;
             
             
             g.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), rect, strF);
         }
    }
}
