using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication1
{
    static class XMLCreater
    {
        public static XmlDocument Create()
        {
            XmlDocument doc = new XmlDocument();

            //(1) the xml declaration is recommended, but not mandatory
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            //(2) string.Empty makes cleaner code
            XmlElement element1 = doc.CreateElement(string.Empty, "input", string.Empty);
            doc.AppendChild(element1);

            XmlElement element2 = doc.CreateElement(string.Empty, "qualitycontrol", string.Empty);
            element2.SetAttribute("type","XXXXX");
            element2.SetAttribute("losequantity", "XXXXXXXXx");
            element2.SetAttribute("delay", "XXXXXXXX");
            element1.AppendChild(element2);

            XmlElement element3 = doc.CreateElement(string.Empty, "sellwish", string.Empty);
            for(int i = 0;i<3;i++)
            {
                XmlElement e = doc.CreateElement(string.Empty, "item", string.Empty);
                e.SetAttribute("article", "XXXX");
                e.SetAttribute("quantity", "XXXX");
                element3.AppendChild(e);
            }

            element1.AppendChild(element3);

            XmlElement element4 = doc.CreateElement(string.Empty, "selldirect", string.Empty);
            for (int i = 0; i < 3; i++)
            {
                XmlElement e = doc.CreateElement(string.Empty, "item", string.Empty);
                e.SetAttribute("article", "XXXX");
                e.SetAttribute("quantity", "XXXX");
                e.SetAttribute("price", "XXXX");
                e.SetAttribute("penalty", "XXXX");
                element4.AppendChild(e);
            }
            element1.AppendChild(element4);

            XmlElement element5 = doc.CreateElement(string.Empty, "orderlist", string.Empty);
            for (int i = 0; i < 3; i++)
            {
                XmlElement e = doc.CreateElement(string.Empty, "order", string.Empty);
                e.SetAttribute("article", "XXXX");
                e.SetAttribute("quantity", "XXXX");
                e.SetAttribute("modus", "XXXX");
                
                element5.AppendChild(e);
            }

            element1.AppendChild(element5);

            XmlElement element6 = doc.CreateElement(string.Empty, "productionlist", string.Empty);
            for (int i = 0; i < 3; i++)
            {
                XmlElement e = doc.CreateElement(string.Empty, "production", string.Empty);
                e.SetAttribute("article", "XXXX");
                e.SetAttribute("quantity", "XXXX");
                

                element6.AppendChild(e);
            }

            element1.AppendChild(element6);

            XmlElement element7 = doc.CreateElement(string.Empty, "workingtimelist", string.Empty);
            for (int i = 0; i < 3; i++)
            {
                XmlElement e = doc.CreateElement(string.Empty, "workingtime", string.Empty);
                e.SetAttribute("station", "XXXX");
                e.SetAttribute("shift", "XXXX");
                e.SetAttribute("overtime", "XXXX");


                element7.AppendChild(e);
            }

            element1.AppendChild(element7);

            return doc;
        }
    }
}
