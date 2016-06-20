﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public static List<Fertigungsauftrag> au1 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au2 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au3 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au4 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au5 = new List<Fertigungsauftrag>();

        public static string au4name = "-----";
        public static string au5name = "-----";

        public static bool xmleingelesen = false;

        public static void setau1(List<Fertigungsauftrag> l)
        {
            au1 = l;
            Console.WriteLine();
        }

        public static void setau2(List<Fertigungsauftrag> l)
        {
            au2 = l;
            
        }

        public static void setau3(List<Fertigungsauftrag> l)
        {
            au3 = l;
            
        }

        public Form2()
        {
            
            InitializeComponent();
            deutsch();
            chart1.Titles.Add("Gesamter Lagerwert");
            

            chart1.Series.Add("Gesamter Lagerwert");
            chart1.Series.Remove(chart1.Series[0]);
            
            chart1.Series["Gesamter Lagerwert"].ChartType = SeriesChartType.Column;

            



            for (int pointIndex = 0; pointIndex < 1; pointIndex++)
            {
                int gesamtint = Convert.ToInt32(Math.Round(Convert.ToDouble("0")));
                gesamtint = gesamtint;
                chart1.Series["Gesamter Lagerwert"].Points.Add(gesamtint);
            }
            this.BackColor = Color.FromArgb(211, 211, 211); // this should be pink-ish
           /* tabPage1.BackColor = Color.FromArgb(145, 222, 232); // this should be pink-ish
            tabPage2.BackColor = Color.FromArgb(135, 162, 232); // this should be pink-ish
            tabPage3.BackColor = Color.FromArgb(125, 32, 232); // this should be pink-ish
            tabPage4.BackColor = Color.FromArgb(115, 232, 32); // this should be pink-ish
            tabPage5.BackColor = Color.FromArgb(195, 32, 232); // this should be pink-ish
            tabPage6.BackColor = Color.FromArgb(95, 132, 132); // this should be pink-ish
            tabPage7.BackColor = Color.FromArgb(85, 72, 172); // this should be pink-ish
            tabPage8.BackColor = Color.FromArgb(75, 22, 82); // this should be pink-ish
            tabPage9.BackColor = Color.FromArgb(65, 42, 32); // this should be pink-ish
            tabPage10.BackColor = Color.FromArgb(55, 92, 112); // this should be pink-ish
            tabPage11.BackColor = Color.FromArgb(45, 212, 232); // this should be pink-ish
            //tabPage12.BackColor = Color.FromArgb(35, 160, 122); // this should be pink-ish
            tabPage13.BackColor = Color.FromArgb(25, 2, 2); // this should be pink-ish*/
            label1.Text = "Version: 1.5.2.1               MMJ$ Group Ltd.              "+ DateTime.Now.ToString();
            //TODO Bilder einbinden
        //    Image myimage = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\fahrrad2.jpg");
      //      pictureBox1.Image=(myimage);
      //      Image myimage2 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\frau.jpg");
      //      Image myimage3 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\kinder.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            label37.Text = au4name;
            label34.Text = au5name;
       //     Image myimage4 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\MMJ$Logo3.jpg");
      //      pictureBox4.Image = (myimage4);
        //    pictureBox2.Image = myimage4;
          //  pictureBox3.Image = myimage4;
            label41.BackColor = Color.Red;

         /*   Image myimage7 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\background.jpg");
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].BackgroundImage = myimage7;
            }*/
        } 

        private void xMLImportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                string xmlfile = openFileDialog1.FileName;
                FileStream fs = new FileStream(xmlfile, FileMode.Open, FileAccess.Read);
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;
                XmlNodeList xmlnode2;
                xmldoc.Load(fs);

                xmlnode = xmldoc.GetElementsByTagName("inwardstockmovement");
                Database.bestellungen = new List<Inwardstockmovement>();
                for(int i = 0; i < xmlnode[0].ChildNodes.Count-1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Inwardstockmovement a = new Inwardstockmovement(xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[6].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[7].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[8].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[9].Value.ToString()
                        );
                    Database.bestellungen.Add(a);
                }
                dataGridView2.DataSource = Database.bestellungen;
                xmlnode = xmldoc.GetElementsByTagName("warehousestock");
                Database.lager = new List<Warehousestock>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Warehousestock a = new Warehousestock(xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString());
                    if (a.id == "21")
                    {
                        a.lieferfrist = "1,8";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "300";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    
                    if (a.id == "21")
                    {
                        a.lieferfrist = "1,8";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "300";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "22")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "300";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "23")
                    {
                        a.lieferfrist = "1,2";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "300";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "24")
                    {
                        a.lieferfrist = "3,2";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "7";
                        a.verwendungP2 = "7";
                        a.verwendungP3 = "7";
                        a.diskontmenge = "6100";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "25")
                    {
                        a.lieferfrist = "0,9";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "4";
                        a.verwendungP2 = "4";
                        a.verwendungP3 = "4";
                        a.diskontmenge = "3600";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "27")
                    {
                        a.lieferfrist = "0,9";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "1800";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "28")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "4";
                        a.verwendungP2 = "5";
                        a.verwendungP3 = "6";
                        a.diskontmenge = "4500";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "32")
                    {
                        a.lieferfrist = "2,1";
                        a.abweichung = "0,5";
                        a.verwendungP1 = "3";
                        a.verwendungP2 = "3";
                        a.verwendungP3 = "3";
                        a.diskontmenge = "2700";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "33")
                    {
                        a.lieferfrist = "1,9";
                        a.abweichung = "0,5";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "34")
                    {
                        a.lieferfrist = "1,6";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "72";
                        a.diskontmenge = "22000";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "35")
                    {
                        a.lieferfrist = "2,2";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "4";
                        a.verwendungP2 = "4";
                        a.verwendungP3 = "4";
                        a.diskontmenge = "3600";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "36")
                    {
                        a.lieferfrist = "1,2";
                        a.abweichung = "0,1";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "37")
                    {
                        a.lieferfrist = "1,5";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "38")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "300";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "39")
                    {
                        a.lieferfrist = "1,5";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "1800";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "40")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "41")
                    {
                        a.lieferfrist = "0,9";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "42")
                    {
                        a.lieferfrist = "1,2";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "1800";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "43")
                    {
                        a.lieferfrist = "2,0";
                        a.abweichung = "0,5";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "2700";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "44")
                    {
                        a.lieferfrist = "1,0";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "3";
                        a.verwendungP2 = "3";
                        a.verwendungP3 = "3";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "45")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "46")
                    {
                        a.lieferfrist = "0,9";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "47")
                    {
                        a.lieferfrist = "1,1";
                        a.abweichung = "0,1";
                        a.verwendungP1 = "1";
                        a.verwendungP2 = "1";
                        a.verwendungP3 = "1";
                        a.diskontmenge = "900";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "48")
                    {
                        a.lieferfrist = "1,0";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "1800";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "52")
                    {
                        a.lieferfrist = "1,6";
                        a.abweichung = "0,4";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "600";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "53")
                    {
                        a.lieferfrist = "1,6";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "72";
                        a.verwendungP2 = "0";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "22000";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "57")
                    {
                        a.lieferfrist = "1,7";
                        a.abweichung = "0,3";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "600";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "58")
                    {
                        a.lieferfrist = "1,6";
                        a.abweichung = "0,5";
                        a.verwendungP1 = "0";
                        a.verwendungP2 = "72";
                        a.verwendungP3 = "0";
                        a.diskontmenge = "22000";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "59")
                    {
                        a.lieferfrist = "0,7";
                        a.abweichung = "0,2";
                        a.verwendungP1 = "2";
                        a.verwendungP2 = "2";
                        a.verwendungP3 = "2";
                        a.diskontmenge = "1800";
                        a.bruttobedarfjetzt = (Convert.ToDouble(Database.prognosen[0].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext1 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext2 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.bruttobedarfnext3 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].menge) * Convert.ToDouble(a.verwendungP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].menge) * Convert.ToDouble(a.verwendungP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].menge) * Convert.ToDouble(a.verwendungP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.bruttobedarfjetzt)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.bruttobedarfnext1)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToInt32(a.bruttobedarfnext2)).ToString();
                        empfehlungen(a);
                    }
                    Database.lager.Add(a);
                }
                dataGridView22.DataSource = Database.empfehlungen;
                dataGridView1.DataSource = Database.lager;
                //label3.Text = "Gesamter Lagerwert: ";
                String gesamt = xmlnode[0].ChildNodes.Item(xmlnode[0].ChildNodes.Count - 1).InnerText.ToString();
                
                xmlnode = xmldoc.GetElementsByTagName("futureinwardstockmovement");
                Database.zukunftigeEingänge = new List<Futureinwardstockmovement>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Futureinwardstockmovement a = new Futureinwardstockmovement(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString()); ;
                    Database.zukunftigeEingänge.Add(a);
                }
                dataGridView3.DataSource = Database.zukunftigeEingänge;

                xmlnode = xmldoc.GetElementsByTagName("idletimecosts");
                Database.strafkosten = new List<Idletimecosts>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Idletimecosts a = new Idletimecosts(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString()
                        ); ;
                    Database.strafkosten.Add(a);
                }
                dataGridView4.DataSource = Database.strafkosten;

                xmlnode = xmldoc.GetElementsByTagName("waitinglistworkstations");
                Database.workstationswaitinglist = new List<Waitinglistworkstations>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Waitinglistworkstations a = new Waitinglistworkstations(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString()
                        );

                    List<Waitinglist> w = new List<Waitinglist>();
                    foreach (XmlNode node in xmlnode[0].ChildNodes.Item(i))
                    {
                        Waitinglist wa = new Waitinglist(
                       node.Attributes[0].Value.ToString(),
                        node.Attributes[1].Value.ToString(),
                         node.Attributes[2].Value.ToString(),
                          node.Attributes[3].Value.ToString(),
                           node.Attributes[4].Value.ToString(),
                            node.Attributes[5].Value.ToString(),
                             node.Attributes[6].Value.ToString());
                        w.Add(wa);
                    }

                    a.listWaitinglist = w;
                    Database.workstationswaitinglist.Add(a);
                }
                dataGridView5.DataSource = Database.workstationswaitinglist;

                xmlnode = xmldoc.GetElementsByTagName("waitingliststock");
                Database.waitingliststock = new List<Missingpart>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Missingpart a = new Missingpart(
                        //xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString()
                        );
                    a.id = xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString();

                    List<Waitinglist2> w = new List<Waitinglist2>();
                    foreach (XmlNode node in xmlnode[0].ChildNodes.Item(i))
                    {
                        Waitinglist2 wa = new Waitinglist2(
                       node.Attributes[0].Value.ToString(),
                        node.Attributes[1].Value.ToString(),
                         node.Attributes[2].Value.ToString(),
                          node.Attributes[3].Value.ToString(),
                           node.Attributes[4].Value.ToString(),
                            node.Attributes[5].Value.ToString());
                        w.Add(wa);
                    }

                    a.waitinglistlist = w;
                    Database.waitingliststock.Add(a);
                }
                dataGridView6.DataSource = Database.waitingliststock;

                xmlnode = xmldoc.GetElementsByTagName("ordersinwork");
                Database.ordersinwork = new List<Workplace>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Workplace a = new Workplace(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[6].Value.ToString()); ;
                    Database.ordersinwork.Add(a);
                }
                dataGridView7.DataSource = Database.ordersinwork;



                xmlnode = xmldoc.GetElementsByTagName("completedorders");
                Database.orders = new List<Order>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Order a = new Order(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString()
                        );
                    
                    List<Batch> w = new List<Batch>();
                    foreach (XmlNode node in xmlnode[0].ChildNodes.Item(i))
                    {
                        Batch wa = new Batch(
                       node.Attributes[0].Value.ToString(),
                        node.Attributes[1].Value.ToString(),
                         node.Attributes[2].Value.ToString(),
                          node.Attributes[3].Value.ToString());
                        w.Add(wa);
                    }

                    a.listbatch = w;
                    Database.orders.Add(a);
                }
                dataGridView8.DataSource = Database.orders;


                xmlnode = xmldoc.GetElementsByTagName("cycletimes");
                Database.cycletimes = new List<Order2>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Order2 a = new Order2(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(),
                        xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString()); ;
                    Database.cycletimes.Add(a);
                }
                dataGridView11.DataSource = Database.cycletimes;

                   

                for (int pointIndex = 0; pointIndex < 1; pointIndex++)
                {
                    int gesamtint = Convert.ToInt32(Math.Round(Convert.ToDouble(gesamt)));
                    gesamtint = gesamtint;
                    chart1.Series["Gesamter Lagerwert"].Points.Add(gesamtint);
                }

                dataGridView12.DataSource = Database.empfehlungen;

                chart3.Titles.Add("Empfehlungen");
                
                chart3.Series.Add("Empfehlungen");
                chart3.Series.Remove(chart3.Series[0]);
                
                chart3.Series["Empfehlungen"].ChartType = SeriesChartType.Line;

                for (int i = 0; i < Database.empfehlungen.Count; i++)
                {

                }
                



                label2.Text = "Xml eingelesen";

                xmleingelesen = true;
            }
        }

        public void chart3befüllen(EmpfohleneBestellungen e)
        {
            chart3.Series["Empfehlungen"].Points.Add(Convert.ToInt32(e.amount));
            chart3.Series["Empfehlungen"].Points.Add(Convert.ToInt32(e.amountnext2));
            chart3.Series["Empfehlungen"].Points.Add(Convert.ToInt32(e.amountnext3));
            chart3.Series["Empfehlungen"].Points.Add(Convert.ToInt32(e.amountnext4));
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deutsch();
        }

        public void deutsch()
        {
            tabPage1.Text = "Bestellungen";
            tabPage14.Text = "Lagerbestand";
            tabPage15.Text = "Zukünftige Eingänge";
            tabPage16.Text = "Wartekosten";
            tabPage17.Text = "Warteliste Arbeitsplätze";
            tabPage18.Text = "Warteliste Lager";
            tabPage20.Text = "Aufträge in Bearbeitung";
            tabPage22.Text = "Beendete Aufträge";
            tabPage24.Text = "Durchlaufzeiten";
            tabPage10.Text = "XML Ergebnisse";
            tabPage11.Text = "Vertrieb";
            tabPage12.Text = "Produktion";
            tabPage13.Text = "Arbeitszeit";
            //label3.Text = "Gesamter Lagerwert: ";
            deutschToolStripMenuItem.Text = "Deutsch";
            englischToolStripMenuItem.Text = "Englisch";
            dateiToolStripMenuItem.Text = "Datei";
            xMLImportierenToolStripMenuItem.Text = "Xml importieren";
            xMLExportierenToolStripMenuItem.Text = "Xml exportieren";
            spracheToolStripMenuItem.Text = "Sprache";
            label2.Text = "Sprache: Deutsch";
            label42.Text = "Prognosen";
           
            label8.Text = "Vetriebswunsch";
           
            label10.Text = "Produkt 1";
            label11.Text = "Produkt 2";
            label12.Text = "Produkt 3";
            button9.Text = "Senden";
            button11.Text = "Senden";
            label13.Text = "Produkt 3";
            label14.Text = "Produkt 2";
            label15.Text = "Produkt 1";
            label16.Text = "Menge";
            label17.Text = "Preis";
            label18.Text = "Konventionalstrafe";
            label9.Text = "Direktverkauf";
            //label3.Text = "Totalstockvalue: ";
            
            vorschauToolStripMenuItem.Text = "Vorschau";
           
            label21.Text = "Produkt";
            label22.Text = "Produkt";
            label23.Text = "Produkt";
            label24.Text = "Produkt";
            label25.Text = "Produkt";
            label26.Text = "Menge";
            label28.Text = "Menge";
            label30.Text = "Menge";
            label32.Text = "Menge";
            label36.Text = "Menge";
            button5.Text = "Aufteilen";
            button6.Text = "Aufteilen";
            button7.Text = "Aufteilen";
            button8.Text = "Aufteilen";
            button10.Text = "Aktualisieren";
            label5.Text = "Artikel";
            label6.Text = "Menge";
            label7.Text = "Modus";
            button1.Text = "Senden";
        }

        public void empfehlungen(Warehousestock a)
        {
            if (Convert.ToDouble(a.amountnext2) < 0)
            {
                EmpfohleneBestellungen e = new EmpfohleneBestellungen();
                e.id = a.id;
                e.lieferfrist = a.lieferfrist;
                e.mengebestellung = a.mengebestellung;
                e.normalEil = a.normalEil;
                e.price = a.price;
                e.startamount = a.startamount;
                e.stockvalue = a.stockvalue;
                e.abweichung = a.abweichung;
                e.amount = a.amount;
                e.amountnext2 = a.amountnext2;
                e.amountnext3 = a.amountnext3;
                e.amountnext4 = a.amountnext4;
                e.bruttobedarfjetzt = a.bruttobedarfjetzt;
                e.bruttobedarfnext1 = a.bruttobedarfnext1;
                e.bruttobedarfnext2 = a.bruttobedarfnext2;
                e.bruttobedarfnext3 = a.bruttobedarfnext3;
                e.diskontmenge = a.diskontmenge;
                Database.empfehlungen.Add(e);
            }
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englisch();
        }

        public void englisch()
        {
            tabPage1.Text = "Inward Stockmovement";
            tabPage14.Text = "Warehousestock";
            tabPage15.Text = "Future Orders";
            tabPage16.Text = "Ideltimecosts";
            tabPage17.Text = "Waitinglistworkstations";
            tabPage18.Text = "Waitingliststock";
            tabPage20.Text = "Orders in Work";
            tabPage22.Text = "Completed Orders";
            tabPage24.Text = "Cycletimes";
            tabPage10.Text = "XML Results";
            tabPage11.Text = "Sales";
            tabPage12.Text = "Production";
            tabPage13.Text = "Working hours";
            label8.Text = "Sales wish";
            label42.Text = "Forecast";
            label10.Text = "Product 1";
            label11.Text = "Product 2";
            label12.Text = "Product 3";
            button9.Text = "Send";
            button11.Text = "Send";
            button1.Text = "Send";
            label13.Text = "Product 3";
            label14.Text = "Product 2";
            label15.Text = "Product 1";
            label16.Text = "Amount";
            label17.Text = "Price";
            label18.Text = "Penalty";
            label9.Text = "Dircet sales";
            //label3.Text = "Totalstockvalue: ";
            deutschToolStripMenuItem.Text = "German";
            englischToolStripMenuItem.Text = "English";
            dateiToolStripMenuItem.Text = "Data";
            vorschauToolStripMenuItem.Text = "Preview";
            spracheToolStripMenuItem.Text = "Language";
            xMLImportierenToolStripMenuItem.Text = "Xml Import";
            xMLExportierenToolStripMenuItem.Text = "Xml Export";
            label2.Text = "Language: Englisch";
            label21.Text = "Product";
            label22.Text = "Product";
            label23.Text = "Product";
            label24.Text = "Product";
            label25.Text = "Product";
            label26.Text = "Amount";
            label28.Text = "Amount";
            label30.Text = "Amount";
            label32.Text = "Amount";
            label36.Text = "Amount";
            button5.Text = "Split";
            button6.Text = "Split";
            button7.Text = "Split";
            button8.Text = "Split";
            button10.Text = "Update";
            label5.Text = "Article";
            label6.Text = "Amount";
            label7.Text = "Mode";
          // label39.Text = "Send ✔";
          // label40.Text = "Send ✔";






        }

        private void xMLExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = null;
            try
            {
               xmldoc = XMLCreater.Create();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            saveFileDialog1.Filter = "XML (.xml)|*.xml"; 
           saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName !="")
            {
                xmldoc.Save(saveFileDialog1.FileName);
            }
        }

        private void dataGridView9_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            Waitinglistworkstations w  = Database.workstationswaitinglist[e.RowIndex];

            dataGridView9.DataSource = w.listWaitinglist;

            label2.Text = cell.ToString();
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            Missingpart w = Database.waitingliststock[e.RowIndex];

            dataGridView10.DataSource = w.waitinglistlist;

            label2.Text = cell.ToString();
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewTextBoxCell cell = (DataGridViewTextBoxCell)
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

            Order w = Database.orders[e.RowIndex];

            dataGridView13.DataSource = w.listbatch;

            label2.Text = cell.ToString();
        }

        public static NeueBestellung neue;

        private void button1_Click(object sender, EventArgs e)
        {
            EingabeBestellung form = new EingabeBestellung();
            form.ShowDialog();
            NeueBestellung n = EingabeBestellung.neue;
            
            Database.neuebestellungen.Add(n);
            dataGridView19.DataSource = Database.neuebestellungen;
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            NeueBestellung neu = new NeueBestellung();
            neu.article = textBox2.Text;
            neu.menge = textBox1.Text;
            neu.modus = textBox3.Text;
            Database.neuebestellungen.Add(neu);
            dataGridView19.DataSource = null;
            dataGridView19.DataSource = Database.neuebestellungen;
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (xmleingelesen)
            {
                Form1.welches = 1;
                Form1 form = new Form1();
                form.p1();
                Form1.welches = 1;
                form.ShowDialog();

                if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
                {
                    tabPage12.Text = tabPage12.Text + "✔";
                    produkte = true;
                    if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
                    {
                        label41.BackColor = Color.Green;
                       
                    }
                }
            }
            else
            {
                MessageBox.Show("Bitte erst XML einlesen!");
            }

          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(xmleingelesen)
            {
            Form1.welches = 2;
            Form1 form = new Form1();
            form.p2();
            Form1.welches = 2;
            form.ShowDialog();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
            {
                tabPage12.Text = tabPage12.Text + "✔";
                produkte = true;
                if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
                {
                    label41.BackColor = Color.Green;
                    
                }
            }
            }
            else
            {
                MessageBox.Show("Bitte erst XML einlesen!");
            }

            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(xmleingelesen)
            {

            Form1.welches = 3;
            Form1 form = new Form1();
            form.p3();
            Form1.welches = 3;
            form.ShowDialog();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----"&&label37.Text!="-----"&&label34.Text!="-----")
            {
                tabPage12.Text = tabPage12.Text + "✔";
                produkte = true;
                if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
                {
                    label41.BackColor = Color.Green;
                    
                }
            }
            }
            else
            {
                MessageBox.Show("Bitte erst XML einlesen!");
            }

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //SSSSSSSSSSSSSSSSSSSSSS
            List<Fertigungsauftrag>[] liste = new List<Fertigungsauftrag>[5];
            //List<String> listereihe = new List<string>();
            liste[Convert.ToInt32(textBox25.Text)] = au1;
            liste[Convert.ToInt32(textBox26.Text)] = au2;
            liste[Convert.ToInt32(textBox27.Text)] = au3;
            liste[Convert.ToInt32(textBox28.Text)] = au4;
            liste[Convert.ToInt32(textBox29.Text)] = au5;
            
            label33.Text = "P3";
            if(au3.Count!=0)
            label31.Text = au3[0].menge;

            label20.Text = "P2";
            if (au2.Count != 0)
            label29.Text = au2[0].menge;

            label19.Text = "P1";
            if (au1.Count != 0)
            label27.Text = au1[0].menge;

            label34.Text = au4name;
            if (au4.Count != 0)
            {
                label37.Text = "P"+au4[0].artikel;
                label35.Text = au4[0].menge;
            }

            label37.Text = au5name;
            if (au5.Count != 0)
            {
                label37.Text = "P" + au5[0].artikel;
                label38.Text = au5[0].menge;
            }
            List<Fertigungsauftrag> erg = new List<Fertigungsauftrag>();
            for (int k = 0; k < liste.Length; k++)
            {
                for (int i = 0; i < liste[k].Count; i++)
                {
                    erg.Add(liste[k][i]);
                    
                }
            }
            /*for (int i = 0; i < au1.Count; i++)
            {
                erg.Add(au1[i]);
            }
            for (int i = 0; i < au2.Count; i++)
            {
                erg.Add(au2[i]);
            }
            for (int i = 0; i < au3.Count; i++)
            {
                erg.Add(au3[i]);
            }
            for (int i = 0; i < au4.Count; i++)
            {
                erg.Add(au4[i]);
            }
            for (int i = 0; i < au5.Count; i++)
            {
                erg.Add(au5[i]);
            }
            */
            dataGridView20.DataSource = erg;
            Database.fertigungsauftraege = erg;

            

            Arbeitsplatz a1 = new Arbeitsplatz();
            a1.station = "1";
            a1.rustzeit = "";
            Fertigungsauftrag f49 = new Fertigungsauftrag();
            f49.menge = "0";
            Fertigungsauftrag f5 = new Fertigungsauftrag();
            f5.menge = "0";
            Fertigungsauftrag f6 = new Fertigungsauftrag();
            f6.menge = "0";
            Fertigungsauftrag f4 = new Fertigungsauftrag();
            f4.menge = "0";
            Fertigungsauftrag f7 = new Fertigungsauftrag();
            f7.menge = "0";
            Fertigungsauftrag f8 = new Fertigungsauftrag();
            f8.menge = "0";
            Fertigungsauftrag f9 = new Fertigungsauftrag();
            f9.menge = "0";
            Fertigungsauftrag f10 = new Fertigungsauftrag();
            f10.menge = "0";
            Fertigungsauftrag f11 = new Fertigungsauftrag();
            f11.menge = "0";
            Fertigungsauftrag f12 = new Fertigungsauftrag();
            f12.menge = "0";
            Fertigungsauftrag f13 = new Fertigungsauftrag();
            f13.menge = "0";
            Fertigungsauftrag f14 = new Fertigungsauftrag();
            f14.menge = "0";
            Fertigungsauftrag f15 = new Fertigungsauftrag();
            f15.menge = "0";
            Fertigungsauftrag f16 = new Fertigungsauftrag();
            f16.menge = "0";
            Fertigungsauftrag f17 = new Fertigungsauftrag();
            f17.menge = "0";
            Fertigungsauftrag f18 = new Fertigungsauftrag();
            f18.menge = "0";
            Fertigungsauftrag f19 = new Fertigungsauftrag();
            f19.menge = "0";
            Fertigungsauftrag f20 = new Fertigungsauftrag();
            f20.menge = "0";
            Fertigungsauftrag f26 = new Fertigungsauftrag();
            f26.menge = "0";

            Fertigungsauftrag f54 = new Fertigungsauftrag();
            f54.menge = "0";
            Fertigungsauftrag f29 = new Fertigungsauftrag();
            f29.menge = "0";
            Fertigungsauftrag f50 = new Fertigungsauftrag();
            f50.menge = "0";
            Fertigungsauftrag f55 = new Fertigungsauftrag();
            f55.menge = "0";
            Fertigungsauftrag f30 = new Fertigungsauftrag();
            f30.menge = "0";
            Fertigungsauftrag f51 = new Fertigungsauftrag();
            f51.menge = "0";
            Fertigungsauftrag f56 = new Fertigungsauftrag();
            f56.menge = "0";
            Fertigungsauftrag f31 = new Fertigungsauftrag();
            f31.menge = "0";
            Fertigungsauftrag f1 = new Fertigungsauftrag();
            f1.menge = "0";
            Fertigungsauftrag f2 = new Fertigungsauftrag();
            f2.menge = "0";
            Fertigungsauftrag f3 = new Fertigungsauftrag();
            f3.menge = "0";

            for(int i = 0; i<erg.Count;i++)
            {
                if(erg[i].artikel=="49")
                {
                   
                    if(f49.menge!="")
                    f49.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f49.menge)).ToString());
                    else
                        f49 = erg[i];
                }

                if(erg[i].artikel=="4")
                {
                   
                    if(f4.menge!="")
                        f4.setMenge((Convert.ToInt32(erg[i].menge) + Convert.ToInt32(f4.menge)).ToString());
                    else
                        f4 = erg[i];
                }
                if(erg[i].artikel=="5")
                {
                    
                    if(f5.menge!="")
                    f5.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f5.menge)).ToString());
                    else
                        f5 = erg[i];
                }
                if(erg[i].artikel=="6")
                {
                   
                    if(f6.menge!="")
                    f6.setMenge( (Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f6.menge)).ToString());
                    else
                        f6 = erg[i];
                }
                if(erg[i].artikel=="7")
                {
                   
                    if(f7.menge!="")
                    f7.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f7.menge)).ToString());
                    else
                        f7 = erg[i];
                }
                if(erg[i].artikel=="8")
                {
                  
                    if(f8.menge!="")
                    f8.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f8.menge)).ToString());
                    else
                        f8 = erg[i];
                }
                if(erg[i].artikel=="9")
                {
                 
                    if(f9.menge!="")
                    f9.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f9.menge)).ToString());
                    else
                        f9 = erg[i];
                }
                if(erg[i].artikel=="10")
                {
                   
                    if(f10.menge!="")
                    f10.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f10.menge)).ToString());
                    else
                        f10 = erg[i];
                }
                if(erg[i].artikel=="11")
                {
           
                    if(f11.menge!="")
                    f11.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f11.menge)).ToString());
                    else
                        f11 = erg[i];
                }
                if(erg[i].artikel=="12")
                {
                 
                    if(f12.menge!="")
                    f12.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f12.menge)).ToString());
                    else
                        f12 = erg[i];
                }
                if(erg[i].artikel=="13")
                {
                    if(f13.menge!="")
                    f13.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f13.menge)).ToString());
                    else
                        f13 = erg[i];
                }
                if(erg[i].artikel=="14")
                {
                    if(f14.menge!="")
                    f14.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f14.menge)).ToString());
                    else
                        f14 = erg[i];
                }
                if(erg[i].artikel=="15")
                {
                    if(f15.menge!="")
                    f15.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f15.menge)).ToString());
                    else
                        f15 = erg[i];
                }
                if(erg[i].artikel=="16")
                {
                    if(f16.menge!="")
                    f16.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f16.menge)).ToString());
                    else
                        f16 = erg[i];
                }
                if(erg[i].artikel=="17")
                {
                    if(f17.menge!="")
                    f17.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f17.menge)).ToString());
                    else
                        f17 = erg[i];
                }
                if(erg[i].artikel=="18")
                {
                    if(f18.menge!="")
                    f18.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f18.menge)).ToString());
                    else
                        f18 = erg[i];
                }
                if(erg[i].artikel=="19")
                {
                    if(f19.menge!="")
                    f19.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f19.menge)).ToString());
                    else
                        f19 = erg[i];
                }
                if(erg[i].artikel=="20")
                {
                    if(f20.menge!="")
                    f20.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f20.menge)).ToString());
                    else
                        f20 = erg[i];
                }
                if(erg[i].artikel=="26")
                {
                    if(f26.menge!="")
                    f26.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f26.menge)).ToString());
                    else
                        f26 = erg[i];
                }
                if(erg[i].artikel=="54")
                {
                    if(f54.menge!="")
                    f54.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f54.menge)).ToString());
                    else
                        f54 = erg[i];
                }
                if(erg[i].artikel=="29")
                {
                    if(f29.menge!="")
                    f29.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f29.menge)).ToString());
                    else
                        f29 = erg[i];
                }
                if(erg[i].artikel=="50")
                {
                    if(f50.menge!="")
                    f50.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f50.menge)).ToString());
                    else
                        f50 = erg[i];
                }

                if(erg[i].artikel=="55")
                {
                    if(f55.menge!="")
                    f55.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f55.menge)).ToString());
                    else
                        f55 = erg[i];
                }

                if(erg[i].artikel=="30")
                {
                    if(f30.menge!="")
                    f30.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f30.menge)).ToString());
                    else
                        f30 = erg[i];
                }

                if(erg[i].artikel=="51")
                {
                    if(f51.menge!="")
                    f51.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f51.menge)).ToString());
                    else
                        f51 = erg[i];
                }

                if(erg[i].artikel=="56")
                {
                    if(f56.menge!="")
                    f56.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f56.menge)).ToString());
                    else
                        f56 = erg[i];
                }

                if(erg[i].artikel=="31")
                {
                    if(f31.menge!="")
                    f31.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f31.menge)).ToString());
                    else
                        f31 = erg[i];
                }

                if(erg[i].artikel=="1")
                {
                    if(f1.menge!="")
                    f1.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f1.menge)).ToString());
                    else
                        f1 = erg[i];
                }
                if(erg[i].artikel=="2")
                {
                    if(f2.menge!="")
                    f2.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f2.menge)).ToString());
                    else
                        f2 = erg[i];
                }
                if(erg[i].artikel=="3")
                {
                    if(f3.menge!="")
                    f3.setMenge((Convert.ToInt32(erg[i].menge)+Convert.ToInt32(f3.menge)).ToString());
                    else
                        f3 = erg[i];
                }
            }
            Database.arbeitsplaetze = new List<Arbeitsplatz>();
            a1.rustzeit = "60";
            //a1.bearbeitungszeit += (Convert.ToInt32("60"));
            a1.bearbeitungszeit += (Convert.ToInt32(f49.menge) * 6);
            a1.bearbeitungszeit += (Convert.ToInt32(f54.menge) * 6);
            a1.bearbeitungszeit += (Convert.ToInt32(f29.menge) * 6);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a1.station)
                {
                    a1.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a1);

            Arbeitsplatz a2 = new Arbeitsplatz();
            
            a2.rustzeit = "80";
            //a2.bearbeitungszeit += (Convert.ToInt32("80"));
            a2.bearbeitungszeit += (Convert.ToInt32(f50.menge) * 5);
            a2.bearbeitungszeit += (Convert.ToInt32(f55.menge) * 5);
            a2.bearbeitungszeit += (Convert.ToInt32(f30.menge) * 5);
            a2.station = "2";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a2.station)
                {
                    a2.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a2);

            Arbeitsplatz a3 = new Arbeitsplatz();

            a3.rustzeit = "60";
            //a3.bearbeitungszeit += (Convert.ToInt32("60"));
            a3.bearbeitungszeit += (Convert.ToInt32(f51.menge) * 5);
            a3.bearbeitungszeit += (Convert.ToInt32(f56.menge) * 6);
            a3.bearbeitungszeit += (Convert.ToInt32(f31.menge) * 6);
            a3.station = "3";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a3.station)
                {
                    a3.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a3);

            Arbeitsplatz a4 = new Arbeitsplatz();

            a4.rustzeit = "80";
            //a4.bearbeitungszeit += (Convert.ToInt32("80"));
            a4.bearbeitungszeit += (Convert.ToInt32(f1.menge) * 6);
            a4.bearbeitungszeit += (Convert.ToInt32(f2.menge) * 7);
            a4.bearbeitungszeit += (Convert.ToInt32(f3.menge) * 7);
            a4.station = "4";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a4.station)
                {
                    a4.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a4);

            Arbeitsplatz a5 = new Arbeitsplatz();
            a5.station = "5";

           // Database.arbeitsplaetze.Add(a5);

            Arbeitsplatz a6 = new Arbeitsplatz();

            a6.rustzeit = "180";
            //a6.bearbeitungszeit += (Convert.ToInt32("180"));
            a6.bearbeitungszeit += (Convert.ToInt32(f16.menge) * 2);
            a6.bearbeitungszeit += (Convert.ToInt32(f18.menge) * 3);
            a6.bearbeitungszeit += (Convert.ToInt32(f19.menge) * 3);
            a6.bearbeitungszeit += (Convert.ToInt32(f20.menge) * 3);
            a6.station = "6";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a6.station)
                {
                    a6.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a6);

            Arbeitsplatz a7 = new Arbeitsplatz();

            a7.rustzeit = "350";
            //a7.bearbeitungszeit += (Convert.ToInt32("350"));
            a7.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f18.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f19.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f20.menge) * 2);
            a7.bearbeitungszeit += (Convert.ToInt32(f26.menge) * 2);
            a7.station = "7";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a7.station)
                {
                    a7.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a7);

            

            Arbeitsplatz a8 = new Arbeitsplatz();

            a8.rustzeit = "160";
            //a8.bearbeitungszeit += (Convert.ToInt32("160"));
            a8.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 1);
            a8.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 2);
            a8.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 2);
            a8.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 1);
            a8.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 2);
            a8.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 2);
            a8.bearbeitungszeit += (Convert.ToInt32(f18.menge) * 3);
            a8.bearbeitungszeit += (Convert.ToInt32(f19.menge) * 3);
            a8.bearbeitungszeit += (Convert.ToInt32(f20.menge) * 3);
            a8.station = "8";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a8.station)
                {
                    a8.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a8);

            Arbeitsplatz a9 = new Arbeitsplatz();

            a9.rustzeit = "200";
            //a9.bearbeitungszeit += (Convert.ToInt32("200"));
            a9.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 3);
            a9.bearbeitungszeit += (Convert.ToInt32(f18.menge) * 2);
            a9.bearbeitungszeit += (Convert.ToInt32(f19.menge) * 2);
            a9.bearbeitungszeit += (Convert.ToInt32(f20.menge) * 2);
            a9.station = "9";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a9.station)
                {
                    a9.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a9);

            Arbeitsplatz a10 = new Arbeitsplatz();

            a10.rustzeit = "120";
            //a10.bearbeitungszeit += (Convert.ToInt32("120"));
            a10.bearbeitungszeit += (Convert.ToInt32(f4.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f5.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f6.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f7.menge) * 4);
            a10.station = "10";
            a10.bearbeitungszeit += (Convert.ToInt32(f8.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f9.menge) * 4);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a10.station)
                {
                    a10.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a10);

            Arbeitsplatz a11 = new Arbeitsplatz();

            a11.rustzeit = "160";
            //a11.bearbeitungszeit += (Convert.ToInt32("160"));
            a11.bearbeitungszeit += (Convert.ToInt32(f4.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f5.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f6.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f7.menge) * 3);
            a11.station ="11";
            a11.bearbeitungszeit += (Convert.ToInt32(f8.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f9.menge) * 3);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a11.station)
                {
                    a11.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a11);

            Arbeitsplatz a12 = new Arbeitsplatz();
            a12.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 3);
            a12.station = "12";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a12.station)
                {
                    a12.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a12);
            Arbeitsplatz a13 = new Arbeitsplatz();
            a13.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 2);
            a13.station = "13";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a13.station)
                {
                    a13.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a13);
            Arbeitsplatz a14 = new Arbeitsplatz();
            a14.bearbeitungszeit += (Convert.ToInt32(f16.menge) * 3);

            a14.station = "14";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a14.station)
                {
                    a14.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a14);
            Arbeitsplatz a15 = new Arbeitsplatz();

            a15.rustzeit = "90";
            //a15.bearbeitungszeit += (Convert.ToInt32("90"));
            a15.bearbeitungszeit += (Convert.ToInt32(f17.menge) * 3);
            a15.bearbeitungszeit += (Convert.ToInt32(f26.menge) * 3);

            a15.station = "15";
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a15.station)
                {
                    a15.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a15);

            Database.mergearbeitsplaetze();

            chart2.Titles.Add("Arbeitsplätze");
            //label2.Text = "XML eingelesen";

            chart2.Series.Add("Arbeitsplätze");
            chart2.Series.Remove(chart2.Series[0]);
            //chart1.Series.Add("Area");

            //Ausssehen festlegen
            chart2.Series["Arbeitsplätze"].ChartType = SeriesChartType.Column;

            //Zufällige Werte generieren
            Random random = new Random();



            for (int pointIndex = 0; pointIndex < Database.arbeitsplaetze.Count; pointIndex++)
            {
                int gesamtint = Convert.ToInt32(Math.Round(Convert.ToDouble(Database.arbeitsplaetze[pointIndex].gesamtzeit)));
                gesamtint = gesamtint;
                chart2.Series["Arbeitsplätze"].Points.Add(gesamtint);
            }

            dataGridView21.DataSource = Database.arbeitsplaetze;
            farbezellenarbeitszeit();
            dataGridView21.DataSource = null;
            dataGridView21.DataSource = Database.arbeitsplaetze;
            farbezellenarbeitszeit();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
            {
                tabPage12.Text = tabPage12.Text + "✔";
                produkte = true;
                if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
                {
                    label41.BackColor = Color.Green;
                  
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (label27.Text == "-----")
            {

            }
            else
            {
                howmuch form = new howmuch(au1);
                form.Show();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (label29.Text == "-----")
            {

            }
            else
            {
                howmuch form = new howmuch(au2);
                form.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (label31.Text == "-----")
            {

            }
            else
            {
                howmuch form = new howmuch(au3);
                form.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (label35.Text == "-----")
            {

            }
            else
            {
                howmuch form = new howmuch(au4);
                form.Show();
            }
        }

        private void dataGridView21_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void farbezellenarbeitszeit()
        {
            for (int i = 0; i < Database.arbeitsplaetze.Count; i++)
            {
                if (Database.arbeitsplaetze[i].getBearbeitungszeit() <= 2400)
                {
                    
                    //dataGridView21[4,i].Style.BackColor = Color.Green;
                    Database.arbeitsplaetze[i].schicht = "1";
                    Database.arbeitsplaetze[i].ueberstunden = "0";
                    
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 2400)
                {
                    //dataGridView21[4, i].Style.BackColor=Color.Yellow;
                    Database.arbeitsplaetze[i].schicht = "1";
                    Database.arbeitsplaetze[i].ueberstunden = (Convert.ToInt32(Database.arbeitsplaetze[i].getBearbeitungszeit())-2400).ToString();
                    Database.arbeitsplaetze[i].ueberstunden = (Convert.ToInt32(Database.arbeitsplaetze[i].ueberstunden) / 5).ToString();
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 3600)
                {
                    //dataGridView21[4, i].Style.BackColor = Color.Orange;
                    Database.arbeitsplaetze[i].schicht = "2";
                    Database.arbeitsplaetze[i].ueberstunden = "Empfohlen 2. Schicht";
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 4800)
                {
                    //dataGridView21[4, i].Style.BackColor=Color.Yellow;
                    Database.arbeitsplaetze[i].schicht = "2";
                    Database.arbeitsplaetze[i].ueberstunden = (Convert.ToInt32(Database.arbeitsplaetze[i].getBearbeitungszeit()) - 4800).ToString();
                    Database.arbeitsplaetze[i].ueberstunden = (Convert.ToInt32(Database.arbeitsplaetze[i].ueberstunden) / 5).ToString();
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 7200)
                {
                    //dataGridView21[4, i].Style.BackColor = Color.Red;
                    Database.arbeitsplaetze[i].schicht = "3";
                    Database.arbeitsplaetze[i].ueberstunden = "Empfohlen 3. Schicht";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XMLCreater.sellwish[0] = textBox4.Text;
            XMLCreater.sellwish[1] = textBox5.Text;
            XMLCreater.sellwish[2] = textBox6.Text;

            Database.prognosen[0].sellwish[0].menge = textBox4.Text;
            Database.prognosen[0].sellwish[1].menge = textBox5.Text;
            Database.prognosen[0].sellwish[2].menge = textBox6.Text;

            Database.prognosen[1].sellwish[0].menge = textBox16.Text;
            Database.prognosen[1].sellwish[1].menge = textBox17.Text;
            Database.prognosen[1].sellwish[2].menge = textBox18.Text;

            Database.prognosen[2].sellwish[0].menge = textBox19.Text;
            Database.prognosen[2].sellwish[1].menge = textBox20.Text;
            Database.prognosen[2].sellwish[2].menge = textBox21.Text;

            Database.prognosen[3].sellwish[0].menge = textBox22.Text;
            Database.prognosen[3].sellwish[1].menge = textBox23.Text;
            Database.prognosen[3].sellwish[2].menge = textBox24.Text;

            label39.Text = " ✔";

            if (label39.Text != "" && label40.Text != "")
            {
                tabPage11.Text = tabPage11.Text + "✔";
            }
            vertriebswunsch = true;
            if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
            {
                label41.BackColor = Color.Green;
               
            }
            
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            XMLCreater.selldirectmenge[0] = textBox15.Text;
            XMLCreater.selldirectmenge[1] = textBox14.Text;
            XMLCreater.selldirectmenge[2] = textBox13.Text;

            XMLCreater.selldirektkonventional[0] = textBox9.Text;
            XMLCreater.selldirektkonventional[1] = textBox8.Text;
            XMLCreater.selldirektkonventional[2] = textBox7.Text;

            XMLCreater.selldirektpreis[0] = textBox10.Text;
            XMLCreater.selldirektpreis[1] = textBox11.Text;
            XMLCreater.selldirektpreis[2] = textBox12.Text;

            label40.Text = " ✔";

            if (label39.Text != "" && label40.Text != "")
            {
                tabPage11.Text = tabPage11.Text + "✔";
                
            }
            direktvertrieb = true;
            if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
            {
                label41.BackColor = Color.Green;
                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void vorschauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            xmlvorschau form = new xmlvorschau();
            form.Show();
        }

        private void dataGridView21_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        public static bool arbeitsplaetze = false;
        public static bool produkte = false;
        public static bool vertriebswunsch = false;
        public static bool direktvertrieb = false;

        private void dataGridView21_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int test = 0;
            for (int i = 0; i < Database.arbeitsplaetze.Count; i++)
            {
                if (!String.IsNullOrEmpty(Database.arbeitsplaetze[i].schicht) && Database.arbeitsplaetze[i].schicht != "empfohlen" && !String.IsNullOrEmpty(Database.arbeitsplaetze[i].ueberstunden) && Database.arbeitsplaetze[i].ueberstunden != "empfohlen" && Database.arbeitsplaetze[i].station != "" && Database.arbeitsplaetze[i].station != "empfohlen")
                {
                    test++;
                }
            }
            if (test == Database.arbeitsplaetze.Count)
            {
                tabPage13.Text = tabPage13.Text + "✔";
                arbeitsplaetze = true;
                if (arbeitsplaetze && produkte && vertriebswunsch && direktvertrieb)
                {
                    label41.BackColor = Color.Green;
                }
            }
        }

        public static bool blink = true;

        public void menublink()
        {
            while (blink)
            {
                vorschauToolStripMenuItem.BackColor = Color.LightGray;
                Thread.Sleep(500);
                vorschauToolStripMenuItem.BackColor = Color.Green;
            }
        }

        private void dataGridView20_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView17_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage22_Click(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
