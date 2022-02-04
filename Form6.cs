using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsProject
{
    public partial class Form6 : Form
    {
        Regex pattern = new Regex(@"^([0-9]{1,3}\.){3}[0-9]{1,3}$");
        public Form6()
        {
            InitializeComponent();
        }

        

        private void Form6_Load(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            label1.Text = "Today :" + d.ToLongDateString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(pattern.IsMatch(textBox1.Text.Trim())==true)
            {
                MessageBox.Show(textBox1.Text.Trim() + "\n" + "The IP is correct", "Valid IP", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show(textBox1.Text.Trim() + "\n" + "The IP must have 4 bytes\ninterger number between 0 to 255\nseparated by a dot(255.255.255.255)", "Error", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
