using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//YOU PAN,
//28th July,2021
//Objected Oriented Program Project
namespace WindowsFormsProject
{
    public partial class Form0 : Form
    {
        public Form0()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                LottoMax frm2 = new LottoMax();
                frm2.ShowDialog();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButtons.YesNo).ToString()=="Yes")
            {
                this.Close();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.ShowDialog();
        }

      
    }
}
