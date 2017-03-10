namespace DarkControls.Controls
{
    partial class FormPanel
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
            this.bPanel1 = new DarkControls.Controls.BPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.bPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bPanel1
            // 
            this.bPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bPanel1.NewControls.Add(this.label1);
            this.bPanel1.Location = new System.Drawing.Point(48, 74);
            this.bPanel1.Name = "bPanel1";
            this.bPanel1.Size = new System.Drawing.Size(200, 176);
            this.bPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 264);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1\r\nfsdlkfjsd\r\nf sa\r\ndf \r\nsa\r\nfd \r\nesa fd\r\n\r\nsaf\r\n\r\nesafd\r\nsa\r\nf\r\nsa\r\nfsa\r\nf\r" +
    "\nsaf\r\nsdf\r\n\r\ndsf\r\nsa\r\nf\r\n";
            // 
            // FormPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bPanel1);
            this.Name = "FormPanel";
            this.Text = "FormPanel";
            this.bPanel1.ResumeLayout(false);
            this.bPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BPanel bPanel1;
        private System.Windows.Forms.Label label1;
    }
}