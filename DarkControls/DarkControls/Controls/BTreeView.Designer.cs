namespace DarkControls.Controls
{
    partial class BTreeView
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
            this.VBar = new CustomControls.BScrollbar();
            this.treeView = new DarkControls.Controls.TTreeView();
            this.SuspendLayout();
            // 
            // VBar
            // 
            this.VBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.VBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.VBar.ChannelColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.VBar.IsVScroll = true;
            this.VBar.LargeChange = 10;
            this.VBar.Location = new System.Drawing.Point(130, 1);
            this.VBar.Maximum = 100;
            this.VBar.Minimum = 0;
            this.VBar.MinimumSize = new System.Drawing.Size(15, 40);
            this.VBar.Name = "VBar";
            this.VBar.Size = new System.Drawing.Size(19, 148);
            this.VBar.SmallChange = 1;
            this.VBar.TabIndex = 1;
            this.VBar.ThumbColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(215)))), ((int)(((byte)(215)))));
            this.VBar.Value = 0;
            this.VBar.Scroll += new System.EventHandler(this.VBar_Scroll);
            // 
            // treeView
            // 
            this.treeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.treeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.treeView.FullRowSelect = true;
            this.treeView.Indent = 15;
            this.treeView.ItemHeight = 20;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.ShowLines = false;
            this.treeView.Size = new System.Drawing.Size(150, 150);
            this.treeView.TabIndex = 0;
            this.treeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterCollapse);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterExpand);
            this.treeView.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView_DrawNode);
            // 
            // BTreeView
            // 
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.VBar);
            this.Controls.Add(this.treeView);
            this.Name = "BTreeView";
            this.ResumeLayout(false);

        }

        #endregion

        public TTreeView treeView;
        public CustomControls.BScrollbar VBar;
    }
}
