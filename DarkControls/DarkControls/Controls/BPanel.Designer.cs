namespace DarkControls.Controls
{
    partial class BPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ContainerPanel = new DarkControls.Controls.DPanel();
            this.VBar = new CustomControls.BScrollbar();
            this.SuspendLayout();
            // 
            // ContainerPanel
            // 
            //this.ContainerPanel.AutoSize = true;
            this.ContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.ContainerPanel.Name = "ContainerPanel";
            this.ContainerPanel.Size = new System.Drawing.Size(133, 150);
            this.ContainerPanel.TabIndex = 0;
            // 
            // VBar
            // 
            this.VBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.VBar.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.VBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.VBar.IsVScroll = true;
            this.VBar.LargeChange = 10;
            this.VBar.Location = new System.Drawing.Point(133, 0);
            this.VBar.Maximum = 100;
            this.VBar.Minimum = 0;
            this.VBar.MinimumSize = new System.Drawing.Size(17, 42);
            this.VBar.Name = "VBar";
            this.VBar.Size = new System.Drawing.Size(17, 150);
            this.VBar.SmallChange = 1;
            this.VBar.TabIndex = 1;
            this.VBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.VBar.Value = 0;
            // 
            // BPanel
            // 
            this.Controls.Add(this.ContainerPanel);
            this.Controls.Add(this.VBar);
            this.Name = "BPanel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DPanel ContainerPanel;
        private CustomControls.BScrollbar VBar;
    }
}
