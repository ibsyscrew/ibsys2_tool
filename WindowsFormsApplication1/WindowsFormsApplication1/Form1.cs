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

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    
                }
                else
                {
                    int text = Convert.ToInt32(textBox1.Text);
                    textBox6.Text = text.ToString();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show("Bitte eine Zahl eingeben!!!!!!");
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
