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

        public List<int> listezumaufteilen26 = new List<int>(){0,0,0};
        public List<int> listezumaufteilen16 = new List<int>() { 0, 0, 0 };
        public List<int> listezumaufteilen17 = new List<int>() { 0, 0, 0 };

        public int e26 = 0;
        public int e16 = 0;
        public int e17 = 0;

        public Form1(string s)
        {
            

            for(int i=0;i<Database.lager.Count;i++)
            {
                if(Database.lager[i].id =="26")
                {
                    e26 = Convert.ToInt32(Database.lager[i].amount);
                }
                if(Database.lager[i].id =="16")
                {
                    e16 = Convert.ToInt32(Database.lager[i].amount);
                }
                if(Database.lager[i].id =="17")
                {
                    e17 = Convert.ToInt32(Database.lager[i].amount);
                }
            }
            int k = 0;
            int auf = Convert.ToInt32(e26)/10;
            for (int i = 0; i < auf; i++)
            {
                listezumaufteilen26[k] = (Convert.ToInt32(listezumaufteilen26[k]) + 10);

                if (k == 2)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }
            }

             k = 0;
             auf = Convert.ToInt32(e16)/10;
            for (int i = 0; i < auf; i++)
            {
                listezumaufteilen16[k] = Convert.ToInt32(listezumaufteilen16[k]) + 10;

                if (k == 2)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }
            }

             k = 0;
             auf = Convert.ToInt32(e17)/10;
            for (int i = 0; i < auf; i++)
            {
                listezumaufteilen17[k] = (Convert.ToInt32(listezumaufteilen17[k]) + 10);

                if (k == 2)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }
            }


            InitializeComponent();
        //    Image myimage = new Bitmap(@"C:\Users\Marvin Arbeit\Desktop\FH Karlsruhe\7. Semester\IBSYS2\Herren.jpg");
       //     this.BackgroundImage = myimage;

            Warehousestock f49 = new Warehousestock();
            Warehousestock f5 = new Warehousestock();
            Warehousestock f6 = new Warehousestock();
            Warehousestock f4 = new Warehousestock();

            Warehousestock f7 = new Warehousestock();
            Warehousestock f8 = new Warehousestock();
            Warehousestock f9 = new Warehousestock();

            Warehousestock f10 = new Warehousestock();
            Warehousestock f11 = new Warehousestock();
            Warehousestock f12 = new Warehousestock();

            Warehousestock f13 = new Warehousestock();
            Warehousestock f14 = new Warehousestock();
            Warehousestock f15 = new Warehousestock();

            Warehousestock f16 = new Warehousestock();
            Warehousestock f17 = new Warehousestock();
            Warehousestock f18 = new Warehousestock();

            Warehousestock f19 = new Warehousestock();
            Warehousestock f20 = new Warehousestock();
            Warehousestock f26 = new Warehousestock();


            Warehousestock f54 = new Warehousestock();
            Warehousestock f29 = new Warehousestock();

            Warehousestock f50 = new Warehousestock();
            Warehousestock f55 = new Warehousestock();
            Warehousestock f30 = new Warehousestock();

            Warehousestock f51 = new Warehousestock();
            Warehousestock f56 = new Warehousestock();
            Warehousestock f31 = new Warehousestock();

            Warehousestock f1 = new Warehousestock();
            Warehousestock f2 = new Warehousestock();
            Warehousestock f3 = new Warehousestock();

            var erg = Database.lager;

            for(int i = 0; i<erg.Count;i++)
            {
                if(erg[i].id=="49")
                {
                    f49 = new Warehousestock();
                    if(f49.amount!="")
                    f49.amount = (Convert.ToInt32(erg[i].amount)+f49.amount);
                    else
                        f49 = erg[i];
                }

                if(erg[i].id=="4")
                {
                    f4 = new Warehousestock();
                    if(f4.amount!="")
                    f16.amount = (Convert.ToInt32(erg[i].amount)+f4.amount);
                    else
                        f4 = erg[i];
                }
                if(erg[i].id=="5")
                {
                    f5 = new Warehousestock();
                    if(f5.amount!="")
                    f5.amount = (Convert.ToInt32(erg[i].amount)+f5.amount);
                    else
                        f5 = erg[i];
                }
                if(erg[i].id=="6")
                {
                    f6 = new Warehousestock();
                    if(f6.amount!="")
                    f6.amount = (Convert.ToInt32(erg[i].amount)+f6.amount);
                    else
                        f6 = erg[i];
                }
                if(erg[i].id=="7")
                {
                   f7 = new Warehousestock();
                    if(f7.amount!="")
                    f7.amount = (Convert.ToInt32(erg[i].amount)+f7.amount);
                    else
                        f7 = erg[i];
                }
                if(erg[i].id=="8")
                {
                    f8 = new Warehousestock();
                    if(f8.amount!="")
                    f8.amount = (Convert.ToInt32(erg[i].amount)+f8.amount);
                    else
                        f8 = erg[i];
                }
                if(erg[i].id=="9")
                {
                    f9 = new Warehousestock();
                    if(f9.amount!="")
                    f9.amount = (Convert.ToInt32(erg[i].amount)+f9.amount);
                    else
                        f9 = erg[i];
                }
                if(erg[i].id=="10")
                {
                    f10 = new Warehousestock();
                    if(f10.amount!="")
                    f10.amount = (Convert.ToInt32(erg[i].amount)+f10.amount);
                    else
                        f10 = erg[i];
                }
                if(erg[i].id=="11")
                {
                    f11 = new Warehousestock();
                    if(f11.amount!="")
                    f11.amount = (Convert.ToInt32(erg[i].amount)+f11.amount);
                    else
                        f11 = erg[i];
                }
                if(erg[i].id=="12")
                {
                    f12 = new Warehousestock();
                    if(f12.amount!="")
                    f12.amount = (Convert.ToInt32(erg[i].amount)+f12.amount);
                    else
                        f12 = erg[i];
                }
                if(erg[i].id=="13")
                {
                    f13 = new Warehousestock();
                    if(f13.amount!="")
                    f13.amount = (Convert.ToInt32(erg[i].amount)+f13.amount);
                    else
                        f13 = erg[i];
                }
                if(erg[i].id=="14")
                {
                    f14 = new Warehousestock();
                    if(f14.amount!="")
                    f14.amount = (Convert.ToInt32(erg[i].amount)+f14.amount);
                    else
                        f14 = erg[i];
                }
                if(erg[i].id=="15")
                {
                    f15 = new Warehousestock();
                    if(f15.amount!="")
                    f15.amount = (Convert.ToInt32(erg[i].amount)+f15.amount);
                    else
                        f15 = erg[i];
                }
                if(erg[i].id=="16")
                {
                    f16 = new Warehousestock();
                    if(f16.amount!="")
                    f16.amount = (Convert.ToInt32(erg[i].amount)+f16.amount);
                    else
                        f16 = erg[i];
                }
                if(erg[i].id=="17")
                {
                    f17 = new Warehousestock();
                    if(f17.amount!="")
                    f17.amount = (Convert.ToInt32(erg[i].amount)+f17.amount);
                    else
                        f17 = erg[i];
                }
                if(erg[i].id=="18")
                {
                    f18 = new Warehousestock();
                    if(f18.amount!="")
                    f18.amount = (Convert.ToInt32(erg[i].amount)+f18.amount);
                    else
                        f18 = erg[i];
                }
                if(erg[i].id=="19")
                {
                    f19 = new Warehousestock();
                    if(f19.amount!="")
                    f19.amount = (Convert.ToInt32(erg[i].amount)+f19.amount);
                    else
                        f19 = erg[i];
                }
                if(erg[i].id=="20")
                {
                    f20 = new Warehousestock();
                    if(f20.amount!="")
                    f20.amount = (Convert.ToInt32(erg[i].amount)+f20.amount);
                    else
                        f20 = erg[i];
                }
                if(erg[i].id=="26")
                {
                    f26 = new Warehousestock();
                    if(f26.amount!="")
                    f26.amount = (Convert.ToInt32(erg[i].amount)+f26.amount);
                    else
                        f26 = erg[i];
                }
                if(erg[i].id=="54")
                {
                    f54 = new Warehousestock();
                    if(f54.amount!="")
                    f54.amount = (Convert.ToInt32(erg[i].amount)+f54.amount);
                    else
                        f54 = erg[i];
                }
                if(erg[i].id=="29")
                {
                    f29 = new Warehousestock();
                    if(f29.amount!="")
                    f29.amount = (Convert.ToInt32(erg[i].amount)+f29.amount);
                    else
                        f29 = erg[i];
                }
                if(erg[i].id=="50")
                {
                    f50 = new Warehousestock();
                    if(f50.amount!="")
                    f50.amount = (Convert.ToInt32(erg[i].amount)+f50.amount);
                    else
                        f50 = erg[i];
                }

                if(erg[i].id=="55")
                {
                    f55 = new Warehousestock();
                    if(f55.amount!="")
                    f55.amount = (Convert.ToInt32(erg[i].amount)+f55.amount);
                    else
                        f55 = erg[i];
                }

                if(erg[i].id=="30")
                {
                    f30 = new Warehousestock();
                    if(f30.amount!="")
                    f30.amount = (Convert.ToInt32(erg[i].amount)+f30.amount);
                    else
                        f30 = erg[i];
                }

                if(erg[i].id=="51")
                {
                    f51 = new Warehousestock();
                    if(f51.amount!="")
                    f51.amount = (Convert.ToInt32(erg[i].amount)+f51.amount);
                    else
                        f51 = erg[i];
                }

                if(erg[i].id=="56")
                {
                    f56 = new Warehousestock();
                    if(f56.amount!="")
                    f56.amount = (Convert.ToInt32(erg[i].amount)+f56.amount);
                    else
                        f56 = erg[i];
                }

                if(erg[i].id=="31")
                {
                    f31 = new Warehousestock();
                    if(f31.amount!="")
                    f31.amount = (Convert.ToInt32(erg[i].amount)+f31.amount);
                    else
                        f31 = erg[i];
                }

                if(erg[i].id=="1")
                {
                    f1 = new Warehousestock();
                    if(f1.amount!="")
                    f1.amount = (Convert.ToInt32(erg[i].amount)+f1.amount);
                    else
                        f1 = erg[i];
                }
                if(erg[i].id=="2")
                {
                    f2 = new Warehousestock();
                    if(f2.amount!="")
                    f2.amount = (Convert.ToInt32(erg[i].amount)+f2.amount);
                    else
                        f2 = erg[i];
                }
                if(erg[i].id=="3")
                {
                    f3 = new Warehousestock();
                    if(f3.amount!="")
                    f3.amount = (Convert.ToInt32(erg[i].amount)+f3.amount);
                    else
                        f3 = erg[i];
                }
            }
            if (welches == 1)
            {
                if (XMLCreater.sellwish[0] != "0")
                {
                    textBox1.Text = XMLCreater.sellwish[0];
                }
                textBox3.Text = f1.amount;
                textBox9.Text = f26.amount;
                textBox17.Text = f51.amount;
                textBox24.Text = f16.amount;
                textBox31.Text = f17.amount;
                textBox38.Text = f50.amount;
                textBox45.Text = f4.amount;
                textBox52.Text = f10.amount;
                textBox59.Text = f49.amount;
                textBox66.Text = f7.amount;
                textBox73.Text = f13.amount;
                textBox80.Text = f18.amount;


            }

            if (welches == 2)
            {
                if (XMLCreater.sellwish[1] != "0")
                {
                    textBox1.Text = XMLCreater.sellwish[1];
                }
                textBox3.Text = f2.amount;
                textBox9.Text = f26.amount;
                textBox17.Text = f56.amount;
                textBox24.Text = f16.amount;
                textBox31.Text = f17.amount;
                textBox38.Text = f55.amount;
                textBox45.Text = f5.amount;
                textBox52.Text = f11.amount;
                textBox59.Text = f54.amount;
                textBox66.Text = f8.amount;
                textBox73.Text = f14.amount;
                textBox80.Text = f19.amount;


            }

            if (welches == 3)
            {
                if (XMLCreater.sellwish[2] != "0")
                {
                    textBox1.Text = XMLCreater.sellwish[2];
                }
                textBox3.Text = f1.amount;
                textBox9.Text = f26.amount;
                textBox17.Text = f31.amount;
                textBox24.Text = f16.amount;
                textBox31.Text = f17.amount;
                textBox38.Text = f30.amount;
                textBox45.Text = f6.amount;
                textBox52.Text = f12.amount;
                textBox59.Text = f29.amount;
                textBox66.Text = f9.amount;
                textBox73.Text = f15.amount;
                textBox80.Text = f20.amount;

                if (s == "e")
                {
                    englisch();
                }
                else
                {
                    deutsch();
                }

            }
        }

        public static int welches = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (welches == 1)
            {
                auftraege1create();
                Form2.setau1(au1);
            }

            if (welches == 2)
            {
                auftraege2create();
                Form2.setau2(au2);
            }

            if (welches == 3)
            {
                auftraege3create();
                Form2.setau3(au3);
            }

            this.Close();
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
                    textBox27.Text = (Convert.ToInt32(textBox21.Text) + Convert.ToInt32(textBox22.Text) + Convert.ToInt32(textBox23.Text) - Convert.ToInt32(textBox24.Text) - Convert.ToInt32(textBox25.Text) - Convert.ToInt32(textBox26.Text)).ToString();
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
                    textBox34.Text = (Convert.ToInt32(textBox28.Text) + Convert.ToInt32(textBox29.Text) + Convert.ToInt32(textBox30.Text) - Convert.ToInt32(textBox31.Text) - Convert.ToInt32(textBox32.Text) - Convert.ToInt32(textBox33.Text)).ToString();
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

        public void p1()
        {
            label7.Text = "P1";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "1")
                {
                    textBox5.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox5.Text)).ToString();
                }
            }

            textBox9.Text = listezumaufteilen26[0].ToString();
            textBox24.Text = listezumaufteilen16[0].ToString();
            textBox31.Text = listezumaufteilen17[0].ToString();

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                if (Database.workstationswaitinglist[i].listWaitinglist != null)
                {
                    for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                    {
                        if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "1")
                        {
                            textBox4.Text = (Convert.ToInt32(textBox4.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                        }
                    }
                }
            }
            label8.Text = "E26";
            /*for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "26")
                {
                    textBox12.Text = Database.ordersinwork[i].amount;
                }
            }
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "1")
                    {
                        textBox11.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }*/
            label9.Text = "E51";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "51")
                {
                    textBox19.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox19.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "51")
                    {
                        textBox18.Text = (Convert.ToInt32(textBox18.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }
            label10.Text = "E16";
           /* for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "16")
                {
                    textBox26.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "16")
                    {
                        textBox25.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }*/

            label11.Text = "E17";
            /*for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "17")
                {
                    textBox33.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "17")
                    {
                        textBox32.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }
            */
            label12.Text = "E50";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "50")
                {
                    textBox40.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox40.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "50")
                    {
                        textBox39.Text = (Convert.ToInt32(textBox39.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label13.Text = "E4";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "4")
                {
                    textBox47.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox47.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "4")
                    {
                        textBox46.Text = (Convert.ToInt32(textBox46.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label14.Text = "E10";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "10")
                {
                    textBox54.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox54.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "10")
                    {
                        textBox53.Text = (Convert.ToInt32(textBox53.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label15.Text = "E49";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "49")
                {
                    textBox61.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox61.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "49")
                    {
                        textBox60.Text =(Convert.ToInt32(textBox60.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label16.Text = "E7";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "7")
                {
                    textBox68.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox68.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "7")
                    {
                        textBox67.Text =(Convert.ToInt32(textBox67.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label17.Text = "E13";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "13")
                {
                    textBox75.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox75.Text)).ToString() ;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "13")
                    {
                        textBox74.Text = (Convert.ToInt32(textBox74.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label18.Text = "E18";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "18")
                {
                    textBox82.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox82.Text)).ToString();
                }
            }
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "18")
                    {
                        textBox81.Text = (Convert.ToInt32(textBox81.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

        }

        public void p2()
        {
            textBox9.Text = listezumaufteilen26[1].ToString();
            textBox24.Text = listezumaufteilen16[1].ToString();
            textBox31.Text = listezumaufteilen17[1].ToString();
            label7.Text = "P2";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "2")
                {
                    textBox5.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox5.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "2")
                    {
                        textBox4.Text = (Convert.ToInt32(textBox4.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label8.Text = "E26";
            /*for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "26")
                {
                    textBox12.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "26")
                    {
                        textBox11.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }
            */
            label9.Text = "E56";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "56")
                {
                    textBox19.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox19.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "56")
                    {
                        textBox18.Text = (Convert.ToInt32(textBox18.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label10.Text = "E16";
            /*for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "16")
                {
                    textBox26.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "16")
                    {
                        textBox25.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }
            */
            label11.Text = "E17";
            /*for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "17")
                {
                    textBox33.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "17" )
                    {
                        textBox32.Text = Database.workstationswaitinglist[i].listWaitinglist[j].amount;
                    }
                }
            }
            */
            label12.Text = "E55";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "55")
                {
                    textBox40.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox40.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "55")
                    {
                        textBox39.Text = (Convert.ToInt32(textBox39.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label13.Text = "E5";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "5")
                {
                    textBox47.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox47.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "5")
                    {
                        textBox46.Text = (Convert.ToInt32(textBox46.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }
            label14.Text = "E11";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "11")
                {
                    textBox54.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox54.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "11")
                    {
                        textBox53.Text = (Convert.ToInt32(textBox53.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label15.Text = "E54";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "54")
                {
                    textBox61.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox61.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "54")
                    {
                        textBox60.Text = (Convert.ToInt32(textBox60.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label16.Text = "E8";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "8")
                {
                    textBox68.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox68.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "8")
                    {
                        textBox67.Text = (Convert.ToInt32(textBox67.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label17.Text = "E14";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "14")
                {
                    textBox75.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox75.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "14")
                    {
                        textBox74.Text = (Convert.ToInt32(textBox74.Text)+Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label18.Text = "E19";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "19")
                {
                    textBox82.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox82.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "19")
                    {
                        textBox81.Text = (Convert.ToInt32(textBox81.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }
        }

        public void p3()
        {
            label7.Text = "P3";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "3")
                {
                    textBox5.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox5.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "3")
                    {
                        textBox4.Text = (Convert.ToInt32(textBox4.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            textBox9.Text = listezumaufteilen26[2].ToString();
            textBox24.Text = listezumaufteilen16[2].ToString();
            textBox31.Text = listezumaufteilen17[2].ToString();

            label8.Text = "E26";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "26")
                {
                    textBox12.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox12.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "26")
                    {
                        textBox11.Text = (Convert.ToInt32(textBox11.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label9.Text = "E31";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "31")
                {
                    textBox19.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox19.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "31")
                    {
                        textBox18.Text = (Convert.ToInt32(textBox18.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label10.Text = "E16";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "16")
                {
                    textBox26.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox26.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "16")
                    {
                        textBox25.Text = (Convert.ToInt32(textBox25.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label11.Text = "E17";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "17")
                {
                    textBox33.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox33.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "17")
                    {
                        textBox32.Text = (Convert.ToInt32(textBox32.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label12.Text = "E30";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "30")
                {
                    textBox40.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox40.Text)).ToString();
                }
            }


            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "30")
                    {
                        textBox39.Text = (Convert.ToInt32(textBox39.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label13.Text = "E6";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "6")
                {
                    textBox47.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox47.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "6")
                    {
                        textBox46.Text = (Convert.ToInt32(textBox46.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label14.Text = "E12";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "12")
                {
                    textBox54.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox54.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "12")
                    {
                        textBox53.Text = (Convert.ToInt32(textBox53.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label15.Text = "E29";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "29")
                {
                    textBox61.Text = Database.ordersinwork[i].amount;
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "29")
                    {
                        textBox60.Text = (Convert.ToInt32(textBox60.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label16.Text = "E9";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "9")
                {
                    textBox68.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox68.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "9")
                    {
                        textBox67.Text = (Convert.ToInt32(textBox60.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label17.Text = "E15";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "15")
                {
                    textBox75.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox75.Text)).ToString();
                }
            }

            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "15")
                    {
                        textBox74.Text = (Convert.ToInt32(textBox74.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

            label18.Text = "E20";
            for (int i = 0; i < Database.ordersinwork.Count; i++)
            {
                if (Database.ordersinwork[i].item == "20")
                {
                    textBox82.Text = (Convert.ToInt32(Database.ordersinwork[i].amount) + Convert.ToInt32(textBox82.Text)).ToString();
                }
            }
            for (int i = 0; i < Database.workstationswaitinglist.Count; i++)
            {
                for (int j = 0; j < Database.workstationswaitinglist[i].listWaitinglist.Count; j++)
                {
                    if (Database.workstationswaitinglist[i].listWaitinglist[j].item == "20")
                    {
                        textBox81.Text = (Convert.ToInt32(textBox81.Text) + Convert.ToInt32(Database.workstationswaitinglist[i].listWaitinglist[j].amount)).ToString();
                    }
                }
            }

        }
        public static List<Fertigungsauftrag> au1 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au2 = new List<Fertigungsauftrag>();
        public static List<Fertigungsauftrag> au3 = new List<Fertigungsauftrag>();
        
        public void auftraege1create()
        {
            List<Fertigungsauftrag> erg = new List<Fertigungsauftrag>();

            Fertigungsauftrag a1 = new Fertigungsauftrag();
            a1.artikel = "1";
            a1.menge = textBox6.Text;
            erg.Add(a1);

            Fertigungsauftrag a2 = new Fertigungsauftrag();
            a2.artikel = "26";
            a2.menge = textBox13.Text;
            erg.Add(a2);

            Fertigungsauftrag a3 = new Fertigungsauftrag();
            a3.artikel = "51";
            a3.menge = textBox20.Text;
            erg.Add(a3);

            Fertigungsauftrag a4 = new Fertigungsauftrag();
            a4.artikel = "16";
            a4.menge = textBox27.Text;
            erg.Add(a4);

            Fertigungsauftrag a5 = new Fertigungsauftrag();
            a5.artikel = "17";
            a5.menge = textBox34.Text;
            erg.Add(a5);

            Fertigungsauftrag a6 = new Fertigungsauftrag();
            a6.artikel = "50";
            a6.menge = textBox41.Text;
            erg.Add(a6);

            Fertigungsauftrag a7 = new Fertigungsauftrag();
            a7.artikel = "4";
            a7.menge = textBox48.Text;
            erg.Add(a7);

            Fertigungsauftrag a8 = new Fertigungsauftrag();
            a8.artikel = "10";
            a8.menge = textBox55.Text;
            erg.Add(a8);

            Fertigungsauftrag a9 = new Fertigungsauftrag();
            a9.artikel = "49";
            a9.menge = textBox62.Text;
            erg.Add(a9);

            Fertigungsauftrag a10 = new Fertigungsauftrag();
            a10.artikel = "7";
            a10.menge = textBox69.Text;
            erg.Add(a10);

            Fertigungsauftrag a11 = new Fertigungsauftrag();
            a11.artikel = "13";
            a11.menge = textBox76.Text;
            erg.Add(a11);

            Fertigungsauftrag a12 = new Fertigungsauftrag();
            a12.artikel = "18";
            a12.menge = textBox83.Text;
            erg.Add(a12);

            au1 = erg;
        }

        public void englisch()
        {
            label1.Text = "sales wish";
            label2.Text = "safety warehousstock";


        }
        public void deutsch()
        {
            label1.Text = "Test";


        }
        public void auftraege2create()
        {
            List<Fertigungsauftrag> erg = new List<Fertigungsauftrag>();

            Fertigungsauftrag a1 = new Fertigungsauftrag();
            a1.artikel = "2";
            a1.menge = textBox6.Text;
            erg.Add(a1);

            Fertigungsauftrag a2 = new Fertigungsauftrag();
            a2.artikel = "26";
            a2.menge = textBox13.Text;
            erg.Add(a2);

            Fertigungsauftrag a3 = new Fertigungsauftrag();
            a3.artikel = "56";
            a3.menge = textBox20.Text;
            erg.Add(a3);

            Fertigungsauftrag a4 = new Fertigungsauftrag();
            a4.artikel = "16";
            a4.menge = textBox27.Text;
            erg.Add(a4);

            Fertigungsauftrag a5 = new Fertigungsauftrag();
            a5.artikel = "17";
            a5.menge = textBox34.Text;
            erg.Add(a5);

            Fertigungsauftrag a6 = new Fertigungsauftrag();
            a6.artikel = "55";
            a6.menge = textBox41.Text;
            erg.Add(a6);

            Fertigungsauftrag a7 = new Fertigungsauftrag();
            a7.artikel = "5";
            a7.menge = textBox48.Text;
            erg.Add(a7);

            Fertigungsauftrag a8 = new Fertigungsauftrag();
            a8.artikel = "11";
            a8.menge = textBox55.Text;
            erg.Add(a8);

            Fertigungsauftrag a9 = new Fertigungsauftrag();
            a9.artikel = "54";
            a9.menge = textBox62.Text;
            erg.Add(a9);

            Fertigungsauftrag a10 = new Fertigungsauftrag();
            a10.artikel = "8";
            a10.menge = textBox69.Text;
            erg.Add(a10);

            Fertigungsauftrag a11 = new Fertigungsauftrag();
            a11.artikel = "14";
            a11.menge = textBox76.Text;
            erg.Add(a11);

            Fertigungsauftrag a12 = new Fertigungsauftrag();
            a12.artikel = "19";
            a12.menge = textBox83.Text;
            erg.Add(a12);

            au2 = erg;
        }

        public void auftraege3create()
        {
            List<Fertigungsauftrag> erg = new List<Fertigungsauftrag>();

            Fertigungsauftrag a1 = new Fertigungsauftrag();
            a1.artikel = "3";
            a1.menge = textBox6.Text;
            erg.Add(a1);

            Fertigungsauftrag a2 = new Fertigungsauftrag();
            a2.artikel = "26";
            a2.menge = textBox13.Text;
            erg.Add(a2);

            Fertigungsauftrag a3 = new Fertigungsauftrag();
            a3.artikel = "31";
            a3.menge = textBox20.Text;
            erg.Add(a3);

            Fertigungsauftrag a4 = new Fertigungsauftrag();
            a4.artikel = "16";
            a4.menge = textBox27.Text;
            erg.Add(a4);

            Fertigungsauftrag a5 = new Fertigungsauftrag();
            a5.artikel = "17";
            a5.menge = textBox34.Text;
            erg.Add(a5);

            Fertigungsauftrag a6 = new Fertigungsauftrag();
            a6.artikel = "30";
            a6.menge = textBox41.Text;
            erg.Add(a6);

            Fertigungsauftrag a7 = new Fertigungsauftrag();
            a7.artikel = "6";
            a7.menge = textBox48.Text;
            erg.Add(a7);

            Fertigungsauftrag a8 = new Fertigungsauftrag();
            a8.artikel = "12";
            a8.menge = textBox55.Text;
            erg.Add(a8);

            Fertigungsauftrag a9 = new Fertigungsauftrag();
            a9.artikel = "29";
            a9.menge = textBox62.Text;
            erg.Add(a9);

            Fertigungsauftrag a10 = new Fertigungsauftrag();
            a10.artikel = "9";
            a10.menge = textBox69.Text;
            erg.Add(a10);

            Fertigungsauftrag a11 = new Fertigungsauftrag();
            a11.artikel = "15";
            a11.menge = textBox76.Text;
            erg.Add(a11);

            Fertigungsauftrag a12 = new Fertigungsauftrag();
            a12.artikel = "20";
            a12.menge = textBox83.Text;
            erg.Add(a12);

            au3 = erg;
        }        
    }
}
