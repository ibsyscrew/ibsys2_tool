using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EingabeBestellung : Form
    {
        public static NeueBestellung neue;
        public EingabeBestellung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NeueBestellung neu = new NeueBestellung();
            neu.article = textBox1.Text;
            neu.menge = textBox2.Text;
            neu.modus = textBox3.Text;
            neue = neu;

            
        }
    }
}
