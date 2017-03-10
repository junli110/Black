
using CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DarkControls.Controls
{
    public partial class Form1 : BForm
    {
        public ImageList imageCollection1;
        public Form1()
        {
            InitializeComponent();
            var iconbtn = new IconButton();
            TitleFont = iconbtn.GetIconFont(12);
            Title = char.ConvertFromUtf32((int)IconType.normal);
            treeView1.treeView.Nodes.Clear();
            treeView1.treeView.NodeMouseClick+=treeView_NodeMouseClick;
            
            var treeList1 = treeView1.treeView;
            //treeList1.Nodes.Clear();
            for (int i = 0; i < 6; i++)
            {
                var t = new TreeNode("接点 "+i);
                t.ImageIndex = i;
                treeView1.treeView.Nodes.Add(t);
                for (int j = 0; j < 5; j++)
                {
                    var t1 = new TreeNode("接点 " + j);
                    t1.ImageIndex = j*i;
                    t.Nodes.Add(t1);


                }

            }

            
            imageCollection1 = new ImageList();
            imageCollection1.ColorDepth = ColorDepth.Depth32Bit;
            this.imageCollection1.Images.Add(ResourceFont.普通交易);
            this.imageCollection1.Images.Add(ResourceFont.市价委托);
            this.imageCollection1.Images.Add(ResourceFont.提货申请);
            this.imageCollection1.Images.Add(ResourceFont.查询);
            this.imageCollection1.Images.Add(ResourceFont.买入);
            this.imageCollection1.Images.Add(ResourceFont.卖出);
            this.imageCollection1.Images.Add(ResourceFont.撤单蓝色);
            this.imageCollection1.Images.Add(ResourceFont.撤单灰色);
            this.imageCollection1.Images.Add(ResourceFont.资金持仓蓝色);
            this.imageCollection1.Images.Add(ResourceFont.资金持仓灰色);
            this.imageCollection1.Images.Add(ResourceFont.委托蓝色);
            this.imageCollection1.Images.Add(ResourceFont.委托灰色);
            this.imageCollection1.Images.Add(ResourceFont.成交灰色);
            this.imageCollection1.Images.Add(ResourceFont.成交蓝色);
            this.imageCollection1.Images.Add(ResourceFont.配号查询灰色);
            this.imageCollection1.Images.Add(ResourceFont.配号查询蓝色);
            this.imageCollection1.Images.Add(ResourceFont.中签查询灰色);
            this.imageCollection1.Images.Add(ResourceFont.中签查询蓝色);
            this.imageCollection1.Images.Add(ResourceFont.deposit01);
            this.imageCollection1.Images.Add(ResourceFont.deposit02);
            this.imageCollection1.Images.Add(ResourceFont.withdraw01);
            this.imageCollection1.Images.Add(ResourceFont.withdraw02);
            this.imageCollection1.Images.Add(ResourceFont.出入金);
            this.imageCollection1.Images.Add(ResourceFont.pwd);
            this.imageCollection1.Images.Add(ResourceFont.pwdblue);
            this.imageCollection1.Images.Add(ResourceFont.pwdgray);
            this.imageCollection1.Images.Add(ResourceFont.资金流水blue);
            this.imageCollection1.Images.Add(ResourceFont.资金流水grey);
            this.imageCollection1.Images.Add(ResourceFont.持仓流水blue);
            this.imageCollection1.Images.Add(ResourceFont.持仓流水grey);
            this.imageCollection1.Images.Add(ResourceFont.FSubsciption);
            this.imageCollection1.Images.Add(ResourceFont.SSubscriptionBlue);
            this.imageCollection1.Images.Add(ResourceFont.SSubscriptionGray);
            this.imageCollection1.Images.Add(ResourceFont.SSubLogBlue);
            this.imageCollection1.Images.Add(ResourceFont.SSubLogGray);
            this.imageCollection1.Images.Add(ResourceFont.SSubSerBlue);
            this.imageCollection1.Images.Add(ResourceFont.SSubSerGray);
            treeList1.ImageList = imageCollection1;
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            e.Node.ImageIndex = 0;
            
        }

        


      



    }
   
}
