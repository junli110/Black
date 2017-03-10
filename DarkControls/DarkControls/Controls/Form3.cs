using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            bGridViewContorl1.AutoGenerateColumns = true;
            bGridViewContorl1.DataSource = null;
        }
    }
}
