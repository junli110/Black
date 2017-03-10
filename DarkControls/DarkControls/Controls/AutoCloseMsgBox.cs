
using DarkControls.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public class AutoCloseMsgBox
    {

       
        
        AutoCloseMsgBox(string text, string caption, int timeout)
        {
            
           
           

                //BMessageBox.Show(text, caption);
            
        }
        public static void Show(string text, string caption, int timeout, bool IsSkinName = false)
        {

            var msgBox = new BAutoMsgForm(text, caption);
            msgBox.timeout = timeout;
            msgBox.ShowDialog();
            
        }
       
       
    }


}
