using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomControls;
using System.Runtime.InteropServices;

namespace DarkControls.Controls
{
    public partial class BTreeView : UserControl
    {
        private Font Iconfont;
        public BTreeView()
        {
            InitializeComponent();
            this.treeView.ScrollEvent += treeView_ScrollEvent;
            treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            this.Resize+=BTreeView_Resize;

           
        }

        private void BTreeView_Resize(object sender, EventArgs e)
        {
            VBar.Height = this.Height - 2;
            VBar.Location = new Point(this.DisplayRectangle.Width-1-VBar.Width, 1);
            this.SendToBack();
        }
        private Font GetIconFont()
        {
            if (Iconfont == null)
            {
                var btn = new IconButton();
                Iconfont = btn.GetIconFont(8);
            }
            return Iconfont;
        }
        private void  treeView_ScrollEvent()
        {
            SCROLLINFO info = tvImageListScrollInfo;

             VBar.Value=info.nPos;
        }

       
       
        public SCROLLINFO tvImageListScrollInfo
        {

            get
            {

                SCROLLINFO si = new SCROLLINFO();

                si.cbSize = (uint)Marshal.SizeOf(si);

                si.fMask = (int)(ScrollInfoMask.SIF_DISABLENOSCROLL | ScrollInfoMask.SIF_ALL);

                GetScrollInfo(treeView.Handle, (int)ScrollBarDirection.SB_VERT, ref si);

                return si;

            }

        }
        private void treeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            SetImageListScroll();
        }

        private void treeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            SetImageListScroll();
        }
        private void VBar_Scroll(object sender, EventArgs e)
        {
            SCROLLINFO info = tvImageListScrollInfo;

            info.nPos = VBar.Value;
            SetScrollInfo(treeView.Handle, (int)ScrollBarDirection.SB_VERT, ref info, true);
            PostMessage(treeView.Handle, WM_VSCROLL, MakeLong((short)SB_THUMBTRACK, (short)(info.nPos)), IntPtr.Zero);
        }
        private void SetImageListScroll()
        {

            SCROLLINFO info = tvImageListScrollInfo;

            VBar.Maximum = info.nMax + 1;// +(int)info.nPage;
            VBar.Minimum = info.nMin;
            VBar.LargeChange = (int)info.nPage;
            if (info.nMax > 0)
            {

                int pos = info.nPos ;

                if (pos >= 0)
                {

                    VBar.Value = pos;

                }

            }

            if (VBar.LargeChange >= VBar.Maximum||VBar.LargeChange==0)
            {
                VBar.Visible = false;
            }
            else
            {
                VBar.Visible = true;
            }
            this.SendToBack();
            
        }
       
        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }
        public const int SB_THUMBTRACK = 5;
        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;

        [DllImport("user32.dll", EntryPoint = "GetScrollInfo")]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        [DllImport("user32.dll", EntryPoint = "SetScrollInfo")]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        private void treeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
           // e.Node.ImageIndex = 3;
        }

        private void treeView_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
             Brush textBrush = SystemBrushes.Control;
            Rectangle nodeRect = e.Node.Bounds;
            if (nodeRect.Height == 0 && nodeRect.Width == 0 && nodeRect.X == 0 && nodeRect.Y == 0) return;
            nodeRect.Location = new Point(nodeRect.Location.X-20,nodeRect.Location.Y);
            /*--------- 1. draw expand/collapse icon ---------*/
            Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 5);
            Image expandImg = null;
            if (e.Node.IsExpanded)
               // expandImg = ResourceFont.sanjiaoDown;
                e.Graphics.DrawString(char.ConvertFromUtf32((int)IconType.sanjaoDown), GetIconFont(), textBrush, ptExpand);
            else
            {
                if (e.Node.Nodes.Count >= 1)
                    //expandImg = ResourceFont.snajaoRight;
                    e.Graphics.DrawString(char.ConvertFromUtf32((int)IconType.sanjaoRight), GetIconFont(), textBrush, ptExpand);
            }
            if (expandImg != null)
            {
                //Graphics g = Graphics.FromImage(expandImg);

                //IntPtr imgPtr = g.GetHdc();
                //g.ReleaseHdc();
                //e.Graphics.DrawImage(expandImg, ptExpand);
               
            }

            /*--------- 2. draw node icon ---------*/
            Point ptNodeIcon = new Point(nodeRect.Location.X - 4, nodeRect.Location.Y );
            //Image nodeImg = Image.FromFile(nodePath);
            //g = Graphics.FromImage(nodeImg);
            //imgPtr = g.GetHdc();
            //g.ReleaseHdc();
            if (e.Node.IsSelected)
            {
                if (treeView.ImageList != null && e.Node.SelectedImageIndex >= 0 && treeView.ImageList.Images.Count > e.Node.SelectedImageIndex)
                    e.Graphics.DrawImage(treeView.ImageList.Images[e.Node.SelectedImageIndex], ptNodeIcon);
            }
            else
            {
                if (treeView.ImageList != null && e.Node.ImageIndex >= 0 && treeView.ImageList.Images.Count > e.Node.ImageIndex)
                    e.Graphics.DrawImage(treeView.ImageList.Images[e.Node.ImageIndex], ptNodeIcon);
            }
            /*--------- 3. draw node text ---------*/
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null)
                nodeFont = ((TreeView)sender).Font;
           
            //to highlight the text when selected
            if (e.Node.Equals(treeView.SelectedNode))
            {
                textBrush = SystemBrushes.HotTrack;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(53, 53, 53)), nodeRect.Location.X +14, nodeRect.Location.Y, this.Width - nodeRect.Location.X-14, nodeRect.Height);
            }
            //Inflate to not be cut
            Rectangle textRect = new Rectangle();
            //need to extend node rect
            textRect.Width = nodeRect.Width+40;
            textRect.Y = nodeRect.Y+1;
            textRect.X = nodeRect.X+3;
            textRect.Height = nodeRect.Height;
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush, Rectangle.Inflate(textRect, -12, 0));
    
        }

       
    }
    public class TTreeView : TreeView
    {
        public delegate void ScrollDel();
        public ScrollDel  ScrollEvent;
        public const int WM_VSCROLL = 0x0115;
        public const int WM_MOUSEWHEEL =0x20a;
        public const int WM_ERASEBKGND = 0x0014;
        public TTreeView()
        {
            
        }
        protected override void WndProc(ref Message message)
        {
           
            switch (message.Msg)
            {
                case WM_MOUSEWHEEL:
                    if (ScrollEvent != null) ScrollEvent();
                    break;
            }
            if(WM_ERASEBKGND!=message.Msg)
            base.WndProc(ref message);
           
        }
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        private extern static int SetWindowTheme(IntPtr hWnd, string pszSubAppName,
                                                string pszSubIdList);

        //protected override void CreateHandle()
        //{
        //    base.CreateHandle();
        //    SetWindowTheme(this.Handle, "explorer", null);
        //}
    }
    public struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }
    enum ScrollInfoMask
    {
        SIF_RANGE = 0x1,
        SIF_PAGE = 0x2,
        SIF_POS = 0x4,
        SIF_DISABLENOSCROLL = 0x8,
        SIF_TRACKPOS = 0x10,
        SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
    }
    enum ScrollBarDirection
    {
        SB_HORZ = 0,
        SB_VERT = 1,
        SB_CTL = 2,
        SB_BOTH = 3
    }



    [StructLayout(LayoutKind.Sequential)]
    public struct tagSCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }
    public enum fnBar
    {
        SB_HORZ = 0,
        SB_VERT = 1,
        SB_CTL = 2
    }
    public enum fMask
    {
        SIF_ALL,
        SIF_DISABLENOSCROLL = 0X0010,
        SIF_PAGE = 0X0002,
        SIF_POS = 0X0004,
        SIF_RANGE = 0X0001,
        SIF_TRACKPOS = 0X0008
    }
}
