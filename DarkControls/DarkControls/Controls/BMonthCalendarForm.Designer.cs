namespace DarkControls.Controls
{
    partial class BMonthCalendarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bMonthCalendar1 = new DarkControls.Controls.BMonthCalendar();
            this.SuspendLayout();
            // 
            // bMonthCalendar1
            // 
            this.bMonthCalendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.bMonthCalendar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.bMonthCalendar1.Location = new System.Drawing.Point(-1, -1);
            this.bMonthCalendar1.Name = "bMonthCalendar1";
            this.bMonthCalendar1.TabIndex = 0;
            this.bMonthCalendar1.TitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.bMonthCalendar1.TitleForeColor = System.Drawing.Color.White;
            this.bMonthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.bMonthCalendar1_DateChanged);
            this.bMonthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.bMonthCalendar1_DateSelected);
            // 
            // BMonthCalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(95)))), ((int)(((byte)(95)))));
            this.ClientSize = new System.Drawing.Size(205, 153);
            this.ControlBox = false;
            this.Controls.Add(this.bMonthCalendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BMonthCalendarForm";
            this.Text = "BMonthCalendarForm";
            this.ResumeLayout(false);

        }

        #endregion

        public BMonthCalendar bMonthCalendar1;

    }
}