using CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public class BGridView:DataGridView
    {
        private BScrollbar HBar;
        private BScrollbar VBar;
        public Panel panel;
        public Panel panelBotton;
        public Panel panelRight;
        public Panel panelFill;
        private bool init = true;
        private Control firstParent;
        public BGridView()
        {

            
            panel = new Panel();
            panel.Dock = DockStyle.Fill;
            panelBotton = new Panel();
            panelBotton.Dock = DockStyle.Bottom;
            panelRight = new Panel();
            panelRight.Dock = DockStyle.Right;
            panelRight.Width = 15;
            panelBotton.Height = 15;
            panelFill = new Panel();
            panelFill.Dock = DockStyle.Fill;
            //panelFill.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);

            HBar = new BScrollbar();
            VBar = new BScrollbar();
            HBar.IsVScroll = false;
            HBar.Dock = DockStyle.Bottom;
            HBar.MinimumSize = new System.Drawing.Size(20, 0);
            HBar.Height = 15;
            HBar.Value = 0;
          
            VBar.IsVScroll = true;
            VBar.Dock = DockStyle.Right;
            VBar.Width = 15;
            VBar.Value = 0;
            VBar.ChannelColor = HBar.ChannelColor = Color.FromArgb(90, 90, 90);
            VBar.ThumbColor = HBar.ThumbColor = Color.FromArgb(215,215,215);
            
            panelBotton.Controls.Add(HBar);
            panelRight.Controls.Add(VBar);
            //panel.Controls.Add(this);
            VBar.Scroll+=VBar_Scroll;
            HBar.Scroll +=HBar_Scroll;
            this.MouseWheel +=BGridView_MouseWheel;
            this.DataBindingComplete+=BGridView_DataBindingComplete;
            
            this.ParentChanged+=BGridView_ParentChanged;
           
            this.Resize+=BGridView_Resize;
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
            //dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            //dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(15,58,93);
            this.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.RowTemplate.Height = 23;
            this.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ShowCellToolTips = false;
            this.ShowEditingIcon = false;
            this.Size = new System.Drawing.Size(150, 150);
            this.MultiSelect = false;

            base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

        }

      

        private void BGridView_ParentChanged(object sender, EventArgs e)
        {
            if (this.Parent != null && firstParent == null)
            {

                firstParent = this.Parent;
                if (firstParent.Controls.Contains(this))
                {
                    
                    firstParent.Controls.Remove(this);
                    this.Dock = DockStyle.Fill;
                    panelFill.Controls.Add(this);
                    
                   
                    panel.Controls.Add(panelBotton);
                    panel.Controls.Add(panelRight);
                    panel.Controls.Add(panelFill);
                   
                
                    firstParent.Controls.Add(panel);
                    //firstParent.Controls.SetChildIndex(panel, this.TabIndex);

                }
            }
        }

        private void BGridView_Resize(object sender, EventArgs e)
        {
           
            setVScrollbarShow();
            computBars();
           
           
        }

        private void BGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
            setVScrollbarShow();
            computBars();
        }

        private void BGridView_MouseWheel(object sender, MouseEventArgs e)
        {
            if (VBar.Value - e.Delta / 100 > VBar.Maximum - VBar.LargeChange)
            {
                VBar.Value = VBar.Maximum - VBar.LargeChange;
            }
            else if (VBar.Value - e.Delta / 100 < 0)
            {
                VBar.Value = 0;
            }
            else
            {
                VBar.Value -= e.Delta / 100;
            }
            this.FirstDisplayedScrollingRowIndex = VBar.Value < 0 ? 0 : VBar.Value;
            Invalidate();
            Application.DoEvents();
        }

        private void VBar_Scroll(object sender, EventArgs e)
        {
            this.FirstDisplayedScrollingRowIndex = VBar.Value < 0 ? 0 : VBar.Value;
            Invalidate();
            Application.DoEvents();
        }

        private void HBar_Scroll(object sender, EventArgs e)
        {
            this.HorizontalScrollingOffset = HBar.Value;
            Application.DoEvents();
        }
        private void computBars()
        {
            VBar.LargeChange = this.DisplayedRowCount(false)-1;

            VBar.Maximum = this.Rows.Count+1 ;
            VBar.Value = this.FirstDisplayedScrollingRowIndex;

            HBar.LargeChange = this.DisplayRectangle.Width-14;

            HBar.Maximum = realWidth();
            HBar.Value = this.HorizontalScrollingOffset;
        }
        public void setVScrollbarShow()
        {
            if (this.DisplayedRowCount(false) >= this.Rows.Count)
            {
                if (panelRight.Visible)
                {
                    panelRight.Visible = false;
                   
                    
                }
              
            }
            else
            {
                if (!panelRight.Visible)
                {
                    panelRight.Visible = true;
                   
                    
                }
              
            }
            if (this.DisplayRectangle.Width > realWidth())
            {
                if (panelBotton.Visible)
                {
                    panelBotton.Visible = false;
                    
                }
              
            }
            else
            {
                if (!panelBotton.Visible)
                {
                    panelBotton.Visible = true;
                    
                }
                //panelFill.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
               // panelBotton.BringToFront();
                
            }
            //this.SendToBack();
        }
        private int realWidth()
        {
            int with = 0;
            foreach (DataGridViewColumn c in this.Columns)
            {
                with += c.Width;
            }
            return with;
        }
    }
}
