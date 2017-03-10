using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControls;

namespace DarkControls.Controls
{
    public partial class BPanel : UserControl
    {
       
        private bool dgvScroll = false;
        public ControlCollection NewControls
        {
            get { return this.ContainerPanel.Controls; }
        }
        public BPanel()
        {
            InitializeComponent();
           
            VBar.MinimumSize = new System.Drawing.Size(0, 0);
           
           
            VBar.Value = 0;
            VBar.ChannelColor = Color.FromArgb(90, 90, 90);
            VBar.ThumbColor = Color.FromArgb(215, 215, 215);
            //VBar.Width = 19;
            this.ContainerPanel.MouseWheel+=BPanel_MouseWheel;
            this.ContainerPanel.Click+=ContainerPanel_Click;
           this.VBar.ValueChanged +=VBar_ValueChanged;
           this.Resize+=BPanel_Resize;
            this.ContainerPanel.Resize+=Contanir_Resize;
            this.Controls.Add(VBar);
            SetScrollBarEx();
        }

        private void ContainerPanel_Click(object sender, EventArgs e)
        {
            this.ContainerPanel.Focus();
        }

       

        private void BPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            int delta = Math.Abs(e.Delta);
            if (e.Delta < 0)
            {
                if (VBar.Value + delta <= VBar.Maximum - VBar.LargeChange)
                    VBar.Value += delta;
                else
                {
                    VBar.Value = VBar.Maximum - VBar.LargeChange;
                }
                VBar_ValueChanged(null, null);
            }
            else if (e.Delta > 0)
            {
                if (VBar.Value - delta >= VBar.Minimum)
                    VBar.Value -= delta;
                else
                {
                    VBar.Value = VBar.Minimum;
                }
                VBar_ValueChanged(null, null);
            }
           
        }

        private void BPanel_Resize(object sender, EventArgs e)
        {
            SetScrollBarEx();
        }
        private void Contanir_Resize(object sender, EventArgs e)
        {
            SetScrollBarEx();
        }
        private void VBar_ValueChanged(object sender, EventArgs e)
         {
            ContainerPanel.Top =- VBar.Value;
            //Application.DoEvents();
           // ContainerPanel.Invalidate();
        }

       
        private void SetScrollBarEx()
        {

            if (this.Height < ContainerPanel.Height)
            {

                VBar.Visible = true;

                //VBar.Location = new Point(this.Width - 1-VBar.Width, 0);

                VBar.Maximum = this.ContainerPanel.Height;
                VBar.Minimum = 0;
                VBar.LargeChange =  this.Height;
                ContainerPanel.Width = this.Width-VBar.Width;
               

            }
            else
            {
                ContainerPanel.Width = this.Width;
                VBar.Visible = false;
            }

            //ContainerPanel.MinimumSize = new Size(this.Width - VBar.Width, this.Height);
           

        }
    }
    public class DPanel : Panel
    {
        public DPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}
