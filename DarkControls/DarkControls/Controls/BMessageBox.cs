using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkControls.Controls
{
    public partial class BMessageBox : Form
    {
       
      
       
        public enum MyIcon
        {
            Error,
            Explorer,
            Find,
            Information,
            Mail,
            Media,
            Print,
            Question,
            RecycleBinEmpty,
            RecycleBinFull,
            Stop,
            User,
            Warning
        }
        public enum MessageBeepType
        {
            Default = -1,
            Ok = 0x00000000,
            Error = 0x00000010,
            Question = 0x00000020,
            Warning = 0x00000030,
            Information = 0x00000040
        }
        public enum MyButtons
        {
            AbortRetryIgnore,
            OK,
            OKCancel,
            RetryCancel,
            YesNo,
            YesNoCancel
        }

        /// <summary>
        /// Title: Text to display in the title bar of the messagebox.
        /// </summary>
        static public DialogResult Show(string Message)
        {

            var msgBox = new BMsgForm(Message, "");
            
            msgBox.ShowDialog();
            return msgBox.CYReturnButton;
        }

        /// <summary>
        /// Title: Text to display in the title bar of the messagebox.
        /// </summary>
        static public DialogResult Show(string Message, string Title)
        {
           
            var msgBox = new BMsgForm(Message, Title);
           
            msgBox.ShowDialog();
            return msgBox.CYReturnButton;
        }

        /// <summary>
        /// MButtons: Display MyButtons on the message box.
        /// </summary>
        static public DialogResult Show(string Message, string Title, MyButtons MButtons)
        {
            var msgBox = new BMsgForm(Message, Title, MButtons);
            
            msgBox.ShowDialog();
            return msgBox.CYReturnButton;
        }

        /// <summary>
        /// MIcon: Display MyIcon on the message box.
        /// </summary>
        static public DialogResult Show(string Message, string Title, MyButtons MButtons, MyIcon MIcon)
        {
            var msgBox = new BMsgForm(Message, Title, MButtons, MIcon);
            
            msgBox.ShowDialog();
            return msgBox.CYReturnButton;
        }

       
    }
}
