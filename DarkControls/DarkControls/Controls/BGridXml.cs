
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DarkControls.Controls
{
    public  class BGridXml
    {
        
       public static string  path="datagridview.xml";
       private static XmlDocument xmlDoc;
       private static void loadDoc(string XmlFileName)
       {
            if (xmlDoc == null)
            {
                xmlDoc = new XmlDocument();
                if (!File.Exists(path))
                {
                    if (!CreateXmlDocument(path, "root", "1.0", "utf-8", null)) return;

                }
                
                xmlDoc.Load(path);
            }
        }
       public static void SaveOrder(BGridViewContorl dgv)
       {
           try
           {
               if (dgv != null && dgv.Columns.Count > 1 && !string.IsNullOrWhiteSpace(dgv.AAXmlFileName))
               {

                   loadDoc(dgv.AAXmlFileName);
                   var dvroot = xmlDoc.SelectSingleNode("/root/" + dgv.AAXmlFileName);
                    
                   if (dvroot == null)
                   {
                       var root = xmlDoc.SelectSingleNode("/root");
                       var node = xmlDoc.CreateElement(dgv.AAXmlFileName);
                       root.AppendChild(node);
                       dvroot = node;
                   }
                   dvroot.RemoveAll();
                   foreach (DataGridViewColumn c in dgv.Columns)
                   {
                       var node = xmlDoc.CreateElement("Item");
                       XmlAttribute column = xmlDoc.CreateAttribute("column");
                       column.Value = c.DataPropertyName;
                       XmlAttribute index = xmlDoc.CreateAttribute("index");
                       index.Value = c.DisplayIndex.ToString();
                       node.Attributes.Append(column);
                       node.Attributes.Append(index);
                       dvroot.AppendChild(node);
                   }
                   xmlDoc.Save(path);
               }
           }
           catch (Exception ee) {
              
           }
        }

       public static void LoadOrder(BGridViewContorl dgv)
       {
           try
           {
               loadDoc(dgv.AAXmlFileName);
               if (xmlDoc!=null)
               {
                   
                   var items = xmlDoc.SelectNodes("/root/" + dgv.AAXmlFileName + "/Item");
                   if (items.Count == dgv.Columns.Count)
                   {
                       foreach (XmlNode node in items)
                       {
                           foreach (DataGridViewColumn c in dgv.Columns)
                           {
                               if (c.DataPropertyName==node.Attributes["column"].Value)
                                   c.DisplayIndex = Convert.ToInt32(node.Attributes["index"].Value);
                           }
                       }
                   }
               }
           }
           catch (Exception ee)
           {
              
           }
        }
        public static bool CreateXmlDocument(string xmlFileName, string rootNodeName, string version, string encoding, string standalone)
        {
            bool isSuccess = false;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration(version, encoding, standalone);
                XmlNode root = xmlDoc.CreateElement(rootNodeName);
                xmlDoc.AppendChild(xmlDeclaration);
                xmlDoc.AppendChild(root);
                xmlDoc.Save(xmlFileName);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex; //这里可以定义你自己的异常处理
            }
            return isSuccess;
        }
       
    }
}
