using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace DarkControls.Controls
{
    public  class IconFont
    {
        public static Font Icons;
        private IconFont()
        {

        }
        public static Font GetFont()
        {
            //if (Icons == null)
            //{
                GCHandle hObject = GCHandle.Alloc(ResourceFont.iconfont, GCHandleType.Pinned);
                IntPtr intptr = hObject.AddrOfPinnedObject();
                System.Drawing.Text.PrivateFontCollection privateFonts = new System.Drawing.Text.PrivateFontCollection();
                privateFonts.AddMemoryFont(intptr, ResourceFont.iconfont.Length);
                Icons = new Font(privateFonts.Families[0], 12); 
            //}
            return Icons;
        }
       
    }
    public static class FromatString
    {
        public static string FromUnicodeString(this string str)
        {
            //最直接的方法Regex.Unescape(str);
            StringBuilder strResult = new StringBuilder();
            if (!string.IsNullOrEmpty(str))
            {
                string[] strlist = str.Replace("\\", "").Split('u');
                try
                {
                    for (int i = 0; i < strlist.Length; i++)
                    {
                        int charCode = Convert.ToInt32(strlist[i], 16);
                        strResult.Append((char)charCode);
                    }
                }
                catch (FormatException ex)
                {
                    return Regex.Unescape(str);
                }
            }
            return strResult.ToString();
        }
    }
}
