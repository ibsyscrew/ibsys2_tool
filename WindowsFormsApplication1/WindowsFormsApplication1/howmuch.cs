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
        public howmuch(List<Fertigungsauftrag> f, string s)
        {
            auftragteil1 = f;
            InitializeComponent();
            Image myimage7 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\background.jpg");

            tableLayoutPanel1.BackgroundImage = myimage7;

            
            Image myimage4 = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\MMJ$Logo3.jpg");
            pictureBox1.Image = (myimage4);

            sprachen = s;

            if (sprachen == "d")
            {
                deutsch();
            }
            else
            {
                englisch();
            }

        }

        public string sprachen = "d";

        public howmuch(string s)
        {
            sprachen = s;

            if(sprachen == "d")
            {
                deutsch();
            }
            else
            {
                englisch();
            }
        }

        public string message = "";

        public void deutsch()
        {
            label1.Text = "Menge";
            label3.Text = "Menge neu";
            button1.Text = "Fertig";
            message = "Mehr als 5 Aufteilungen gehen nicht!";
        }

        public void englisch()
        {
            label1.Text = "Amount";
            label3.Text = "Amount new";
            button1.Text = "Apply";
            message = "Not more than 5!";

        }

        List<Fertigungsauftrag> auftragteil2 = new List<Fertigungsauftrag>();

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<auftragteil1.Count;i++)
            {
                Fertigungsauftrag f1 = new Fertigungsauftrag();
                f1.id = auftragteil1[i].id;
                f1.setMenge(textBox1.Text) ;
                auftragteil2.Add(f1);
                auftragteil1[i].setMenge((Convert.ToInt32(auftragteil1[i].amount) - Convert.ToInt32(textBox1.Text)).ToString());
            }

            if (Form2.au4.Count == 0)
            {
                //Form2.au2 = auftragteil1;

                Form2.au4 = auftragteil2;
                Form2.au4name = "P"+auftragteil2[0].id;
                this.Close();
                return;
            }
            if (Form2.au5.Count==0)
            {
                Form2.au5 = auftragteil2;
                Form2.au5name = "P"+auftragteil2[0].id;
                //Form2.au2 = auftragteil1;
                this.Close();
                return;
            }

            MessageBox.Show(message);
            this.Close();
        }
    }
}
