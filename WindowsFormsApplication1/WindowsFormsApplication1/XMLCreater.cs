﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WindowsFormsApplication1
{
    static class XMLCreater
    {
        

        public static List<string> sellwish = new List<string>() {"0","0","0"};
        public static List<string> sellwishname = new List<string>() { "1", "2", "3" };

        public static List<string> selldirectmenge = new List<string>() { "0", "0", "0" };
        public static List<string> selldirektkonventional = new List<string>() { "0", "0", "0" };
        public static List<string> selldirektpreis = new List<string>() { "0", "0", "0" };


        public static XmlDocument Create()
        {
            try
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
                element2.SetAttribute("type", "no");
                element2.SetAttribute("losequantity", "0");
                element2.SetAttribute("delay", "0");
                element1.AppendChild(element2);

                XmlElement element3 = doc.CreateElement(string.Empty, "sellwish", string.Empty);
                for (int i = 0; i < sellwish.Count; i++)
                {
                    XmlElement e = doc.CreateElement(string.Empty, "item", string.Empty);
                    e.SetAttribute("article", sellwishname[i]);
                    e.SetAttribute("quantity", sellwish[i]);
                    element3.AppendChild(e);
                }

                element1.AppendChild(element3);

                XmlElement element4 = doc.CreateElement(string.Empty, "selldirect", string.Empty);
                for (int i = 0; i < 3; i++)
                {
                    XmlElement e = doc.CreateElement(string.Empty, "item", string.Empty);
                    e.SetAttribute("article", sellwishname[i]);
                    e.SetAttribute("quantity", selldirectmenge[i]);
                    e.SetAttribute("price", selldirektpreis[i]);
                    e.SetAttribute("penalty", selldirektkonventional[i]);
                    element4.AppendChild(e);
                }
                element1.AppendChild(element4);

                XmlElement element5 = doc.CreateElement(string.Empty, "orderlist", string.Empty);
                for (int i = 0; i < Database.neuebestellungen.Count; i++)
                {
                    XmlElement e = doc.CreateElement(string.Empty, "order", string.Empty);
                    e.SetAttribute("article", Database.neuebestellungen[i].article);
                    e.SetAttribute("quantity", Database.neuebestellungen[i].amount);
                    e.SetAttribute("modus", Database.neuebestellungen[i].modus);

                    element5.AppendChild(e);
                }

                element1.AppendChild(element5);

                XmlElement element6 = doc.CreateElement(string.Empty, "productionlist", string.Empty);
                for (int i = 0; i < Database.fertigungsauftraege.Count; i++)
                {
                    if(Database.fertigungsauftraege[i].amount !="")
                    {
                    if (Convert.ToInt32(Database.fertigungsauftraege[i].amount) > 0)
                    {
                        XmlElement e = doc.CreateElement(string.Empty, "production", string.Empty);
                        e.SetAttribute("article", Database.fertigungsauftraege[i].id);
                        e.SetAttribute("quantity", Database.fertigungsauftraege[i].amount);
                        element6.AppendChild(e);
                    }
                    }
                    
                }

                element1.AppendChild(element6);

                XmlElement element7 = doc.CreateElement(string.Empty, "workingtimelist", string.Empty);
                for (int i = 0; i < Database.arbeitsplaetze.Count; i++)
                {
                    XmlElement e = doc.CreateElement(string.Empty, "workingtime", string.Empty);
                    e.SetAttribute("station", Database.arbeitsplaetze[i].station);
                    e.SetAttribute("shift", Database.arbeitsplaetze[i].shift);
                    if (Convert.ToInt32(Database.arbeitsplaetze[i].overtime) < 0)
                    {
                        e.SetAttribute("overtime", "0");
                    }
                    else
                    {
                        if (Database.arbeitsplaetze[i].shift == "3")
                        {
                            e.SetAttribute("overtime", "0");
                        }
                        else
                        {
                            if (Convert.ToInt32(Database.arbeitsplaetze[i].overtime) >= 1200)
                            {
                                e.SetAttribute("overtime", "1200");
                            }
                            else
                            {
                                e.SetAttribute("overtime", Database.arbeitsplaetze[i].overtime);
                            }
                        }
                    }


                    element7.AppendChild(e);
                }

                element1.AppendChild(element7);

                

                return doc;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
