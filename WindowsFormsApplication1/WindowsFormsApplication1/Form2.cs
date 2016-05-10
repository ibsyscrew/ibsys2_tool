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
        public Form2()
        {
            InitializeComponent();
            deutsch();
            label1.Text = "Version: 1.5.2.1               MMJ$ Group Ltd.              "+ DateTime.Now.ToString();
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
                xmldoc.Load(fs);

                xmlnode = xmldoc.GetElementsByTagName("inwardstockmovement");
                Database.bestellungen = new List<Bestellung>();
                for(int i = 0; i < xmlnode[0].ChildNodes.Count-1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Bestellung a = new Bestellung(xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), 
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
                Database.lager = new List<Artikel>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Artikel a = new Artikel(xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString(), xmlnode[0].ChildNodes.Item(i).Attributes[5].Value.ToString());
                    Database.lager.Add(a);
                }
                dataGridView1.DataSource = Database.lager;
                label3.Text = "Gesamter Lagerwert: ";
                label4.Text = xmlnode[0].ChildNodes.Item(xmlnode[0].ChildNodes.Count - 1).InnerText.ToString() + " €";
                
                xmlnode = xmldoc.GetElementsByTagName("futureinwardstockmovement");
                Database.zukunftigeEingänge = new List<Ausstehende_Bestellungen>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Ausstehende_Bestellungen a = new Ausstehende_Bestellungen(
                        xmlnode[0].ChildNodes.Item(i).Attributes[0].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[1].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[2].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[3].Value.ToString(), 
                        xmlnode[0].ChildNodes.Item(i).Attributes[4].Value.ToString()); ;
                    Database.zukunftigeEingänge.Add(a);
                }
                dataGridView3.DataSource = Database.zukunftigeEingänge;

                xmlnode = xmldoc.GetElementsByTagName("idletimecosts");
                Database.strafkosten = new List<Leerzeitenkosten>();
                for (int i = 0; i < xmlnode[0].ChildNodes.Count - 1; i++)
                {
                    //MessageBox.Show("Zeug: " + xmlnode[0].ChildNodes.Item(0).Attributes[0].Value.ToString());
                    Leerzeitenkosten a = new Leerzeitenkosten(
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
            tabPage6.Text = "Warteliste Material";
            tabPage7.Text = "Aufträge in Bearbeitung";
            tabPage8.Text = "Beendete Aufträge";
            tabPage7.Text = "Durchlaufzeiten";
            tabPage8.Text = "Ergebnisse";
            label3.Text = "Gesamter Lagerwert: ";
            deutschToolStripMenuItem.Text = "Deutsch";
            englischToolStripMenuItem.Text = "Englisch";
            dateiToolStripMenuItem.Text = "Datei";
            xMLImportierenToolStripMenuItem.Text = "Xml importieren";
            xMLExportierenToolStripMenuItem.Text = "Xml exportieren";
            spracheToolStripMenuItem.Text = "Sprache";
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
            tabPage7.Text = "Cycletimes";
            tabPage8.Text = "Results";
            label3.Text = "Totalstockvalue: ";
            deutschToolStripMenuItem.Text = "German";
            englischToolStripMenuItem.Text = "Englisch";
            dateiToolStripMenuItem.Text = "Data";
            spracheToolStripMenuItem.Text = "Language";
            xMLImportierenToolStripMenuItem.Text = "Xml Import";
            xMLExportierenToolStripMenuItem.Text = "Xml Export";
        }
    }
}
