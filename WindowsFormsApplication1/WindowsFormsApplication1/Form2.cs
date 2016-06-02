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

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public static List<Fertigungsauftrag> au1 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au2 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au3 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au4 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au5 = new List<Fertigungsauftrag>();

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
            this.BackColor = Color.FromArgb(211, 211, 211); // this should be pink-ish
            tabPage1.BackColor = Color.FromArgb(145, 222, 232); // this should be pink-ish
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
            tabPage12.BackColor = Color.FromArgb(35, 160, 122); // this should be pink-ish
            tabPage13.BackColor = Color.FromArgb(25, 2, 2); // this should be pink-ish
            label1.Text = "Version: 1.5.2.1               MMJ$ Group Ltd.              "+ DateTime.Now.ToString();
            Image myimage = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\herren2.jpg");
            pictureBox1.Image=( myimage);
            Image myimage2 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\frau.jpg");
            pictureBox2.Image = (myimage2);
            Image myimage3 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\kinder.jpg");
            pictureBox3.Image = (myimage3);
            pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
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
                    Database.lager.Add(a);
                }
                dataGridView1.DataSource = Database.lager;
                label3.Text = "Gesamter Lagerwert: ";
                label4.Text = xmlnode[0].ChildNodes.Item(xmlnode[0].ChildNodes.Count - 1).InnerText.ToString() + " €";
                
                xmlnode = xmldoc.GetElementsByTagName("futureinwardstockmovement");
                Database.zukunftigeEingänge = new List<Futureinwardstockmovement>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
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
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
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


                label2.Text = "XML eingelesen";
            }
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
            tabPage2.Text = "Lagerbestand";
            tabPage3.Text = "Zukünftige Eingänge";
            tabPage4.Text = "Wartekosten";
            tabPage5.Text = "Warteliste Arbeitsplätze";
            tabPage6.Text = "Warteliste Lager";
            tabPage7.Text = "Aufträge in Bearbeitung";
            tabPage8.Text = "Beendete Aufträge";
            tabPage9.Text = "Durchlaufzeiten";
            tabPage10.Text = "Ergebnisse";
            tabPage11.Text = "Dashboard";
            tabPage12.Text = "Produktion";
            tabPage13.Text = "Arbeitszeit";
            label3.Text = "Gesamter Lagerwert: ";
            deutschToolStripMenuItem.Text = "Deutsch";
            englischToolStripMenuItem.Text = "Englisch";
            dateiToolStripMenuItem.Text = "Datei";
            xMLImportierenToolStripMenuItem.Text = "Xml importieren";
            xMLExportierenToolStripMenuItem.Text = "Xml exportieren";
            spracheToolStripMenuItem.Text = "Sprache";
            label2.Text = "Sprache: Deutsch";
        }

        private void englischToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englisch();
        }

        public void englisch()
        {
            tabPage1.Text = "Inward Stockmovement";
            tabPage2.Text = "Warehousestock";
            tabPage3.Text = "Future Orders";
            tabPage4.Text = "Ideltimecosts";
            tabPage5.Text = "Waitinglistworkstations";
            tabPage6.Text = "Waitingliststock";
            tabPage7.Text = "Orders in Work";
            tabPage8.Text = "Completed Orders";
            tabPage9.Text = "Cycletimes";
            tabPage10.Text = "Results";
            label3.Text = "Totalstockvalue: ";
            deutschToolStripMenuItem.Text = "German";
            englischToolStripMenuItem.Text = "Englisch";
            dateiToolStripMenuItem.Text = "Data";
            spracheToolStripMenuItem.Text = "Language";
            xMLImportierenToolStripMenuItem.Text = "Xml Import";
            xMLExportierenToolStripMenuItem.Text = "Xml Export";
            label2.Text = "Language: Englisch";
        }

        private void xMLExportierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = XMLCreater.Create();
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
            Form1 form = new Form1();
            form.p1();
            Form1.welches = 1;
            form.ShowDialog();

          
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.p2();
            Form1.welches = 2;
            form.ShowDialog();

            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.p3();
            Form1.welches = 3;
            form.ShowDialog();

            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            label33.Text = "P3";
            if(au3.Count!=0)
            label31.Text = au3[0].menge;

            label20.Text = "P2";
            if (au2.Count != 0)
            label29.Text = au2[0].menge;

            label19.Text = "P1";
            if (au1.Count != 0)
            label27.Text = au1[0].menge;

            if (au4.Count != 0)
            {
                label37.Text = au4[0].artikel;
                label35.Text = au4[0].menge;
            }

            label37.Text = "P1";
            if (au5.Count != 0)
            {
                label37.Text = au5[0].artikel;
                label38.Text = au5[0].menge;
            }
            List<Fertigungsauftrag> erg = new List<Fertigungsauftrag>();
            for (int i = 0; i < au1.Count; i++)
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

            dataGridView20.DataSource = erg;

            Arbeitsplatz a1 = new Arbeitsplatz();
            a1.station = "1";
            a1.rustzeit = "";
            Fertigungsauftrag f49 = new Fertigungsauftrag();
            Fertigungsauftrag f5 = new Fertigungsauftrag();
            Fertigungsauftrag f6 = new Fertigungsauftrag();
            Fertigungsauftrag f4 = new Fertigungsauftrag();

            Fertigungsauftrag f7 = new Fertigungsauftrag();
            Fertigungsauftrag f8 = new Fertigungsauftrag();
            Fertigungsauftrag f9 = new Fertigungsauftrag();

            Fertigungsauftrag f10 = new Fertigungsauftrag();
            Fertigungsauftrag f11 = new Fertigungsauftrag();
            Fertigungsauftrag f12 = new Fertigungsauftrag();

            Fertigungsauftrag f13 = new Fertigungsauftrag();
            Fertigungsauftrag f14 = new Fertigungsauftrag();
            Fertigungsauftrag f15 = new Fertigungsauftrag();

            Fertigungsauftrag f16 = new Fertigungsauftrag();
            Fertigungsauftrag f17 = new Fertigungsauftrag();
            Fertigungsauftrag f18 = new Fertigungsauftrag();

            Fertigungsauftrag f19 = new Fertigungsauftrag();
            Fertigungsauftrag f20 = new Fertigungsauftrag();
            Fertigungsauftrag f26 = new Fertigungsauftrag();


            Fertigungsauftrag f54 = new Fertigungsauftrag();
            Fertigungsauftrag f29 = new Fertigungsauftrag();

            Fertigungsauftrag f50 = new Fertigungsauftrag();
            Fertigungsauftrag f55 = new Fertigungsauftrag();
            Fertigungsauftrag f30 = new Fertigungsauftrag();

            Fertigungsauftrag f51 = new Fertigungsauftrag();
            Fertigungsauftrag f56 = new Fertigungsauftrag();
            Fertigungsauftrag f31 = new Fertigungsauftrag();

            Fertigungsauftrag f1 = new Fertigungsauftrag();
            Fertigungsauftrag f2 = new Fertigungsauftrag();
            Fertigungsauftrag f3 = new Fertigungsauftrag();


            for(int i = 0; i<erg.Count;i++)
            {
                if(erg[i].artikel=="49")
                {
                    f49 = new Fertigungsauftrag();
                    if(f49.menge!="")
                    f49.menge = (Convert.ToInt32(erg[i].menge)+f49.menge);
                    else
                        f49 = erg[i];
                }

                if(erg[i].artikel=="4")
                {
                    f4 = new Fertigungsauftrag();
                    if(f4.menge!="")
                    f16.menge = (Convert.ToInt32(erg[i].menge)+f4.menge);
                    else
                        f4 = erg[i];
                }
                if(erg[i].artikel=="5")
                {
                    f5 = new Fertigungsauftrag();
                    if(f5.menge!="")
                    f5.menge = (Convert.ToInt32(erg[i].menge)+f5.menge);
                    else
                        f5 = erg[i];
                }
                if(erg[i].artikel=="6")
                {
                    f6 = new Fertigungsauftrag();
                    if(f6.menge!="")
                    f6.menge = (Convert.ToInt32(erg[i].menge)+f6.menge);
                    else
                        f6 = erg[i];
                }
                if(erg[i].artikel=="7")
                {
                   f7 = new Fertigungsauftrag();
                    if(f7.menge!="")
                    f7.menge = (Convert.ToInt32(erg[i].menge)+f7.menge);
                    else
                        f7 = erg[i];
                }
                if(erg[i].artikel=="8")
                {
                    f8 = new Fertigungsauftrag();
                    if(f8.menge!="")
                    f8.menge = (Convert.ToInt32(erg[i].menge)+f8.menge);
                    else
                        f8 = erg[i];
                }
                if(erg[i].artikel=="9")
                {
                    f9 = new Fertigungsauftrag();
                    if(f9.menge!="")
                    f9.menge = (Convert.ToInt32(erg[i].menge)+f9.menge);
                    else
                        f9 = erg[i];
                }
                if(erg[i].artikel=="10")
                {
                    f10 = new Fertigungsauftrag();
                    if(f10.menge!="")
                    f10.menge = (Convert.ToInt32(erg[i].menge)+f10.menge);
                    else
                        f10 = erg[i];
                }
                if(erg[i].artikel=="11")
                {
                    f11 = new Fertigungsauftrag();
                    if(f11.menge!="")
                    f11.menge = (Convert.ToInt32(erg[i].menge)+f11.menge);
                    else
                        f11 = erg[i];
                }
                if(erg[i].artikel=="12")
                {
                    f12 = new Fertigungsauftrag();
                    if(f12.menge!="")
                    f12.menge = (Convert.ToInt32(erg[i].menge)+f12.menge);
                    else
                        f12 = erg[i];
                }
                if(erg[i].artikel=="13")
                {
                    f13 = new Fertigungsauftrag();
                    if(f13.menge!="")
                    f13.menge = (Convert.ToInt32(erg[i].menge)+f13.menge);
                    else
                        f13 = erg[i];
                }
                if(erg[i].artikel=="14")
                {
                    f14 = new Fertigungsauftrag();
                    if(f14.menge!="")
                    f14.menge = (Convert.ToInt32(erg[i].menge)+f14.menge);
                    else
                        f14 = erg[i];
                }
                if(erg[i].artikel=="15")
                {
                    f15 = new Fertigungsauftrag();
                    if(f15.menge!="")
                    f15.menge = (Convert.ToInt32(erg[i].menge)+f15.menge);
                    else
                        f15 = erg[i];
                }
                if(erg[i].artikel=="16")
                {
                    f16 = new Fertigungsauftrag();
                    if(f16.menge!="")
                    f16.menge = (Convert.ToInt32(erg[i].menge)+f16.menge);
                    else
                        f16 = erg[i];
                }
                if(erg[i].artikel=="17")
                {
                    f17 = new Fertigungsauftrag();
                    if(f17.menge!="")
                    f17.menge = (Convert.ToInt32(erg[i].menge)+f17.menge);
                    else
                        f17 = erg[i];
                }
                if(erg[i].artikel=="18")
                {
                    f18 = new Fertigungsauftrag();
                    if(f18.menge!="")
                    f18.menge = (Convert.ToInt32(erg[i].menge)+f18.menge);
                    else
                        f18 = erg[i];
                }
                if(erg[i].artikel=="19")
                {
                    f19 = new Fertigungsauftrag();
                    if(f19.menge!="")
                    f19.menge = (Convert.ToInt32(erg[i].menge)+f19.menge);
                    else
                        f19 = erg[i];
                }
                if(erg[i].artikel=="20")
                {
                    f20 = new Fertigungsauftrag();
                    if(f20.menge!="")
                    f20.menge = (Convert.ToInt32(erg[i].menge)+f20.menge);
                    else
                        f20 = erg[i];
                }
                if(erg[i].artikel=="26")
                {
                    f26 = new Fertigungsauftrag();
                    if(f26.menge!="")
                    f26.menge = (Convert.ToInt32(erg[i].menge)+f26.menge);
                    else
                        f26 = erg[i];
                }
                if(erg[i].artikel=="54")
                {
                    f54 = new Fertigungsauftrag();
                    if(f54.menge!="")
                    f54.menge = (Convert.ToInt32(erg[i].menge)+f54.menge);
                    else
                        f54 = erg[i];
                }
                if(erg[i].artikel=="29")
                {
                    f29 = new Fertigungsauftrag();
                    if(f29.menge!="")
                    f29.menge = (Convert.ToInt32(erg[i].menge)+f29.menge);
                    else
                        f29 = erg[i];
                }
                if(erg[i].artikel=="50")
                {
                    f50 = new Fertigungsauftrag();
                    if(f50.menge!="")
                    f50.menge = (Convert.ToInt32(erg[i].menge)+f50.menge);
                    else
                        f50 = erg[i];
                }

                if(erg[i].artikel=="55")
                {
                    f55 = new Fertigungsauftrag();
                    if(f55.menge!="")
                    f55.menge = (Convert.ToInt32(erg[i].menge)+f55.menge);
                    else
                        f55 = erg[i];
                }

                if(erg[i].artikel=="30")
                {
                    f30 = new Fertigungsauftrag();
                    if(f30.menge!="")
                    f30.menge = (Convert.ToInt32(erg[i].menge)+f30.menge);
                    else
                        f30 = erg[i];
                }

                if(erg[i].artikel=="51")
                {
                    f51 = new Fertigungsauftrag();
                    if(f51.menge!="")
                    f51.menge = (Convert.ToInt32(erg[i].menge)+f51.menge);
                    else
                        f51 = erg[i];
                }

                if(erg[i].artikel=="56")
                {
                    f56 = new Fertigungsauftrag();
                    if(f56.menge!="")
                    f56.menge = (Convert.ToInt32(erg[i].menge)+f56.menge);
                    else
                        f56 = erg[i];
                }

                if(erg[i].artikel=="31")
                {
                    f31 = new Fertigungsauftrag();
                    if(f31.menge!="")
                    f31.menge = (Convert.ToInt32(erg[i].menge)+f31.menge);
                    else
                        f31 = erg[i];
                }

                if(erg[i].artikel=="1")
                {
                    f1 = new Fertigungsauftrag();
                    if(f1.menge!="")
                    f1.menge = (Convert.ToInt32(erg[i].menge)+f1.menge);
                    else
                        f1 = erg[i];
                }
                if(erg[i].artikel=="2")
                {
                    f2 = new Fertigungsauftrag();
                    if(f2.menge!="")
                    f2.menge = (Convert.ToInt32(erg[i].menge)+f2.menge);
                    else
                        f2 = erg[i];
                }
                if(erg[i].artikel=="3")
                {
                    f3 = new Fertigungsauftrag();
                    if(f3.menge!="")
                    f3.menge = (Convert.ToInt32(erg[i].menge)+f3.menge);
                    else
                        f3 = erg[i];
                }
            }
            a1.bearbeitungszeit += (Convert.ToInt32(f49.menge) * 6);
            a1.bearbeitungszeit += (Convert.ToInt32(f54.menge) * 6);
            a1.bearbeitungszeit += (Convert.ToInt32(f29.menge) * 6);

            Database.arbeitsplaetze.Add(a1);

            Arbeitsplatz a2 = new Arbeitsplatz();
            a2.bearbeitungszeit += (Convert.ToInt32(f50.menge) * 6);
            a2.bearbeitungszeit += (Convert.ToInt32(f55.menge) * 6);
            a2.bearbeitungszeit += (Convert.ToInt32(f30.menge) * 6);
            a2.station = "2";
            Database.arbeitsplaetze.Add(a2);

            Arbeitsplatz a3 = new Arbeitsplatz();
            a3.bearbeitungszeit += (Convert.ToInt32(f51.menge) * 5);
            a3.bearbeitungszeit += (Convert.ToInt32(f56.menge) * 6);
            a3.bearbeitungszeit += (Convert.ToInt32(f31.menge) * 6);
            a3.station = "3";
            Database.arbeitsplaetze.Add(a3);

            Arbeitsplatz a4 = new Arbeitsplatz();
            a4.bearbeitungszeit += (Convert.ToInt32(f1.menge) * 6);
            a4.bearbeitungszeit += (Convert.ToInt32(f2.menge) * 7);
            a4.bearbeitungszeit += (Convert.ToInt32(f3.menge) * 7);
            a4.station = "4";
            Database.arbeitsplaetze.Add(a4);

            Arbeitsplatz a5 = new Arbeitsplatz();
            a5.station = "5";

            Database.arbeitsplaetze.Add(a5);

            Arbeitsplatz a6 = new Arbeitsplatz();
            a6.bearbeitungszeit += (Convert.ToInt32(f16.menge) * 2);
            a6.bearbeitungszeit += (Convert.ToInt32(f18.menge) * 3);
            a6.bearbeitungszeit += (Convert.ToInt32(f19.menge) * 3);
            a6.bearbeitungszeit += (Convert.ToInt32(f20.menge) * 3);
            a6.station = "6";
            Database.arbeitsplaetze.Add(a6);

            Arbeitsplatz a7 = new Arbeitsplatz();
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
            Database.arbeitsplaetze.Add(a7);

            

            Arbeitsplatz a8 = new Arbeitsplatz();
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
            Database.arbeitsplaetze.Add(a8);

            Arbeitsplatz a9 = new Arbeitsplatz();
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
            Database.arbeitsplaetze.Add(a9);

            Arbeitsplatz a10 = new Arbeitsplatz();
            a10.bearbeitungszeit += (Convert.ToInt32(f4.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f5.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f6.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f7.menge) * 4);
            a10.station = "10";
            a10.bearbeitungszeit += (Convert.ToInt32(f8.menge) * 4);
            a10.bearbeitungszeit += (Convert.ToInt32(f9.menge) * 4);
            Database.arbeitsplaetze.Add(a10);

            Arbeitsplatz a11 = new Arbeitsplatz();
            a11.bearbeitungszeit += (Convert.ToInt32(f4.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f5.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f6.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f7.menge) * 3);
            a11.station =" 11";
            a11.bearbeitungszeit += (Convert.ToInt32(f8.menge) * 3);
            a11.bearbeitungszeit += (Convert.ToInt32(f9.menge) * 3);
            Database.arbeitsplaetze.Add(a11);

            Arbeitsplatz a12 = new Arbeitsplatz();
            a12.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 3);
            a12.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 3);
            a12.station = "12";
            Database.arbeitsplaetze.Add(a12);
            Arbeitsplatz a13 = new Arbeitsplatz();
            a13.bearbeitungszeit += (Convert.ToInt32(f10.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f11.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f12.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f13.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f14.menge) * 2);
            a13.bearbeitungszeit += (Convert.ToInt32(f15.menge) * 2);
            a13.station = "13";
            Database.arbeitsplaetze.Add(a13);
            Arbeitsplatz a14 = new Arbeitsplatz();
            a14.bearbeitungszeit += (Convert.ToInt32(f16.menge) * 3);

            a14.station = "14";
            Database.arbeitsplaetze.Add(a14);
            Arbeitsplatz a15 = new Arbeitsplatz();
            a15.bearbeitungszeit += (Convert.ToInt32(f17.menge) * 3);
            a15.bearbeitungszeit += (Convert.ToInt32(f26.menge) * 3);

            a15.station = "15";
            Database.arbeitsplaetze.Add(a15);


            dataGridView21.DataSource = Database.arbeitsplaetze;
            farbezellenarbeitszeit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            howmuch form = new howmuch(au1);
            form.Show();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            howmuch form = new howmuch(au2);
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            howmuch form = new howmuch(au3);
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            howmuch form = new howmuch(au4);
            form.Show();
        }

        private void dataGridView21_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void farbezellenarbeitszeit()
        {
            for (int i = 0; i < Database.arbeitsplaetze.Count; i++)
            {
                if(Database.arbeitsplaetze[i].bearbeitungszeit >3600)
                {
                    dataGridView21[4, i].Style.BackColor=Color.Yellow;
                    Database.arbeitsplaetze[i].ueberstunden = "empfohlen";
                }

                if (Database.arbeitsplaetze[i].bearbeitungszeit > 5400)
                {
                    dataGridView21[4, i].Style.BackColor = Color.Orange;
                    Database.arbeitsplaetze[i].schicht = "empfohlen";
                    Database.arbeitsplaetze[i].ueberstunden = "";
                }
            }
        }
    }
}
