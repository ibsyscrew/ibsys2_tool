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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox10.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld6Errechnung(textBox1.Text);
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox6.Text;
            textBox14.Text = textBox6.Text;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
         
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld6Errechnung(textBox2.Text);
        }

        public void wertkontrolleFeld6Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                { 
                    textBox6.Text = (Convert.ToInt32(textBox1.Text) + Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox3.Text) - Convert.ToInt32(textBox4.Text) - Convert.ToInt32(textBox5.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld13Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox13.Text = (Convert.ToInt32(textBox7.Text) + Convert.ToInt32(textBox8.Text) - Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox10.Text) - Convert.ToInt32(textBox11.Text) - Convert.ToInt32(textBox12.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld6Errechnung(textBox4.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld6Errechnung(textBox4.Text);
            textBox8.Text = textBox4.Text;
            textBox15.Text = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld6Errechnung(textBox5.Text);
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            textBox22.Text = textBox18.Text;
            textBox29.Text = textBox18.Text;
            textBox36.Text = textBox18.Text;
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox13.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox7.Text);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox8.Text);
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox9.Text);
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox11.Text);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld13Errechnung(textBox12.Text);
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld20Errechnung(textBox14.Text);
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld20Errechnung(textBox15.Text);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld20Errechnung(textBox16.Text);
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld20Errechnung(textBox17.Text);
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld20Errechnung(textBox19.Text);
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox21.Text);
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox22.Text);
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox23.Text);
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox24.Text);
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox25.Text);
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld27Errechnung(textBox26.Text);
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox28.Text);
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox29.Text);
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox30.Text);
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox31.Text);
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox32.Text);
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld34Errechnung(textBox33.Text);
        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox35.Text);
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox36.Text);
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox37.Text);
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox38.Text);
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox39.Text);
            textBox43.Text = textBox39.Text;
            textBox50.Text = textBox39.Text;
            textBox57.Text = textBox39.Text;

        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld41Errechnung(textBox40.Text);
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox42.Text);
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox43.Text);
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox44.Text);
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox45.Text);
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox46.Text);
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld48Errechnung(textBox47.Text);
        }

        private void textBox49_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox49.Text);
        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox50.Text);
        }

        private void textBox51_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox51.Text);
        }

        private void textBox52_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox52.Text);
        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox53.Text);
        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld55Errechnung(textBox54.Text);
        }

        private void textBox56_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox56.Text);
        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox57.Text);
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox58.Text);
        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox59.Text);
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox60.Text);
            textBox64.Text = textBox60.Text;
            textBox71.Text = textBox60.Text;
            textBox78.Text = textBox60.Text;
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld62Errechnung(textBox61.Text);
        }

        private void textBox63_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox63.Text);
        }

        private void textBox64_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox64.Text);
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox65.Text);
        }

        private void textBox66_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox66.Text);
        }

        private void textBox67_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox67.Text);
        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld69Errechnung(textBox68.Text);
        }

        private void textBox70_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox70.Text);
        }

        private void textBox71_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox71.Text);
        }

        private void textBox72_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox72.Text);
        }

        private void textBox73_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox73.Text);
        }

        private void textBox74_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox74.Text);
        }

        private void textBox75_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld76Errechnung(textBox75.Text);
        }

        public void wertkontrolleFeld20Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox20.Text = (Convert.ToInt32(textBox14.Text) + Convert.ToInt32(textBox15.Text) + Convert.ToInt32(textBox16.Text) - Convert.ToInt32(textBox17.Text) - Convert.ToInt32(textBox18.Text) - Convert.ToInt32(textBox19.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld27Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox27.Text = (Convert.ToInt32(textBox21.Text) + Convert.ToInt32(textBox22.Text) + Convert.ToInt32(textBox23.Text) - Convert.ToInt32(textBox26.Text) - Convert.ToInt32(textBox24.Text) - Convert.ToInt32(textBox25.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld34Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox34.Text = (Convert.ToInt32(textBox28.Text) + Convert.ToInt32(textBox29.Text) + Convert.ToInt32(textBox30.Text) - Convert.ToInt32(textBox31.Text) - Convert.ToInt32(textBox33.Text) - Convert.ToInt32(textBox34.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld41Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox41.Text = (Convert.ToInt32(textBox35.Text) + Convert.ToInt32(textBox36.Text) + Convert.ToInt32(textBox37.Text) - Convert.ToInt32(textBox38.Text) - Convert.ToInt32(textBox39.Text) - Convert.ToInt32(textBox40.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld48Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox48.Text = (Convert.ToInt32(textBox42.Text) + Convert.ToInt32(textBox43.Text) + Convert.ToInt32(textBox44.Text) - Convert.ToInt32(textBox45.Text) - Convert.ToInt32(textBox46.Text) - Convert.ToInt32(textBox47.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld55Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox55.Text = (Convert.ToInt32(textBox49.Text) + Convert.ToInt32(textBox50.Text) + Convert.ToInt32(textBox51.Text) - Convert.ToInt32(textBox52.Text) - Convert.ToInt32(textBox53.Text) - Convert.ToInt32(textBox54.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld62Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox62.Text = (Convert.ToInt32(textBox56.Text) + Convert.ToInt32(textBox57.Text) + Convert.ToInt32(textBox58.Text) - Convert.ToInt32(textBox59.Text) - Convert.ToInt32(textBox60.Text) - Convert.ToInt32(textBox61.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld69Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox69.Text = (Convert.ToInt32(textBox63.Text) + Convert.ToInt32(textBox64.Text) + Convert.ToInt32(textBox65.Text) - Convert.ToInt32(textBox66.Text) - Convert.ToInt32(textBox67.Text) - Convert.ToInt32(textBox68.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        public void wertkontrolleFeld76Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox76.Text = (Convert.ToInt32(textBox70.Text) + Convert.ToInt32(textBox71.Text) + Convert.ToInt32(textBox72.Text) - Convert.ToInt32(textBox73.Text) - Convert.ToInt32(textBox74.Text) - Convert.ToInt32(textBox75.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            textBox21.Text = textBox20.Text;
            textBox28.Text = textBox20.Text;
            textBox35.Text = textBox20.Text;

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            textBox42.Text = textBox41.Text;
            textBox49.Text = textBox41.Text;
            textBox56.Text = textBox41.Text;
        }

        private void textBox62_TextChanged(object sender, EventArgs e)
        {
            textBox63.Text = textBox62.Text;
            textBox70.Text = textBox62.Text;
            textBox77.Text = textBox62.Text;
        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox77.Text);
        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox78.Text);
        }

        private void textBox79_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox79.Text);
        }

        private void textBox80_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox80.Text);
        }

        private void textBox81_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox81.Text);
        }

        private void textBox82_TextChanged(object sender, EventArgs e)
        {
            wertkontrolleFeld83Errechnung(textBox82.Text);
        }

        private void textBox83_TextChanged(object sender, EventArgs e)
        {

        }

        public void wertkontrolleFeld83Errechnung(String s)
        {
            try
            {
                if (s == "")
                {

                }
                else
                {
                    textBox83.Text = (Convert.ToInt32(textBox77.Text) + Convert.ToInt32(textBox78.Text) + Convert.ToInt32(textBox79.Text) - Convert.ToInt32(textBox80.Text) - Convert.ToInt32(textBox81.Text) - Convert.ToInt32(textBox82.Text)).ToString();
                }
            }
            catch (Exception err)
            {
                // MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
                tipps.Text = "Bitte eine Zahl eingeben!!!!!!";
            }
        }
    }
}
