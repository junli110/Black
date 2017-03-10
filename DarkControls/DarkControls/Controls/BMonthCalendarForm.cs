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
    public partial class BMonthCalendarForm : Form
    {
        public delegate void DateChangeDel(DateTime date);
        public DateChangeDel DateChange;
        public BMonthCalendarForm()
        {
            InitializeComponent();
        }

        private void bMonthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (DateChange != null) {
                DateChange(bMonthCalendar1.SelectionStart);
               
            }
        }

        private void bMonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.Hide();
        }
    }
}
