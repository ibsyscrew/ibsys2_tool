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
    public partial class howmuch : Form
    {
        List<Fertigungsauftrag> auftragteil1 = new List<Fertigungsauftrag>();
        public howmuch(List<Fertigungsauftrag> f)
        {
            auftragteil1 = f;
            InitializeComponent();
            Image myimage7 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\background.jpg");

            tableLayoutPanel1.BackgroundImage = myimage7;

            
            Image myimage4 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\MMJ$Logo3.jpg");
            pictureBox1.Image = (myimage4);

        }
        List<Fertigungsauftrag> auftragteil2 = new List<Fertigungsauftrag>();

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<auftragteil1.Count;i++)
            {
                Fertigungsauftrag f1 = new Fertigungsauftrag();
                f1.artikel = auftragteil1[i].artikel;
                f1.menge = textBox1.Text ;
                auftragteil2.Add(f1);
                auftragteil1[i].menge = (Convert.ToInt32(auftragteil1[i].menge) - Convert.ToInt32(textBox1.Text)).ToString();
            }

            if (Form2.au4.Count == 0)
            {
                //Form2.au2 = auftragteil1;

                Form2.au4 = auftragteil2;
                Form2.au4name = "P"+auftragteil2[0].artikel;
                this.Close();
                return;
            }
            if (Form2.au5.Count==0)
            {
                Form2.au5 = auftragteil2;
                Form2.au5name = "P"+auftragteil2[0].artikel;
                //Form2.au2 = auftragteil1;
                this.Close();
                return;
            }

            MessageBox.Show("Mehr als 5 gehen nicht");
            this.Close();
        }
    }
}
