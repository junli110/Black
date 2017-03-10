using CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public class BGridViewContorl:DataGridView
    {
        public BScrollbar HBar;
        public BScrollbar VBar;
        
        private bool init = true;
        private Control firstParent;
        private int _displayRowCount = 0;
        private bool dgvScroll;
        private int _displayWidth = 0;
        public string AAXmlFileName{get;set;}
        public BGridViewContorl()
            : base()
        {

          
            HBar = new BScrollbar();
            VBar = new BScrollbar();
            HBar.IsVScroll = false;
            //HBar.Dock = DockStyle.Bottom;
            HBar.MinimumSize = new System.Drawing.Size(0, 0);
            VBar.MinimumSize = new System.Drawing.Size(0, 0);
            HBar.Height = 17;
            HBar.Value = 0;
          
            VBar.IsVScroll = true;
            //VBar.Dock = DockStyle.Right;
            //VBar.Anchor = AnchorStyles.Right;
            VBar.Width = 17;
            VBar.Value = 0;
            VBar.ChannelColor = HBar.ChannelColor = Color.FromArgb(90, 90, 90);
            VBar.ThumbColor = HBar.ThumbColor = Color.FromArgb(215,215,215);
           // VBar.Margin = new Padding(0, 0, -18, 0);
            this.Controls.Add(HBar);
            this.Controls.Add(VBar);


            CheckForIllegalCrossThreadCalls = false;
            this.ScrollBars = ScrollBars.Both;
            this.AutoGenerateColumns = false;
            this.Dock = DockStyle.Fill;
            // 
            // dataGridView1
            // 
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToResizeRows = false;
            this.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 20;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "dataGridView1";
            this.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            //dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(15,58,93);
            this.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.RowTemplate.Height = 23;
            //this.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowCellToolTips = false;
            this.ShowEditingIcon = false;
            this.Size = new System.Drawing.Size(150, 150);
            this.MultiSelect = false;

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
             this.HorizontalScrollBar.VisibleChanged += new EventHandler(ScrollBar_VisibleChanged);

            this.VerticalScrollBar.VisibleChanged += new EventHandler(ScrollBar_VisibleChanged);

            this.SizeChanged += new EventHandler(ScrollBar_VisibleChanged);

            this.VBar.ValueChanged += new EventHandler(VScrollBarEx_ValueChanged);

            HBar.ValueChanged += new EventHandler(HScrollBarEx_ValueChanged);

            this.Scroll += new ScrollEventHandler(DataGridViewEx_Scroll);

            this.ColumnHeadersHeightChanged += new EventHandler(ScrollBar_VisibleChanged);

            this.ColumnWidthChanged += new DataGridViewColumnEventHandler(ScrollBar_VisibleChanged);

            this.RowHeadersWidthChanged += new EventHandler(ScrollBar_VisibleChanged);

            this.RowHeightChanged += new DataGridViewRowEventHandler(ScrollBar_VisibleChanged);

            this.RowsAdded += new DataGridViewRowsAddedEventHandler(ScrollBar_VisibleChanged);
            
            this.RowsRemoved += new DataGridViewRowsRemovedEventHandler(ScrollBar_VisibleChanged);

            this.ColumnAdded += new DataGridViewColumnEventHandler(ScrollBar_VisibleChanged);
            //this.ColumnAdded+=BGridViewContorl_ColumnAdded;
            this.ColumnRemoved += new DataGridViewColumnEventHandler(ScrollBar_VisibleChanged);

            this.DataSourceChanged += new EventHandler(ScrollBar_VisibleChanged);
            this.ColumnDisplayIndexChanged+=BGridViewContorl_ColumnDisplayIndexChanged;
            this.RowPostPaint+=BGridViewContorl_RowPostPaint;
            this.DataBindingComplete+=BGridViewContorl_DataBindingComplete;
            SetScrollBarEx();
        }

        private void BGridViewContorl_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            BGridXml.LoadOrder(this);
            if (this.RowHeadersVisible)
            {
                if (this.Rows.Count > 100)
                {
                    this.RowHeadersWidth = 45;
                }
                else
                {
                    this.RowHeadersWidth = 30;
                }
            }
        }

        private void BGridViewContorl_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (this.RowHeadersVisible)
            {
                var grid = sender as DataGridView;
                var rowIdx = (e.RowIndex + 1).ToString();

                var centerFormat = new StringFormat()
                {
                    // right alignment might actually make more sense for numbers  
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
        }

        private void BGridViewContorl_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            BGridXml.LoadOrder(this);
        }

        private void BGridViewContorl_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            BGridXml.SaveOrder(this);
        }

      

        //
        private void VScrollBarEx_ValueChanged(object sender, EventArgs e)

        {

            if (!this.dgvScroll)

            {

                this.FirstDisplayedScrollingRowIndex = VBar.Value;

                Application.DoEvents();

            }

        }

        private void HScrollBarEx_ValueChanged(object sender, EventArgs e)

        {

            if (!this.dgvScroll)

            {

                this.HorizontalScrollingOffset = HBar.Value;

                GetDisplayWidth();

                Application.DoEvents();

            }

        }

        private void DataGridViewEx_Scroll(object sender, ScrollEventArgs e)

        {

            this.dgvScroll = true;

            if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)

            {

                VBar.Value = this.FirstDisplayedScrollingRowIndex;

            }

            else

            {

                HBar.Value = this.HorizontalScrollingOffset;

            }

            this.dgvScroll = false;

        }

        private void ScrollBar_VisibleChanged(object sender, EventArgs e)

        {
            //BGridXml.LoadOrder(this);
            SetScrollBarEx();

        }

        private void SetScrollBarEx()

        {

            if (this.VerticalScrollBar.Visible)

            {

                VBar.Visible = true;

                VBar.Location = new Point(this.DisplayRectangle.Width-1, 0);

                this.VerticalScrollBar.SendToBack();

                VBar.Height = this.DisplayRectangle.Height;
                VBar.Width = 17;
                GetDisplayRowCount();

            }

            else

            {

                VBar.Visible = false;

            }

            if (this.HorizontalScrollBar.Visible)

            {

               HBar.Visible = true;

                HBar.Location = new Point(0, this.DisplayRectangle.Height-1);

                this.HorizontalScrollBar.SendToBack();

                HBar.Width = this.DisplayRectangle.Width ;
                HBar.Height = 17;

                GetDisplayWidth();

                HBar.Value = this.HorizontalScrollingOffset;

            }

            else

            {

                HBar.Visible = false;

            }

        }

        public int GetDisplayWidth()

        {

            int width = 0;

            for (int i = 0; i < this.Columns.Count; i++)

            {

                width += this.Columns[i].Width;

            }

            _displayWidth = width;

            HBar.Maximum = width;

            HBar.LargeChange = HBar.Maximum / HBar.Width + this.DisplayRectangle.Width - this.RowHeadersWidth;

            return width;

        }

        public int GetDisplayRowCount()

        {

            int j = 0;

           int height = 0;

            int i = this.FirstDisplayedScrollingRowIndex;

            if (i < 0)

            {

                i = 0;

            }

            for (; i < this.Rows.Count; i++)

            {

                height += this.Rows[i].Height;

                if (height < this.DisplayRectangle.Height - this.ColumnHeadersHeight)

                {

                    j++;

                }

                else

                {

                    break;

                }

            }

            j = this.Rows.Count - j;

            if (j < 0)

            {

                j = 0;

            }

            if (_displayRowCount != j)

            {
                VBar.LargeChange = this.DisplayedRowCount(false);
                _displayRowCount = j;

                VBar.Maximum = j + VBar.Minimum + VBar.LargeChange ;

                if (this.FirstDisplayedScrollingRowIndex < 0)

                {

                    VBar.Value = 0;

                }

                else if (this.FirstDisplayedScrollingRowIndex > VBar.Maximum)

                {

                    VBar.Value = VBar.Maximum;

                }

                else

                {

                    VBar.Value = this.FirstDisplayedScrollingRowIndex;

                }

            }

            return j;

        }

   }
    
}
