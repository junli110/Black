using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Diagnostics;

using System.Drawing.Drawing2D;


namespace CustomControls {

   
    public class BScrollbar : UserControl {

        protected Color moChannelColor = Color.Empty;
        

        protected int moLargeChange = 10;
        protected int moSmallChange = 1;
        protected int moMinimum = 0;
        protected int moMaximum = 100;
        protected int moValue = 0;
        private int nClickPoint;

        protected int moThumbTop = 0;

        protected bool moAutoSize = false;

        private bool moThumbDown = false;
        private bool moThumbDragging = false;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChanged = null;
        
        private int GetThumbHeight()
        {
            var length = this.Width;
            if (moIsVScroll)
                length = this.Height;
            int nTrackSize = (length - (UpArrowImageHeight + DownArrowImageHeight));
            float fThumbSize = ((float)LargeChange / (float)Maximum) * nTrackSize;
            int nThumbSize = (int)fThumbSize;

            if (nThumbSize > nTrackSize)
            {
                nThumbSize = nTrackSize;
                fThumbSize = nTrackSize;
            }
            if (nThumbSize < 10)
            {
                nThumbSize = 10;
                fThumbSize = 10;
            }

            return nThumbSize;
        }

        public BScrollbar() {

            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            
            moChannelColor = Color.FromArgb(90, 90, 90);
            moThumbColor = Color.FromArgb(215, 215, 215);
            this.BackColor = moChannelColor;
            moIsVScroll = true;
            this.Width = UpArrowImageWidth;
            base.MinimumSize = new Size(UpArrowImageWidth, UpArrowImageHeight + DownArrowImageHeight + GetThumbHeight());
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("LargeChange")]
        public int LargeChange {
            get { return moLargeChange; }
            set { moLargeChange = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("SmallChange")]
        public int SmallChange {
            get { return moSmallChange; }
            set { moSmallChange = value;
            Invalidate();    
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Minimum")]
        public int Minimum {
            get { return moMinimum; }
            set { moMinimum = value;
            Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Maximum")]
        public int Maximum {
            get { return moMaximum; }
            set { moMaximum = value;
            Invalidate();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("滑块颜色")]
        public Color ThumbColor
        {
            get { return moThumbColor; }
            set { moThumbColor = value; }
        }
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Behavior"), Description("Value")]
        public int Value {
            get { return moValue; }
            set
            {
                moValue = value;
                var length = this.Width;
                if (moIsVScroll)
                    length = this.Height;

                int nTrackSize = (length - (UpArrowImageHeight + DownArrowImageHeight));
                float fThumbSize = ((float)LargeChange / (float)Maximum) * nTrackSize;
                int nThumbSize = (int)fThumbSize;

                if (nThumbSize > nTrackSize)
                {
                    nThumbSize = nTrackSize;
                    fThumbSize = nTrackSize;
                }
                if (nThumbSize < 10)
                {
                    nThumbSize = 10;
                    fThumbSize = 10;
                }

                //figure out value
                int nPixelRange = nTrackSize - nThumbSize;
                int nRealRange = (Maximum - Minimum) - LargeChange;
                float fPerc = 0.0f;
                if (nRealRange != 0)
                {
                    fPerc = (float)moValue / (float)nRealRange;

                }

                float fTop = fPerc * nPixelRange;
                moThumbTop = (int)fTop;


                Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("Channel Color")]
        public Color ChannelColor
        {
            get { return moChannelColor; }
            set { moChannelColor = value; }
        }

       

       
        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), DefaultValue(false), Category("Skin"), Description("是否是竖直滚动条")]
        public bool IsVScroll
        {
            get { return moIsVScroll; }
            set { moIsVScroll = value; }
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            if (moIsVScroll)
            {
                //draw channel
                e.Graphics.FillRectangle(new SolidBrush(moChannelColor), new Rectangle(0, 0, this.Width, (this.Height)));

                //draw thumb
                int nTrackHeight = (this.Height - (UpArrowImageHeight + DownArrowImageHeight));
                float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < 10)
                {
                    nThumbHeight = 10;
                    fThumbHeight = 10;
                }



                int nTop = moThumbTop;
                nTop += UpArrowImageHeight;


                //draw 滑块
                Rectangle rect = new Rectangle(1, nTop, this.Width - 2, nThumbHeight);

                e.Graphics.FillPath(new SolidBrush(moThumbColor), GetRoundRectangle(new Rectangle(4, nTop, this.Width - 9, (int)fThumbHeight), 3));
                e.Graphics.DrawPath(new Pen(moThumbColor), GetRoundRectangle(new Rectangle(4, nTop, this.Width - 9, (int)fThumbHeight), 3));



                //draw bottom

                e.Graphics.FillPolygon(new SolidBrush(moThumbColor), new Point[] { new Point(this.Width / 2, 5), new Point(this.Width / 2 + 4, 10), new Point(this.Width / 2 - 4, 10) });
                e.Graphics.FillPolygon(new SolidBrush(moThumbColor), new Point[] { new Point(this.Width / 2, this.Height - 5), new Point(this.Width / 2 + 4, this.Height - 10), new Point(this.Width / 2 - 4, this.Height - 10) });
            }
            else {
                //draw channel
                e.Graphics.FillRectangle(new SolidBrush(moChannelColor), new Rectangle(0, 0, this.Width, (this.Height)));

                //draw thumb
                int nTrackWidth = (this.Width - (UpArrowImageWidth + DownArrowImageWidth));
                float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
                int nThumbWidth = (int)fThumbWidth;

                if (nThumbWidth > nTrackWidth)
                {
                    nThumbWidth = nTrackWidth;
                    fThumbWidth = nTrackWidth;
                }
                if (nThumbWidth < 10)
                {
                    nThumbWidth = 10;
                    fThumbWidth = 10;
                }



                int nTop = moThumbTop;
                nTop += UpArrowImageWidth;


                //draw 滑块
                Rectangle rect = new Rectangle(nTop, 0, this.Width - 2, nThumbWidth);

                e.Graphics.FillPath(new SolidBrush(moThumbColor), GetRoundRectangle(new Rectangle(nTop, 4,  (int)fThumbWidth,this.Height-9), 3));
                e.Graphics.DrawPath(new Pen(moThumbColor), GetRoundRectangle(new Rectangle(nTop, 4, (int)fThumbWidth, this.Height - 9), 3));



                //draw bottom

                e.Graphics.FillPolygon(new SolidBrush(moThumbColor), new Point[] { new Point(5, this.Height / 2), new Point(10, this.Height / 2 + 4), new Point(10,this.Height / 2 - 4) });
                e.Graphics.FillPolygon(new SolidBrush(moThumbColor), new Point[] { new Point( this.Width - 5,this.Height / 2), new Point( this.Width - 10,this.Height / 2 + 4), new Point(this.Width - 10,this.Height / 2 - 4) });
            
            
            
            }
        }

        public override bool AutoSize {
            get {
                return base.AutoSize;
            }
            set {
                base.AutoSize = value;
                if (base.AutoSize) {
                    this.Width = UpArrowImageWidth;
                }
            }
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // CustomScrollbar
            // 
            this.Name = "CustomScrollbar";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CustomScrollbar_MouseUp);
            this.Resize+=BScrollbar_Resize;
            this.ResumeLayout(false);

        }

        private void BScrollbar_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

      

        private void CustomScrollbar_MouseDown(object sender, MouseEventArgs e) {
            Point ptPoint = this.PointToClient(Cursor.Position);
           

            if (moIsVScroll)
            {
                int nTrackHeight = (this.Height - (UpArrowImageHeight + DownArrowImageHeight));

                float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
                int nThumbHeight = (int)fThumbHeight;

                if (nThumbHeight > nTrackHeight)
                {
                    nThumbHeight = nTrackHeight;
                    fThumbHeight = nTrackHeight;
                }
                if (nThumbHeight < 10)
                {
                    nThumbHeight = 10;
                    fThumbHeight = 10;
                }

                int nTop = moThumbTop;
                nTop += UpArrowImageHeight;
                Rectangle thumbrect = new Rectangle(new Point(2, nTop), new Size(this.Width - 4, nThumbHeight));

                if (thumbrect.Contains(ptPoint))
                {

                    //hit the thumb
                    nClickPoint = (ptPoint.Y - nTop);
                    //MessageBox.Show(Convert.ToString((ptPoint.Y - nTop)));
                    this.moThumbDown = true;
                }

                Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(UpArrowImageWidth, UpArrowImageHeight));
               
                if (uparrowrect.Contains(ptPoint))
                {
                   
                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackHeight - nThumbHeight);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbTop - SmallChange * nPixelRange / nRealRange) < 0)
                                moThumbTop = 0;
                            else
                                moThumbTop -= SmallChange * nPixelRange / nRealRange;

                            //figure out value
                            float fPerc = (float)moThumbTop / (float)nPixelRange;
                            float fValue = fPerc * (Maximum - LargeChange);

                            moValue = (int)fValue;
                            Debug.WriteLine(moValue.ToString());

                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());

                            if (Scroll != null)
                                Scroll(this, new EventArgs());

                            Invalidate();
                        }
                    }
                }

                Rectangle downarrowrect = new Rectangle(new Point(1, UpArrowImageHeight + nTrackHeight), new Size(UpArrowImageWidth, UpArrowImageHeight));
               
                if (downarrowrect.Contains(ptPoint))
                {
                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackHeight - nThumbHeight);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbTop + SmallChange * nPixelRange / nRealRange) > nPixelRange)
                                moThumbTop = nPixelRange;
                            else
                                moThumbTop += SmallChange * nPixelRange / nRealRange;

                            //figure out value
                            float fPerc = (float)moThumbTop / (float)nPixelRange;
                            float fValue = fPerc * (Maximum - LargeChange);

                            moValue = (int)Math.Ceiling(fValue);
                            // moValue++;
                            Debug.WriteLine(moValue.ToString());

                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());

                            if (Scroll != null)
                                Scroll(this, new EventArgs());

                            Invalidate();
                        }
                    }
                }
            }
            else
            {

                int nTrackWidth = (this.Width - (UpArrowImageHeight + DownArrowImageHeight));
                float fThumbWidth = ((float)LargeChange / (float)Maximum) * nTrackWidth;
                int nThumbWidth = (int)fThumbWidth;

                if (nThumbWidth > nTrackWidth)
                {
                    nThumbWidth = nTrackWidth;
                    fThumbWidth = nTrackWidth;
                }
                if (nThumbWidth < 56)
                {
                    nThumbWidth = 56;
                    fThumbWidth = 56;
                }

                int nLeft = moThumbTop;
                nLeft += UpArrowImageHeight;

                Rectangle thumbrect = new Rectangle(new Point(nLeft,2), new Size(nThumbWidth, this.Height - 5));

                if (thumbrect.Contains(ptPoint))
                {

                    //hit the thumb
                    nClickPoint = (ptPoint.X - nLeft);
                    //MessageBox.Show(Convert.ToString((ptPoint.Y - nLeft)));
                    this.moThumbDown = true;
                }

               
               Rectangle uparrowrect = new Rectangle(new Point(1, 0), new Size(UpArrowImageWidth, UpArrowImageHeight));
                
                if (uparrowrect.Contains(ptPoint))
                {

                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackWidth - nThumbWidth);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbTop - SmallChange) < 0)
                                moThumbTop = 0;
                            else
                                moThumbTop -= SmallChange;

                            //figure out value
                            float fPerc = (float)moThumbTop / (float)nPixelRange;
                            float fValue = fPerc * (Maximum - LargeChange);

                            moValue = (int)fValue;
                            Debug.WriteLine(moValue.ToString());

                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());

                            if (Scroll != null)
                                Scroll(this, new EventArgs());

                            Invalidate();
                        }
                    }
                }

               
               Rectangle downarrowrect = new Rectangle(new Point(this.Width - UpArrowImageWidth, 1), new Size(UpArrowImageWidth, UpArrowImageHeight));
                
                if (downarrowrect.Contains(ptPoint))
                {
                    int nRealRange = (Maximum - Minimum) - LargeChange;
                    int nPixelRange = (nTrackWidth - nThumbWidth);
                    if (nRealRange > 0)
                    {
                        if (nPixelRange > 0)
                        {
                            if ((moThumbTop + SmallChange) > nPixelRange)
                                moThumbTop = nPixelRange;
                            else
                                moThumbTop += SmallChange;

                            //figure out value
                            float fPerc = (float)moThumbTop / (float)nPixelRange;
                            float fValue = fPerc * (Maximum - LargeChange);

                            moValue = (int)Math.Ceiling(fValue);
                            // moValue++;
                            Debug.WriteLine(moValue.ToString());

                            if (ValueChanged != null)
                                ValueChanged(this, new EventArgs());

                            if (Scroll != null)
                                Scroll(this, new EventArgs());

                            Invalidate();
                        }
                    }
                }
            }
        }

        private void CustomScrollbar_MouseUp(object sender, MouseEventArgs e) {
            this.moThumbDown = false;
            this.moThumbDragging = false;
        }

        private void MoveThumb(int y) {
            int nRealRange = Maximum - Minimum;
            int nTrackHeight = ((moIsVScroll? this.Height:this.Width) - (UpArrowImageHeight + DownArrowImageHeight));
            float fThumbHeight = ((float)LargeChange / (float)Maximum) * nTrackHeight;
            int nThumbHeight = (int)fThumbHeight;

            if (nThumbHeight > nTrackHeight) {
                nThumbHeight = nTrackHeight;
                fThumbHeight = nTrackHeight;
            }
            if (nThumbHeight < 10) {
                nThumbHeight = 10;
                fThumbHeight = 10;
            }

            int nSpot = nClickPoint;

            int nPixelRange = (nTrackHeight - nThumbHeight);
            if (moThumbDown && nRealRange > 0) {
                if (nPixelRange > 0) {
                    int nNewThumbTop = y - (UpArrowImageHeight+nSpot);
                    
                    if(nNewThumbTop<0)
                    {
                        moThumbTop = nNewThumbTop = 0;
                    }
                    else if(nNewThumbTop > nPixelRange)
                    {
                        moThumbTop = nNewThumbTop = nPixelRange;
                    }
                    else {
                        moThumbTop = y - (UpArrowImageHeight + nSpot);
                    }
                   
                    //figure out value
                    float fPerc = (float)moThumbTop / (float)nPixelRange;
                    float fValue = fPerc * (Maximum-LargeChange);
                    moValue = (int)fValue;
                    Debug.WriteLine(moValue.ToString());

                    Application.DoEvents();

                    Invalidate();
                }
            }
        }

        private void CustomScrollbar_MouseMove(object sender, MouseEventArgs e) {
            if(moThumbDown == true)
            {
                this.moThumbDragging = true;
            }
            if (moIsVScroll)
            {
                if (this.moThumbDragging)
                {

                    MoveThumb(e.Y);
                }
            }
            else
            {
                if (this.moThumbDragging)
                {

                    MoveThumb(e.X);
                }
            }

            if(ValueChanged != null)
                ValueChanged(this, new EventArgs());

            if(Scroll != null)
                Scroll(this, new EventArgs());
        }
       
        /// <summary>  
        /// 根据普通矩形得到圆角矩形的路径  
        /// </summary>  
        /// <param name="rectangle">原始矩形</param>  
        /// <param name="r">半径</param>  
        /// <returns>图形路径</returns>  
        private GraphicsPath GetRoundRectangle(Rectangle rect, int cornerRadius)
        {
            GraphicsPath roundedRect = new GraphicsPath();
            roundedRect.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            roundedRect.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            roundedRect.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
            roundedRect.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            roundedRect.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
            roundedRect.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            roundedRect.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
            roundedRect.CloseFigure();
            return roundedRect;
        }


        public Color moThumbColor;

        public bool moIsVScroll;

        public int UpArrowImageHeight = 15;
        private int UpArrowImageWidth = 15;

        public int DownArrowImageHeight = 15;

        public int ThumbWidth = 15;

        public int DownArrowImageWidth = 15;
    
    }
}