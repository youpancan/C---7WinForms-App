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
            Lotto649 frm3 = new Lotto649();
            frm3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoneyEx frm4 = new MoneyEx();
            frm4.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SimpleCalc frm5 = new SimpleCalc();
            frm5.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            IP4 frm6 = new IP4();
            frm6.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TempApp frm7 = new TempApp();
            frm7.ShowDialog();
        }

      
    }
}
