namespace DarkControls.Controls
{
    partial class BMsgForm
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
            this.bLabel1 = new DarkControls.Controls.BLabel();
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.IconBox);
            this.panel1.Controls.Add(this.bLabel1);
            this.panel1.Size = new System.Drawing.Size(256, 121);
            // 
            // bLabel1
            // 
            this.bLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.bLabel1.Location = new System.Drawing.Point(70, 26);
            this.bLabel1.Name = "bLabel1";
            this.bLabel1.Size = new System.Drawing.Size(152, 34);
            this.bLabel1.TabIndex = 0;
            this.bLabel1.Text = "bLabel1";
            // 
            // IconBox
            // 
            this.IconBox.Location = new System.Drawing.Point(22, 26);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(32, 32);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IconBox.TabIndex = 3;
            this.IconBox.TabStop = false;
            // 
            // BMsgForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 146);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BMsgForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.BMsgForm_Activated);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BLabel bLabel1;
        private System.Windows.Forms.PictureBox IconBox;
    }
}