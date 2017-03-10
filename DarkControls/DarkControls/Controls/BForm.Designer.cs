using System.Drawing;
namespace DarkControls.Controls
{
    partial class BForm
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
            this.titlepanel = new System.Windows.Forms.Panel();
            this.FormIcon = new System.Windows.Forms.PictureBox();
            this.titlelabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new DarkControls.Controls.IconButton();
            this.button3 = new DarkControls.Controls.IconButton();
            this.button1 = new DarkControls.Controls.IconButton();
            this.titlepanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            this.SuspendLayout();
            // 
            // titlepanel
            // 
            this.titlepanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.titlepanel.Controls.Add(this.FormIcon);
            this.titlepanel.Controls.Add(this.button2);
            this.titlepanel.Controls.Add(this.button3);
            this.titlepanel.Controls.Add(this.titlelabel);
            this.titlepanel.Controls.Add(this.button1);
            this.titlepanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlepanel.Location = new System.Drawing.Point(3, 0);
            this.titlepanel.Name = "titlepanel";
            this.titlepanel.Size = new System.Drawing.Size(278, 22);
            this.titlepanel.TabIndex = 1;
            this.titlepanel.DoubleClick += new System.EventHandler(this.Titlepanel_DoubleClick);
            this.titlepanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseDown);
            this.titlepanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseMove);
            this.titlepanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Titlepanel_MouseUp);
            // 
            // FormIcon
            // 
            this.FormIcon.Location = new System.Drawing.Point(4, 2);
            this.FormIcon.Name = "FormIcon";
            this.FormIcon.Size = new System.Drawing.Size(17, 17);
            this.FormIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FormIcon.TabIndex = 5;
            this.FormIcon.TabStop = false;
            this.FormIcon.Visible = false;
            // 
            // titlelabel
            // 
            this.titlelabel.AutoSize = true;
            this.titlelabel.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.titlelabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.titlelabel.Location = new System.Drawing.Point(2, 4);
            this.titlelabel.Name = "titlelabel";
            this.titlelabel.Size = new System.Drawing.Size(0, 14);
            this.titlelabel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 237);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.ActiveColor = System.Drawing.SystemColors.ControlLight;
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.button2.Bold = true;
            this.button2.IconType = DarkControls.Controls.IconType.Max;
            this.button2.InActiveColor = System.Drawing.SystemColors.ControlDark;
            this.button2.Location = new System.Drawing.Point(211, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 14);
            this.button2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button2.TabIndex = 4;
            this.button2.TabStop = false;
            this.button2.Tag = "max";
            this.button2.ToolTipText = null;
            this.button2.Click += new System.EventHandler(this.Titlebutton_Click);
            // 
            // button3
            // 
            this.button3.ActiveColor = System.Drawing.SystemColors.ControlLight;
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.button3.Bold = true;
            this.button3.IconType = DarkControls.Controls.IconType.Min;
            this.button3.InActiveColor = System.Drawing.SystemColors.ControlDark;
            this.button3.Location = new System.Drawing.Point(177, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 14);
            this.button3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button3.TabIndex = 3;
            this.button3.TabStop = false;
            this.button3.Tag = "min";
            this.button3.ToolTipText = null;
            this.button3.Click += new System.EventHandler(this.Titlebutton_Click);
            // 
            // button1
            // 
            this.button1.ActiveColor = System.Drawing.Color.FloralWhite;
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.button1.Bold = true;
            this.button1.IconType = DarkControls.Controls.IconType.close;
            this.button1.InActiveColor = System.Drawing.SystemColors.ControlDark;
            this.button1.Location = new System.Drawing.Point(245, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 14);
            this.button1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "close";
            this.button1.ToolTipText = "";
            this.button1.Click += new System.EventHandler(this.Titlebutton_Click);
            // 
            // BForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlepanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.titlepanel.ResumeLayout(false);
            this.titlepanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private  DarkControls.Controls.IconButton button2;
        private DarkControls.Controls.IconButton button3;
        private IconButton button1;
        private System.Windows.Forms.Panel titlepanel;
        private System.Windows.Forms.Label titlelabel;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox FormIcon;
    }
}