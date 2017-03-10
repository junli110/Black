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
    public partial class BForm : Form
    {

        const int HTLEFT = 10;
        const int HTRIGHT = 11;
        const int HTTOP = 12;
        const int HTTOPLEFT = 13;
        const int HTTOPRIGHT = 14;
        const int HTBOTTOM = 15;
        const int HTBOTTOMLEFT = 0x10;
        const int HTBOTTOMRIGHT = 17; 
        private bool moving = false;

        private Point oldMousePosition;
        public new FormBorderStyle FormBorderStyle
        {
            get
            {
                return base.FormBorderStyle;
            }
            set
            {
                if (value != FormBorderStyle.Sizable && value != FormBorderStyle.SizableToolWindow)
                {
                    //titlepanel.Controls.Remove(button2);
                }
                base.FormBorderStyle = value;
            }
        }

        #region 隐藏父类的属性，使其不可见

        [Browsable(false)]
        public new string Text
        {
            get
            {
                return titlelabel.Text;
            }
            set
            { titlelabel.Text = value; base.Text = value; }
        }

        [Browsable(false)]
        public new bool ControlBox
        {
            get
            {
                return false;
            }
            set
            {
                base.ControlBox = false;
            }
        }

        #endregion

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题")]
        public string Title
        {
            get { return titlelabel.Text; }
            set { titlelabel.Text = value; base.Text = value; }
        }
        private Icon _icon;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体图标")]
        public Icon Icon
        {
            get { return _icon; }
            set { _icon = value;
            if (_icon != null)
            {
                FormIcon.Image = (Image)_icon.ToBitmap();
                FormIcon.Visible = true;
                titlelabel.Location = new Point(22,4);
                base.Icon = _icon;
            }
            else
            {
                FormIcon.Visible = false;
                titlelabel.Location = new Point(4, 4);
            }
            }
        }


        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题字体样式")]
        public Font TitleFont
        {
            get
            {
                return titlelabel.Font;
            }
            set
            {
                titlelabel.Font = value;
            }
        }


        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题字体颜色")]
        public Color TitleColor
        {
            get
            {
                return titlelabel.ForeColor;
            }
            set
            {
                titlelabel.ForeColor = value;
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题栏背景色")]
        public Color TitleBarBackColor
        {
            get
            {
                return titlepanel.BackColor;
            }
            set
            {
                titlepanel.BackColor = value;
            }
        }
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题栏背景色")]
        public  Control.ControlCollection NewControls
        {
            get
            {
                return panel1.Controls;
            }
           
           
        }
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description("窗体标题栏背景色")]
        public  Control.ControlCollection FormControls
        {
            get
            {
                return this.Controls;
            }

        }


        public new bool MaximizeBox
        {
            get
            {
                return titlepanel.Contains(button2);
            }
            set
            {
                if (!value)
                {
                    button3.Location = button2.Location;
                    titlepanel.Controls.Remove(button2);
                   
                }
                else if (!titlepanel.Contains(button2))
                {
                    titlepanel.Controls.Add(button2);
                }
            }
        }

        public new bool MinimizeBox
        {
            get
            {
                return titlepanel.Contains(button3);
            }
            set
            {
                if (!value)
                {
                    titlepanel.Controls.Remove(button3);
                }
                else if (!titlepanel.Contains(button3))
                {
                    titlepanel.Controls.Add(button3);
                }
            }
        }


        private void ResetTitlePanel()
        {
            base.ControlBox = false;
            base.Text = null;
            SetToolTip(button1, "关闭");
            button2.Size = button1.Size;
            SetToolTip(button2, "最大化或还原");
            button3.Size = button1.Size;
            SetToolTip(button3, "最小化");
        }

        private void SetToolTip(Control ctrl, string tip)
        {
            new ToolTip().SetToolTip(ctrl, tip);
        }
        public BForm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            button1.Font = IconFont.GetFont();
            button1.Text = "";
            button1.ForeColor = Color.FromArgb(255, 255, 255);
        }
        private void Titlebutton_Click(object sender, EventArgs e)
        {
            IconButton btn = (IconButton)sender;
            switch (btn.Tag.ToString())
            {
                case "close":
                    {
                        this.Close();
                        break;
                    }
                case "max":
                    {
                        if (this.WindowState == FormWindowState.Maximized)
                        {
                            this.WindowState = FormWindowState.Normal;
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Maximized;
                           
                        }
                        break;
                    }
                case "min":
                    {
                        if (this.WindowState != FormWindowState.Minimized)
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                        break;
                    }
            }
        }

        private void Titlepanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                return;
            }
            //Titlepanel.Cursor = Cursors.NoMove2D;
            oldMousePosition = e.Location;
            moving = true;
        }

        private void Titlepanel_MouseUp(object sender, MouseEventArgs e)
        {
            //Titlepanel.Cursor = Cursors.Default;
            moving = false;
        }

        private void Titlepanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && moving)
            {
                Point newPosition = new Point(e.Location.X - oldMousePosition.X, e.Location.Y - oldMousePosition.Y);
                this.Location += new Size(newPosition);
            }
        }

        private void Titlepanel_DoubleClick(object sender, EventArgs e)
        {
            if (titlepanel.Contains(button2))
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void titlepanel_ControlRemoved(object sender, ControlEventArgs e)
        {
            switch (e.Control.Name)
            {
                case "button2":
                    {
                        if (titlepanel.Contains(button3))
                        {
                            button3.Left = button1.Left - button1.Width;
                        }
                        break;
                    }
            }
        }

        private void titlepanel_ControlAdded(object sender, ControlEventArgs e)
        {
            switch (e.Control.Name)
            {
                case "button2":
                    {
                        if (titlepanel.Contains(button3))
                        {
                            button3.Left = button2.Left - button2.Width;
                        }
                        break;
                    }
                case "button3":
                    {
                        if (titlepanel.Contains(button2))
                        {
                            button3.Left = button2.Left - button2.Width;
                        }
                        break;
                    }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawLines(new Pen(this.BackColor, 3), new Point[] { new Point(0, 0), new Point(0, this.Height), new Point(this.Width, this.Height), new Point(this.Width, 0) });
        }
        protected override void WndProc(ref Message m)
        {
      
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMLEFT;
                        else m.Result = (IntPtr)HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息   
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标   
                    m.LParam = IntPtr.Zero;//默认值   
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内   
                    base.WndProc(ref m);
                    break;
                default:
                  
                    base.WndProc(ref m);
                    break;
            }
        } 
    }
}
