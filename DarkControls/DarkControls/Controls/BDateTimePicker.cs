
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    class BDateTimePicker : UserControl
    {
        private TextBox textBox1;
        private IconButton iconButton1;
        private BMonthCalendarForm monthCalendar;
        private bool showCalendar=false;
        private bool mouseDown = false;
        private int start;
        private int length;
        private string oriText;
        public DateTime? EditValue
        {
            get { return Convert.ToDateTime( textBox1.Text); }
            set { textBox1.Text = (value == null ? "" : value.Value.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(value.Value)); }
        }
        
        
        public BDateTimePicker()
        {
            
            InitializeComponent();
            iconButton1.IconType = IconType.sanjaoDown;
           
            initMonthCalendar();
            textBox1.Height = this.Height;
            textBox1.Width = this.Width-3;
            iconButton1.Height = textBox1.Height - 5;
            iconButton1.Left = this.Width - iconButton1.Width-5;
            iconButton1.Top = 4;
            textBox1.LostFocus += textBox1_LostFocus;
            this.SizeChanged+=BDateTimePicker_SizeChanged;
           
            
            iconButton1.MouseUp+=iconButton1_MouseUp;
            textBox1.Text = DateTime.Now.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(DateTime.Now);
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 4;


        }

        private void BDateTimePicker_SizeChanged(object sender, EventArgs e)
        {
            textBox1.Height = this.Height;
            textBox1.Width = this.Width - 3;
            iconButton1.Height = textBox1.Height - 5;
            iconButton1.Width = 16;
            iconButton1.Left = this.Width - iconButton1.Width-1 ;

        }

      
        private void iconButton1_MouseUp(object sender, MouseEventArgs e)
        {
            
           
            if (monthCalendar == null || monthCalendar.IsDisposed)
            {
                initMonthCalendar();
            }
            if (monthCalendar.Visible == false)
            {
                monthCalendar.Left = PointToScreen(new Point(0, 0)).X-20;
                monthCalendar.Top = PointToScreen(new Point(0, 0)).Y + this.Height + 3;

                monthCalendar.Show();
            }
            monthCalendar.bMonthCalendar1.SelectionStart = monthCalendar.bMonthCalendar1.SelectionEnd = EditValue??DateTime.Now;
            monthCalendar.BringToFront();
            monthCalendar.bMonthCalendar1.Focus();
           
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {

           
            DateTime dt;
            if (!DateTime.TryParse(textBox1.Text, out dt))
            {
                textBox1.Text = DateTime.Now.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(DateTime.Now);
            }
            
        }
        private void initMonthCalendar()
        {
            monthCalendar = new BMonthCalendarForm();
            monthCalendar.StartPosition = FormStartPosition.Manual;
            monthCalendar.Visible = false;
            monthCalendar.DateChange += DateChange;
            monthCalendar.bMonthCalendar1.LostFocus += monthCalendar_LostFocus;
            
           
        }

        private void monthCalendar_LostFocus(object sender, EventArgs e)
        {
         if(!monthCalendar.bMonthCalendar1.ContainsFocus)
                monthCalendar.Hide();
        }
        private void DateChange(DateTime newDate) {
            textBox1.Text = newDate.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(newDate); ;
            textBox1.SelectionStart = 0;
            textBox1.SelectionLength = 4;
        }
        private void InitializeComponent()
        {
            this.textBox1 = new TextBox();
            this.iconButton1 = new DarkControls.Controls.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            // 
            // 
            // 
            
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(213)))), ((int)(((byte)(213)))));
            this.textBox1.Location = new System.Drawing.Point(3, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // iconButton1
            // 
            this.iconButton1.ActiveColor = System.Drawing.Color.White;
            this.iconButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.iconButton1.Bold = false;
            this.iconButton1.IconType = DarkControls.Controls.IconType.sanjaoDown;
            this.iconButton1.InActiveColor = System.Drawing.SystemColors.Control;
            this.iconButton1.Location = new System.Drawing.Point(132, 3);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(18, 17);
            this.iconButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconButton1.TabIndex = 1;
            this.iconButton1.TabStop = false;
            this.iconButton1.ToolTipText = null;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // BDateTimePicker
            // 
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.textBox1);
            this.Name = "BDateTimePicker";
            this.Size = new System.Drawing.Size(150, 23);
            ((System.ComponentModel.ISupportInitialize)(this.iconButton1)).EndInit();
            this.ResumeLayout(false);

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
           
           
            //monthCalendar.BringToFront();
            //monthCalendar.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down || e.KeyData == Keys.Right || e.KeyData == Keys.Left)
            {
                textBox1.SelectionStart = start;
                textBox1.SelectionLength = length;
            }
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (!DateTime.TryParse(textBox1.Text, out dt))
            {
                textBox1.Text = DateTime.Now.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(DateTime.Now);
            }
            else
            {
                textBox1.Text = dt.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(dt);
            }
            var arr = textBox1.Text.Split(new char[] {'/',' ' });
            int st = 0, len = 0, end = 0;
            for (int i = 0; i < arr.Count(); i++)
            {

                if (len + arr[i].Length >= textBox1.SelectionStart)
                {
                    textBox1.SelectionStart = len;
                    textBox1.SelectionLength = arr[i].Length;
                    break;
                }
                len += arr[i].Length+1;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            start = textBox1.SelectionStart;
            length = textBox1.SelectionLength;

            DateTime d;
            if (DateTime.TryParse(textBox1.Text, out d))
            {
                var date = d;
                textBox1.Text = d.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(d);
                if (e.KeyData == Keys.Up)
                {

                   
                    if (start == 0)
                        date = date.AddYears(1);
                    else if (start == 5)
                        date = date.AddMonths(1);
                    else if (start == 8 || start == 11)
                        date = date.AddDays(1);
                    textBox1.Text = date.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(date); ;
                    textBox1.SelectionStart = start;
                    textBox1.SelectionLength = length;

                    e.Handled = true;

                }
                else if (e.KeyData == Keys.Down)
                {

                    
                    if (start == 0)
                        date = date.AddYears(-1);
                    else if (start == 5)
                        date = date.AddMonths(-1);
                    else if (start == 8 || start == 11)
                        date = date.AddDays(-1);
                    textBox1.Text = date.ToString("yyyy/MM/dd ", CultureInfo.CreateSpecificCulture("zh-cn")) + GetWeek(date);

                    textBox1.SelectionStart = start;
                    textBox1.SelectionLength = length;

                    e.Handled = true;

                }
                else if (e.KeyData == Keys.Right)
                {
                    if (start == 0)
                    {
                        start = 5;
                        length = 2;
                    }

                    else if (start == 5)
                    {
                        start = 8;
                        length = 2;
                    }
                    else if (start == 8)
                    {
                        start = 11;
                        length = 3;
                    }
                    else if (start == 11)
                    {

                    }
                    textBox1.SelectionStart = start;
                    textBox1.SelectionLength = length;
                }
                else if (e.KeyData == Keys.Left)
                {
                    if (start == 0)
                    {

                    }

                    else if (start == 5)
                    {
                        start = 0;
                        length = 4;
                    }
                    else if (start == 8)
                    {
                        start = 5;
                        length = 2;
                    }
                    else if (start == 11)
                    {
                        start = 8;
                        length = 2;
                    }
                    textBox1.SelectionStart = start;
                    textBox1.SelectionLength = length;
                }
            }

        }
        public string GetWeek(DateTime dt)
        {
            return CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(dt.DayOfWeek);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Keys.Up.ToString() || e.KeyChar.ToString() == Keys.Down.ToString() || e.KeyChar.ToString() == Keys.Right.ToString() || e.KeyChar.ToString() == Keys.Left.ToString() || char.IsDigit(e.KeyChar))
            {
                
            }
            else
            {
                
                e.Handled = true;
            }
            //oriText = textBox1.Text;
        }
    }
}  