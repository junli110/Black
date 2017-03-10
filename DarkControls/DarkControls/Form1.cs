using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarkControls.Controls;
namespace DarkControls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btbMsgBox_Click(object sender, EventArgs e)
        {
            BMessageBox.Show("Hello World!", "Title", BMessageBox.MyButtons.YesNo, BMessageBox.MyIcon.Error);
            AutoCloseMsgBox.Show("Hello! 自动关闭", "title", 1000);
        }

        private void bButton1_Click(object sender, EventArgs e)
        {
            var form = new Controls.Form1(); form.Show();
        }
    }
}
