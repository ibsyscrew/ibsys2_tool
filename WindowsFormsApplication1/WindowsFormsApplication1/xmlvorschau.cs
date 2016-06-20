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

namespace WindowsFormsApplication1
{
    public partial class xmlvorschau : Form
    {
        public xmlvorschau()
        {
            InitializeComponent();

            XmlDocument xmldoc = XMLCreater.Create();
            //highlighter.HighlightRTF(richTextBox1);
            richTextBox1.Text = highlighter.PrintXML(xmldoc.OuterXml);
            //highlighter.HighlightRTF(richTextBox1);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
