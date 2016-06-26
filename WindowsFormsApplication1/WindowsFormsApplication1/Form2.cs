using System;
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
           
            chart1.Titles.Add("Gesamter Lagerwert");
            

            chart1.Series.Add("6");
            chart1.Series.Remove(chart1.Series[0]);
            
            chart1.Series["6"].ChartType = SeriesChartType.Column;


            deutsch();


            for (int pointIndex = 0; pointIndex < 1; pointIndex++)
            {
                int gesamtint = Convert.ToInt32(Math.Round(Convert.ToDouble("0")));
                gesamtint = gesamtint;
                chart1.Series["6"].Points.Add(gesamtint);
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

           // chart2.Titles.Add("Arbeitsplätze");
            //label2.Text = "XML eingelesen";

            chart2.Series.Add("1");
            chart2.Series.Remove(chart2.Series[0]);
            //chart1.Series.Add("Area");

            //Ausssehen festlegen
            chart2.Series["1"].ChartType = SeriesChartType.Column;

         /*   Image myimage7 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\background.jpg");
            for (int i = 0; i < tabControl1.TabPages.Count; i++)
            {
                tabControl1.TabPages[i].BackgroundImage = myimage7;
            }*/
        } 

        private void xMLImportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(label39.Text!="")
            {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string xmlfile = openFileDialog1.FileName;
                FileStream fs = new FileStream(xmlfile, FileMode.Open, FileAccess.Read);
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xmlnode;
                XmlNodeList xmlnode2;
                xmldoc.Load(fs);
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

                xmlnode = xmldoc.GetElementsByTagName("inwardstockmovement");
                Database.bestellungen = new List<Inwardstockmovement>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
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
                        a.delivery_deadline = "1,8";
                        a.difference = "0,4";
                        a.useP1 = "1";
                        a.useP2 = "0";
                        a.useP3 = "0";
                        a.discont = "300";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }

                    if (a.id == "21")
                    {
                        a.delivery_deadline = "1,8";
                        a.difference = "0,4";
                        a.useP1 = "1";
                        a.useP2 = "0";
                        a.useP3 = "0";
                        a.discont = "300";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "22")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,4";
                        a.useP1 = "0";
                        a.useP2 = "1";
                        a.useP3 = "0";
                        a.discont = "300";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "23")
                    {
                        a.delivery_deadline = "1,2";
                        a.difference = "0,2";
                        a.useP1 = "0";
                        a.useP2 = "0";
                        a.useP3 = "1";
                        a.discont = "300";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "24")
                    {
                        a.delivery_deadline = "3,2";
                        a.difference = "0,3";
                        a.useP1 = "7";
                        a.useP2 = "7";
                        a.useP3 = "7";
                        a.discont = "6100";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "25")
                    {
                        a.delivery_deadline = "0,9";
                        a.difference = "0,2";
                        a.useP1 = "4";
                        a.useP2 = "4";
                        a.useP3 = "4";
                        a.discont = "3600";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "27")
                    {
                        a.delivery_deadline = "0,9";
                        a.difference = "0,2";
                        a.useP1 = "2";
                        a.useP2 = "2";
                        a.useP3 = "2";
                        a.discont = "1800";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "28")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,4";
                        a.useP1 = "4";
                        a.useP2 = "5";
                        a.useP3 = "6";
                        a.discont = "4500";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "32")
                    {
                        a.delivery_deadline = "2,1";
                        a.difference = "0,5";
                        a.useP1 = "3";
                        a.useP2 = "3";
                        a.useP3 = "3";
                        a.discont = "2700";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "33")
                    {
                        a.delivery_deadline = "1,9";
                        a.difference = "0,5";
                        a.useP1 = "0";
                        a.useP2 = "0";
                        a.useP3 = "2";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "34")
                    {
                        a.delivery_deadline = "1,6";
                        a.difference = "0,3";
                        a.useP1 = "0";
                        a.useP2 = "0";
                        a.useP3 = "72";
                        a.discont = "22000";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "35")
                    {
                        a.delivery_deadline = "2,2";
                        a.difference = "0,4";
                        a.useP1 = "4";
                        a.useP2 = "4";
                        a.useP3 = "4";
                        a.discont = "3600";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "36")
                    {
                        a.delivery_deadline = "1,2";
                        a.difference = "0,1";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "37")
                    {
                        a.delivery_deadline = "1,5";
                        a.difference = "0,3";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "38")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,4";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "300";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "39")
                    {
                        a.delivery_deadline = "1,5";
                        a.difference = "0,3";
                        a.useP1 = "2";
                        a.useP2 = "2";
                        a.useP3 = "2";
                        a.discont = "1800";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "40")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,2";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "41")
                    {
                        a.delivery_deadline = "0,9";
                        a.difference = "0,2";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "42")
                    {
                        a.delivery_deadline = "1,2";
                        a.difference = "0,3";
                        a.useP1 = "2";
                        a.useP2 = "2";
                        a.useP3 = "2";
                        a.discont = "1800";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "43")
                    {
                        a.delivery_deadline = "2,0";
                        a.difference = "0,5";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "2700";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "44")
                    {
                        a.delivery_deadline = "1,0";
                        a.difference = "0,2";
                        a.useP1 = "3";
                        a.useP2 = "3";
                        a.useP3 = "3";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "45")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,3";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "46")
                    {
                        a.delivery_deadline = "0,9";
                        a.difference = "0,3";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "47")
                    {
                        a.delivery_deadline = "1,1";
                        a.difference = "0,1";
                        a.useP1 = "1";
                        a.useP2 = "1";
                        a.useP3 = "1";
                        a.discont = "900";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "48")
                    {
                        a.delivery_deadline = "1,0";
                        a.difference = "0,2";
                        a.useP1 = "2";
                        a.useP2 = "2";
                        a.useP3 = "2";
                        a.discont = "1800";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "52")
                    {
                        a.delivery_deadline = "1,6";
                        a.difference = "0,4";
                        a.useP1 = "2";
                        a.useP2 = "0";
                        a.useP3 = "0";
                        a.discont = "600";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "53")
                    {
                        a.delivery_deadline = "1,6";
                        a.difference = "0,2";
                        a.useP1 = "72";
                        a.useP2 = "0";
                        a.useP3 = "0";
                        a.discont = "22000";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "57")
                    {
                        a.delivery_deadline = "1,7";
                        a.difference = "0,3";
                        a.useP1 = "0";
                        a.useP2 = "2";
                        a.useP3 = "0";
                        a.discont = "600";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "58")
                    {
                        a.delivery_deadline = "1,6";
                        a.difference = "0,5";
                        a.useP1 = "0";
                        a.useP2 = "72";
                        a.useP3 = "0";
                        a.discont = "22000";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToDouble(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    if (a.id == "59")
                    {
                        a.delivery_deadline = "0,7";
                        a.difference = "0,2";
                        a.useP1 = "2";
                        a.useP2 = "2";
                        a.useP3 = "2";
                        a.discont = "1800";
                        a.needs1 = (Convert.ToDouble(Database.prognosen[0].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToInt32(Database.prognosen[0].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[0].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs2 = (Convert.ToDouble(Database.prognosen[1].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[1].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[1].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs3 = (Convert.ToDouble(Database.prognosen[2].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[2].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[2].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.needs4 = (Convert.ToDouble(Database.prognosen[3].sellwish[0].amount) * Convert.ToDouble(a.useP1) + Convert.ToDouble(Database.prognosen[3].sellwish[1].amount) * Convert.ToDouble(a.useP2) + Convert.ToDouble(Database.prognosen[3].sellwish[2].amount) * Convert.ToDouble(a.useP3)).ToString();
                        a.amountnext2 = (Convert.ToDouble(a.amount) - Convert.ToDouble(a.needs1)).ToString();
                        a.amountnext3 = (Convert.ToDouble(a.amountnext2) - Convert.ToDouble(a.needs2)).ToString();
                        a.amountnext4 = (Convert.ToDouble(a.amountnext3) - Convert.ToInt32(a.needs3)).ToString();
                        empfehlungen(a);
                    }
                    Database.lager.Add(a);
                }
                dataGridView22.DataSource = Database.empfehlungen;
                dataGridView1.DataSource = Database.lager;
                //label3.Text = "Gesamter Lagerwert: ";
                String gesamt = xmlnode[0].ChildNodes.Item(xmlnode[0].ChildNodes.Count - 1).InnerText.ToString();

                
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
                    chart1.Series["6"].Points.Add(gesamtint);
                }

                dataGridView12.DataSource = Database.empfehlungen;

                chart3.Series.Remove(chart3.Series[0]);
                chart3.Titles.Add("Empfehlungen");
                for (int i = 0; i < Database.empfehlungen.Count; i++)
                {
                    chart3befüllen(Database.empfehlungen[i]);
                }




                label2.Text = "Xml";

                xmleingelesen = true;
            }
            
            }
            else
            {
                if (sprachen == "d")
                {
                    MessageBox.Show("Bitte erst Vertriebswunsch absenden");
                }
                else
                {
                    MessageBox.Show("Please send the sellwish");
                }
            }
        }

        public void chart3befüllen(EmpfohleneBestellungen e)
        {
            /*
            if (e.id == "58")
                return;
            if (e.id == "34")
                return;*/
            if(chart3.Series.Contains(new Series(e.id)))
            {
                return;
            }
            try
            {
                chart3.Series.Add(e.id);
            }
            catch (Exception errrrrre)
            {
                return;
            }
            

            chart3.Series[e.id].ChartType = SeriesChartType.Line;
            chart3.Series[e.id].Points.Add(Convert.ToInt32(e.amount));
            for (int i = 0; i < Database.bestellungen.Count; i++)
            {
                if (Database.bestellungen[i].orderperiod == "6")
                {
                    if(Database.bestellungen[i].article == e.id)
                    {
                        chart3.Series[e.id].Points.Add(Convert.ToInt32(Database.bestellungen[i].amount));
                    }
                }
            }
            chart3.Series[e.id].Points.Add(Convert.ToInt32(e.amountnext2));
            for (int i = 0; i < Database.bestellungen.Count; i++)
            {
                if (Database.bestellungen[i].orderperiod == "7")
                {
                    if (Database.bestellungen[i].article == e.id)
                    {
                        chart3.Series[e.id].Points.Add(Convert.ToInt32(Database.bestellungen[i].amount));
                    }
                }
            }
            chart3.Series[e.id].Points.Add(Convert.ToInt32(e.amountnext3));
            for (int i = 0; i < Database.bestellungen.Count; i++)
            {
                if (Database.bestellungen[i].orderperiod == "8")
                {
                    if (Database.bestellungen[i].article == e.id)
                    {
                        chart3.Series[e.id].Points.Add(Convert.ToInt32(Database.bestellungen[i].amount));
                    }
                }
            }
            chart3.Series[e.id].Points.Add(Convert.ToInt32(e.amountnext4));
            for (int i = 0; i < Database.bestellungen.Count; i++)
            {
                if (Database.bestellungen[i].orderperiod == "9")
                {
                    if (Database.bestellungen[i].article == e.id)
                    {
                        chart3.Series[e.id].Points.Add(Convert.ToInt32(Database.bestellungen[i].amount));
                    }
                }
            }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public string message = "";

        private void deutschToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deutsch();
        }

        public void deutsch()
        {
            message = "Bitte erst XML einlesen!";
            chart1.Titles.Remove(chart1.Titles[0]);
            chart1.Titles.Add("Gesamter Lagerwert");
            if(chart2.Titles.Count != 0)
            chart2.Titles.Remove(chart2.Titles[0]);
            chart2.Titles.Add("Arbeitsplätze");
            if (chart3.Titles.Count != 0)
            chart3.Titles.Remove(chart3.Titles[0]);
            chart3.Titles.Add("Empfehlungen");
            sprachen = "d";
            tabPage1.Text = "Bestellungen";
            tabPage2.Text = "Empfehlungen";
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
            button12.Text = "Übernehmen";
            
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
            for (int i = 0; i < Database.zukunftigeEingänge.Count; i++)
            {
                if (a.id == Database.zukunftigeEingänge[i].id)
                {
                    return;
                }
            }
            if (Convert.ToDouble(a.amountnext2) < 0)
            {
                EmpfohleneBestellungen e = new EmpfohleneBestellungen();
                e.id = a.id;
                e.delivery_deadline = a.delivery_deadline;
                e.amount_order = a.amount_order;
                e.NE = a.NE;
                e.price = a.price;
                e.startamount = a.startamount;
                e.stockvalue = a.stockvalue;
                e.difference = a.difference;
                e.amount = a.amount;
                e.amountnext2 = a.amountnext2;
                e.amountnext3 = a.amountnext3;
                e.amountnext4 = a.amountnext4;
                e.needs1 = a.needs1;
                e.needs2 = a.needs2;
                e.needs3 = a.needs3;
                e.needs4 = a.needs4;
                e.discount = a.discont;
                e.amountemp = (Convert.ToDouble(a.amountnext2) * (-1.2)).ToString();
                if ((Convert.ToDouble(e.delivery_deadline) + Convert.ToDouble(e.difference)) > 1)
                {
                    e.ne_emp = "4";
                }
                else
                {
                    e.ne_emp = "5";
                }
               
                Database.empfehlungen.Add(e);
            }
            else
            {
                Double lieferzeit =( Convert.ToDouble(a.delivery_deadline) +Convert.ToDouble(a.difference))* 5;
                if (lieferzeit > 5 && Convert.ToDouble(a.amountnext3) < 0)
                {
                   
                        EmpfohleneBestellungen e = new EmpfohleneBestellungen();
                        e.id = a.id;
                        e.delivery_deadline = a.delivery_deadline;
                        e.amount_order = a.amount_order;
                        e.NE = a.NE;
                        e.price = a.price;
                        e.startamount = a.startamount;
                        e.stockvalue = a.stockvalue;
                        e.difference = a.difference;
                        e.amount = a.amount;
                        e.amountnext2 = a.amountnext2;
                        e.amountnext3 = a.amountnext3;
                        e.amountnext4 = a.amountnext4;
                        e.needs1 = a.needs1;
                        e.needs2 = a.needs2;
                        e.needs3 = a.needs3;
                        e.needs4 = a.needs4;
                        e.discount = a.discont;

                        e.amountemp = ((Convert.ToDouble(e.needs1) + Convert.ToDouble(e.needs2) + Convert.ToDouble(e.needs3) + Convert.ToDouble(e.needs4))/4*3).ToString();
                        if (lieferzeit > 10)
                        {
                            e.ne_emp = "4";
                        }
                        else
                        {
                            e.ne_emp = "5";
                        }
                        Database.empfehlungen.Add(e);
                    
                }
                else
                {
                    if (lieferzeit > 10 && Convert.ToDouble(a.amountnext4) < 0)
                    {
                        
                            EmpfohleneBestellungen e = new EmpfohleneBestellungen();
                            e.id = a.id;
                            e.delivery_deadline = a.delivery_deadline;
                            e.amount_order = a.amount_order;
                            e.NE = a.NE;
                            e.price = a.price;
                            e.startamount = a.startamount;
                            e.stockvalue = a.stockvalue;
                            e.difference = a.difference;
                            e.amount = a.amount;
                            e.amountnext2 = a.amountnext2;
                            e.amountnext3 = a.amountnext3;
                            e.amountnext4 = a.amountnext4;
                            e.needs1 = a.needs1;
                            e.needs2 = a.needs2;
                            e.needs3 = a.needs3;
                            e.needs4 = a.needs4;
                            e.discount = a.discont;

                            e.amountemp = ((Convert.ToDouble(e.needs1) + Convert.ToDouble(e.needs2) + Convert.ToDouble(e.needs3) + Convert.ToDouble(e.needs4))).ToString();
                            if (lieferzeit > 15)
                            {
                                e.ne_emp = "4";
                            }
                            else
                            {
                                e.ne_emp = "5";
                            }
                            Database.empfehlungen.Add(e);
                        
                    }
                    else
                    {

                    }
                }
            }
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englisch();
        }

        public void englisch()
        {
            message = "Please insert XML!";
            chart1.Titles.Remove(chart1.Titles[0]);
            chart1.Titles.Add("Warehousestock");
            chart2.Titles.Remove(chart2.Titles[0]);
            chart2.Titles.Add("Workingstations");
            chart3.Titles.Remove(chart3.Titles[0]);
            chart3.Titles.Add("Recomendation");
            sprachen = "e";
            tabPage1.Text = "Inward Stockmovement";
            tabPage2.Text = "Recommendations";
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
            button12.Text = "Accept";
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
            neu.amount = textBox1.Text;
            neu.modus = textBox3.Text;
            Database.neuebestellungen.Add(neu);
            dataGridView19.DataSource = null;
            dataGridView19.DataSource = Database.neuebestellungen;
            ;
        }
        public static string sprachen = "d";
        private void button2_Click(object sender, EventArgs e)
        {
            if (xmleingelesen)
            {
                Form1.welches = 1;
                Form1 form = new Form1(sprachen);
                form.p1();
                Form1.welches = 1;
                form.ShowDialog();

                if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
                {
                    if (!tabPage12.Text.Contains("✔"))
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
                MessageBox.Show(message);
            }

          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(xmleingelesen)
            {
            Form1.welches = 2;
            Form1 form = new Form1(sprachen);
            form.p2();
            Form1.welches = 2;
            form.ShowDialog();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
            {
                if (!tabPage12.Text.Contains("✔"))
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
                MessageBox.Show(message);
            }

            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(xmleingelesen)
            {

            Form1.welches = 3;
            Form1 form = new Form1(sprachen);
            form.p3();
            Form1.welches = 3;
            form.ShowDialog();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----"&&label37.Text!="-----"&&label34.Text!="-----")
            {
                if (!tabPage12.Text.Contains("✔"))
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
                MessageBox.Show(message);
            }

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (au1.Count == 0 && au2.Count == 0 && au3.Count == 0)
                return;
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
            label31.Text = au3[0].amount;

            label20.Text = "P2";
            if (au2.Count != 0)
            label29.Text = au2[0].amount;

            label19.Text = "P1";
            if (au1.Count != 0)
            label27.Text = au1[0].amount;

            label34.Text = au4name;
            if (au4.Count != 0)
            {
                label37.Text = "P"+au4[0].id;
                label35.Text = au4[0].amount;
            }

            label37.Text = au5name;
            if (au5.Count != 0)
            {
                label37.Text = "P" + au5[0].id;
                label38.Text = au5[0].amount;
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
            a1.set_up_time = "";
            Fertigungsauftrag f49 = new Fertigungsauftrag();
            f49.amount = "0";
            Fertigungsauftrag f5 = new Fertigungsauftrag();
            f5.amount = "0";
            Fertigungsauftrag f6 = new Fertigungsauftrag();
            f6.amount = "0";
            Fertigungsauftrag f4 = new Fertigungsauftrag();
            f4.amount = "0";
            Fertigungsauftrag f7 = new Fertigungsauftrag();
            f7.amount = "0";
            Fertigungsauftrag f8 = new Fertigungsauftrag();
            f8.amount = "0";
            Fertigungsauftrag f9 = new Fertigungsauftrag();
            f9.amount = "0";
            Fertigungsauftrag f10 = new Fertigungsauftrag();
            f10.amount = "0";
            Fertigungsauftrag f11 = new Fertigungsauftrag();
            f11.amount = "0";
            Fertigungsauftrag f12 = new Fertigungsauftrag();
            f12.amount = "0";
            Fertigungsauftrag f13 = new Fertigungsauftrag();
            f13.amount = "0";
            Fertigungsauftrag f14 = new Fertigungsauftrag();
            f14.amount = "0";
            Fertigungsauftrag f15 = new Fertigungsauftrag();
            f15.amount = "0";
            Fertigungsauftrag f16 = new Fertigungsauftrag();
            f16.amount = "0";
            Fertigungsauftrag f17 = new Fertigungsauftrag();
            f17.amount = "0";
            Fertigungsauftrag f18 = new Fertigungsauftrag();
            f18.amount = "0";
            Fertigungsauftrag f19 = new Fertigungsauftrag();
            f19.amount = "0";
            Fertigungsauftrag f20 = new Fertigungsauftrag();
            f20.amount = "0";
            Fertigungsauftrag f26 = new Fertigungsauftrag();
            f26.amount = "0";

            Fertigungsauftrag f54 = new Fertigungsauftrag();
            f54.amount = "0";
            Fertigungsauftrag f29 = new Fertigungsauftrag();
            f29.amount = "0";
            Fertigungsauftrag f50 = new Fertigungsauftrag();
            f50.amount = "0";
            Fertigungsauftrag f55 = new Fertigungsauftrag();
            f55.amount = "0";
            Fertigungsauftrag f30 = new Fertigungsauftrag();
            f30.amount = "0";
            Fertigungsauftrag f51 = new Fertigungsauftrag();
            f51.amount = "0";
            Fertigungsauftrag f56 = new Fertigungsauftrag();
            f56.amount = "0";
            Fertigungsauftrag f31 = new Fertigungsauftrag();
            f31.amount = "0";
            Fertigungsauftrag f1 = new Fertigungsauftrag();
            f1.amount = "0";
            Fertigungsauftrag f2 = new Fertigungsauftrag();
            f2.amount = "0";
            Fertigungsauftrag f3 = new Fertigungsauftrag();
            f3.amount = "0";

            for(int i = 0; i<erg.Count;i++)
            {
                if (erg[i].amount != "")
                {
                    if (erg[i].id == "49")
                    {

                        if (f49.amount != "")
                            f49.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f49.amount)).ToString());
                        else
                            f49 = erg[i];
                    }

                    if (erg[i].id == "4")
                    {

                        if (f4.amount != "")
                            f4.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f4.amount)).ToString());
                        else
                            f4 = erg[i];
                    }
                    if (erg[i].id == "5")
                    {

                        if (f5.amount != "")
                            f5.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f5.amount)).ToString());
                        else
                            f5 = erg[i];
                    }
                    if (erg[i].id == "6")
                    {

                        if (f6.amount != "")
                            f6.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f6.amount)).ToString());
                        else
                            f6 = erg[i];
                    }
                    if (erg[i].id == "7")
                    {

                        if (f7.amount != "")
                            f7.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f7.amount)).ToString());
                        else
                            f7 = erg[i];
                    }
                    if (erg[i].id == "8")
                    {

                        if (f8.amount != "")
                            f8.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f8.amount)).ToString());
                        else
                            f8 = erg[i];
                    }
                    if (erg[i].id == "9")
                    {

                        if (f9.amount != "")
                            f9.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f9.amount)).ToString());
                        else
                            f9 = erg[i];
                    }
                    if (erg[i].id == "10")
                    {

                        if (f10.amount != "")
                            f10.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f10.amount)).ToString());
                        else
                            f10 = erg[i];
                    }
                    if (erg[i].id == "11")
                    {

                        if (f11.amount != "")
                            f11.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f11.amount)).ToString());
                        else
                            f11 = erg[i];
                    }
                    if (erg[i].id == "12")
                    {

                        if (f12.amount != "")
                            f12.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f12.amount)).ToString());
                        else
                            f12 = erg[i];
                    }
                    if (erg[i].id == "13")
                    {
                        if (f13.amount != "")
                            f13.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f13.amount)).ToString());
                        else
                            f13 = erg[i];
                    }
                    if (erg[i].id == "14")
                    {
                        if (f14.amount != "")
                            f14.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f14.amount)).ToString());
                        else
                            f14 = erg[i];
                    }
                    if (erg[i].id == "15")
                    {
                        if (f15.amount != "")
                            f15.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f15.amount)).ToString());
                        else
                            f15 = erg[i];
                    }
                    if (erg[i].id == "16")
                    {
                        if (f16.amount != "")
                        {
                            if (erg[i].amount == "")
                            {

                            }
                            else
                                f16.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f16.amount)).ToString());
                        }
                        else
                            f16 = erg[i];
                    }
                    if (erg[i].id == "17")
                    {
                        if (f17.amount != "")
                            f17.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f17.amount)).ToString());
                        else
                            f17 = erg[i];
                    }
                    if (erg[i].id == "18")
                    {
                        if (f18.amount != "")
                            f18.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f18.amount)).ToString());
                        else
                            f18 = erg[i];
                    }
                    if (erg[i].id == "19")
                    {
                        if (f19.amount != "")
                            f19.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f19.amount)).ToString());
                        else
                            f19 = erg[i];
                    }
                    if (erg[i].id == "20")
                    {
                        if (f20.amount != "")
                            f20.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f20.amount)).ToString());
                        else
                            f20 = erg[i];
                    }
                    if (erg[i].id == "26")
                    {
                        if (f26.amount != "")
                            f26.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f26.amount)).ToString());
                        else
                            f26 = erg[i];
                    }
                    if (erg[i].id == "54")
                    {
                        if (f54.amount != "")
                            f54.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f54.amount)).ToString());
                        else
                            f54 = erg[i];
                    }
                    if (erg[i].id == "29")
                    {
                        if (f29.amount != "")
                            f29.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f29.amount)).ToString());
                        else
                            f29 = erg[i];
                    }
                    if (erg[i].id == "50")
                    {
                        if (f50.amount != "")
                            f50.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f50.amount)).ToString());
                        else
                            f50 = erg[i];
                    }

                    if (erg[i].id == "55")
                    {
                        if (f55.amount != "")
                            f55.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f55.amount)).ToString());
                        else
                            f55 = erg[i];
                    }

                    if (erg[i].id == "30")
                    {
                        if (f30.amount != "")
                            f30.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f30.amount)).ToString());
                        else
                            f30 = erg[i];
                    }

                    if (erg[i].id == "51")
                    {
                        if (f51.amount != "")
                            f51.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f51.amount)).ToString());
                        else
                            f51 = erg[i];
                    }

                    if (erg[i].id == "56")
                    {
                        if (f56.amount != "")
                            f56.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f56.amount)).ToString());
                        else
                            f56 = erg[i];
                    }

                    if (erg[i].id == "31")
                    {
                        if (f31.amount != "")
                            f31.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f31.amount)).ToString());
                        else
                            f31 = erg[i];
                    }

                    if (erg[i].id == "1")
                    {
                        if (f1.amount != "")
                            f1.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f1.amount)).ToString());
                        else
                            f1 = erg[i];
                    }
                    if (erg[i].id == "2")
                    {
                        if (f2.amount != "")
                            f2.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f2.amount)).ToString());
                        else
                            f2 = erg[i];
                    }
                    if (erg[i].id == "3")
                    {
                        if (f3.amount != "")
                            f3.setMenge((Convert.ToInt32(erg[i].amount) + Convert.ToInt32(f3.amount)).ToString());
                        else
                            f3 = erg[i];
                    }
                }
            }
            Database.arbeitsplaetze = new List<Arbeitsplatz>();
            a1.set_up_time = "60";
            //a1.bearbeitungszeit += (Convert.ToInt32("60"));
            a1.process_time += (Convert.ToInt32(f49.amount) * 6);
            a1.process_time += (Convert.ToInt32(f54.amount) * 6);
            a1.process_time += (Convert.ToInt32(f29.amount) * 6);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a1.station)
                {
                    a1.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }

            Database.arbeitsplaetze.Add(a1);

            Arbeitsplatz a2 = new Arbeitsplatz();
            
            a2.set_up_time = "80";
            //a2.bearbeitungszeit += (Convert.ToInt32("80"));
            a2.process_time += (Convert.ToInt32(f50.amount) * 5);
            a2.process_time += (Convert.ToInt32(f55.amount) * 5);
            a2.process_time += (Convert.ToInt32(f30.amount) * 5);
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

            a3.set_up_time = "60";
            //a3.bearbeitungszeit += (Convert.ToInt32("60"));
            a3.process_time += (Convert.ToInt32(f51.amount) * 5);
            a3.process_time += (Convert.ToInt32(f56.amount) * 6);
            a3.process_time += (Convert.ToInt32(f31.amount) * 6);
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

            a4.set_up_time = "80";
            //a4.bearbeitungszeit += (Convert.ToInt32("80"));
            a4.process_time += (Convert.ToInt32(f1.amount) * 6);
            a4.process_time += (Convert.ToInt32(f2.amount) * 7);
            a4.process_time += (Convert.ToInt32(f3.amount) * 7);
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

            a6.set_up_time = "180";
            //a6.bearbeitungszeit += (Convert.ToInt32("180"));
            a6.process_time += (Convert.ToInt32(f16.amount) * 2);
            a6.process_time += (Convert.ToInt32(f18.amount) * 3);
            a6.process_time += (Convert.ToInt32(f19.amount) * 3);
            a6.process_time += (Convert.ToInt32(f20.amount) * 3);
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

            a7.set_up_time = "350";
            //a7.bearbeitungszeit += (Convert.ToInt32("350"));
            a7.process_time += (Convert.ToInt32(f10.amount) * 2);
            a7.process_time += (Convert.ToInt32(f11.amount) * 2);
            a7.process_time += (Convert.ToInt32(f12.amount) * 2);
            a7.process_time += (Convert.ToInt32(f13.amount) * 2);
            a7.process_time += (Convert.ToInt32(f14.amount) * 2);
            a7.process_time += (Convert.ToInt32(f15.amount) * 2);
            a7.process_time += (Convert.ToInt32(f18.amount) * 2);
            a7.process_time += (Convert.ToInt32(f19.amount) * 2);
            a7.process_time += (Convert.ToInt32(f20.amount) * 2);
            a7.process_time += (Convert.ToInt32(f26.amount) * 2);
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

            a8.set_up_time = "160";
            //a8.bearbeitungszeit += (Convert.ToInt32("160"));
            a8.process_time += (Convert.ToInt32(f10.amount) * 1);
            a8.process_time += (Convert.ToInt32(f11.amount) * 2);
            a8.process_time += (Convert.ToInt32(f12.amount) * 2);
            a8.process_time += (Convert.ToInt32(f13.amount) * 1);
            a8.process_time += (Convert.ToInt32(f14.amount) * 2);
            a8.process_time += (Convert.ToInt32(f15.amount) * 2);
            a8.process_time += (Convert.ToInt32(f18.amount) * 3);
            a8.process_time += (Convert.ToInt32(f19.amount) * 3);
            a8.process_time += (Convert.ToInt32(f20.amount) * 3);
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

            a9.set_up_time = "200";
            //a9.bearbeitungszeit += (Convert.ToInt32("200"));
            a9.process_time += (Convert.ToInt32(f10.amount) * 3);
            a9.process_time += (Convert.ToInt32(f11.amount) * 3);
            a9.process_time += (Convert.ToInt32(f12.amount) * 3);
            a9.process_time += (Convert.ToInt32(f13.amount) * 3);
            a9.process_time += (Convert.ToInt32(f14.amount) * 3);
            a9.process_time += (Convert.ToInt32(f15.amount) * 3);
            a9.process_time += (Convert.ToInt32(f18.amount) * 2);
            a9.process_time += (Convert.ToInt32(f19.amount) * 2);
            a9.process_time += (Convert.ToInt32(f20.amount) * 2);
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

            a10.set_up_time = "120";
            //a10.bearbeitungszeit += (Convert.ToInt32("120"));
            a10.process_time += (Convert.ToInt32(f4.amount) * 4);
            a10.process_time += (Convert.ToInt32(f5.amount) * 4);
            a10.process_time += (Convert.ToInt32(f6.amount) * 4);
            a10.process_time += (Convert.ToInt32(f7.amount) * 4);
            a10.station = "10";
            a10.process_time += (Convert.ToInt32(f8.amount) * 4);
            a10.process_time += (Convert.ToInt32(f9.amount) * 4);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a10.station)
                {
                    a10.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a10);

            Arbeitsplatz a11 = new Arbeitsplatz();

            a11.set_up_time = "160";
            //a11.bearbeitungszeit += (Convert.ToInt32("160"));
            a11.process_time += (Convert.ToInt32(f4.amount) * 3);
            a11.process_time += (Convert.ToInt32(f5.amount) * 3);
            a11.process_time += (Convert.ToInt32(f6.amount) * 3);
            a11.process_time += (Convert.ToInt32(f7.amount) * 3);
            a11.station ="11";
            a11.process_time += (Convert.ToInt32(f8.amount) * 3);
            a11.process_time += (Convert.ToInt32(f9.amount) * 3);
            
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].id == a11.station)
                {
                    a11.kapvor += (Convert.ToInt32(Database.workstationswaitinglist[i].timeneed_complete));
                }
            }
            
            Database.arbeitsplaetze.Add(a11);

            Arbeitsplatz a12 = new Arbeitsplatz();
            a12.process_time += (Convert.ToInt32(f10.amount) * 3);
            a12.process_time += (Convert.ToInt32(f11.amount) * 3);
            a12.process_time += (Convert.ToInt32(f12.amount) * 3);
            a12.process_time += (Convert.ToInt32(f13.amount) * 3);
            a12.process_time += (Convert.ToInt32(f14.amount) * 3);
            a12.process_time += (Convert.ToInt32(f15.amount) * 3);
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
            a13.process_time += (Convert.ToInt32(f10.amount) * 2);
            a13.process_time += (Convert.ToInt32(f11.amount) * 2);
            a13.process_time += (Convert.ToInt32(f12.amount) * 2);
            a13.process_time += (Convert.ToInt32(f13.amount) * 2);
            a13.process_time += (Convert.ToInt32(f14.amount) * 2);
            a13.process_time += (Convert.ToInt32(f15.amount) * 2);
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
            a14.process_time += (Convert.ToInt32(f16.amount) * 3);

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

            a15.set_up_time = "90";
            //a15.bearbeitungszeit += (Convert.ToInt32("90"));
            a15.process_time += (Convert.ToInt32(f17.amount) * 3);
            a15.process_time += (Convert.ToInt32(f26.amount) * 3);

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

            

            //Zufällige Werte generieren
            Random random = new Random();


            chart2.Series.Clear();
            try
            {
                chart2.Series.Add("1");
            }
            catch(Exception err)
            {

            }
            for (int pointIndex = 0; pointIndex < Database.arbeitsplaetze.Count; pointIndex++)
            {
                int gesamtint = Convert.ToInt32(Math.Round(Convert.ToDouble(Database.arbeitsplaetze[pointIndex].total_process_time)));
                gesamtint = gesamtint;
                chart2.Series["1"].Points.Add(gesamtint);
            }

            dataGridView21.DataSource = Database.arbeitsplaetze;
            farbezellenarbeitszeit();
            dataGridView21.DataSource = null;
            dataGridView21.DataSource = Database.arbeitsplaetze;
            farbezellenarbeitszeit();

            if (label19.Text != "-----" && label20.Text != "-----" && label33.Text != "-----" && label37.Text != "-----" && label34.Text != "-----")
            {
                if (!tabPage12.Text.Contains("✔"))
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
                howmuch form = new howmuch(au1,sprachen);
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
                howmuch form = new howmuch(au2,sprachen);
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
                howmuch form = new howmuch(au3,sprachen);
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
                howmuch form = new howmuch(au4,sprachen);
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
                    Database.arbeitsplaetze[i].shift = "1";
                    Database.arbeitsplaetze[i].overtime = "0";
                    
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 2400)
                {
                    //dataGridView21[4, i].Style.BackColor=Color.Yellow;
                    Database.arbeitsplaetze[i].shift = "1";
                    Database.arbeitsplaetze[i].overtime = (Convert.ToInt32(Database.arbeitsplaetze[i].getBearbeitungszeit())-2400).ToString();
                    Database.arbeitsplaetze[i].overtime = (Convert.ToInt32(Database.arbeitsplaetze[i].overtime) / 5).ToString();
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 3600)
                {
                    //dataGridView21[4, i].Style.BackColor = Color.Orange;
                    Database.arbeitsplaetze[i].shift = "2";
                    Database.arbeitsplaetze[i].overtime = "0";
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 4800)
                {
                    //dataGridView21[4, i].Style.BackColor=Color.Yellow;
                    Database.arbeitsplaetze[i].shift = "2";
                    Database.arbeitsplaetze[i].overtime = (Convert.ToInt32(Database.arbeitsplaetze[i].getBearbeitungszeit()) - 4800).ToString();
                    Database.arbeitsplaetze[i].overtime = (Convert.ToInt32(Database.arbeitsplaetze[i].overtime) / 5).ToString();
                }

                if (Database.arbeitsplaetze[i].getBearbeitungszeit() > 7200)
                {
                    //dataGridView21[4, i].Style.BackColor = Color.Red;
                    Database.arbeitsplaetze[i].shift = "3";
                    Database.arbeitsplaetze[i].overtime = "0";
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            XMLCreater.sellwish[0] = textBox4.Text;
            XMLCreater.sellwish[1] = textBox5.Text;
            XMLCreater.sellwish[2] = textBox6.Text;

            Database.prognosen[0].sellwish[0].amount = textBox4.Text;
            Database.prognosen[0].sellwish[1].amount = textBox5.Text;
            Database.prognosen[0].sellwish[2].amount = textBox6.Text;

            Database.prognosen[1].sellwish[0].amount = textBox16.Text;
            Database.prognosen[1].sellwish[1].amount = textBox17.Text;
            Database.prognosen[1].sellwish[2].amount = textBox18.Text;

            Database.prognosen[2].sellwish[0].amount = textBox19.Text;
            Database.prognosen[2].sellwish[1].amount = textBox20.Text;
            Database.prognosen[2].sellwish[2].amount = textBox21.Text;

            Database.prognosen[3].sellwish[0].amount = textBox22.Text;
            Database.prognosen[3].sellwish[1].amount = textBox23.Text;
            Database.prognosen[3].sellwish[2].amount = textBox24.Text;

            label39.Text = " ✔";

            if (label39.Text != "" && label40.Text != "")
            {
                if (!tabPage11.Text.Contains("✔"))
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
                if (!tabPage11.Text.Contains("✔"))
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
                if (!String.IsNullOrEmpty(Database.arbeitsplaetze[i].shift) && Database.arbeitsplaetze[i].shift != "empfohlen" && !String.IsNullOrEmpty(Database.arbeitsplaetze[i].overtime) && Database.arbeitsplaetze[i].overtime != "empfohlen" && Database.arbeitsplaetze[i].station != "" && Database.arbeitsplaetze[i].station != "empfohlen")
                {
                    test++;
                }
            }
            if (test == Database.arbeitsplaetze.Count)
            {
                if(!tabPage13.Text.Contains("✔"))
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

        private void tableLayoutPanel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sCSIMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void sCSIMHomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://scsim-phoenix.de/scs/start");


        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Database.empfehlungen.Count; i++)
            {
                NeueBestellung n = new NeueBestellung();
                n.article = Database.empfehlungen[i].id;
                n.amount = Database.empfehlungen[i].amountemp;
                n.modus = Database.empfehlungen[i].ne_emp;
                Database.neuebestellungen.Add(n);
            }
            dataGridView19.DataSource = Database.neuebestellungen;
        }

    }
}
