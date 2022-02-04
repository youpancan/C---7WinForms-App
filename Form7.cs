using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace WindowsFormsProject
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        string dir = @"..\TextFile\";
        string path = @"..\TextFile\TempConversions.txt";
        Regex pattern =new Regex(@"^[-]?\d+[.]?\d+$");

        FileStream fs = null;


        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = false;
            label3.Visible = false;
            label5.Visible = true;
            label6.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                DateTime d = DateTime.Now;
                string tempStr = d.ToShortDateString();
                tempStr += " " + d.ToLongTimeString();
                double val;
                try
                {
                    if (pattern.IsMatch(textBox1.Text.Trim()) == true)
                    {
                        val = Convert.ToDouble(textBox1.Text);
                        textBox2.Text = (val * 9 / 5 + 32).ToString();
                        textOut.WriteLine(textBox1.Text.Trim() + " C = " + textBox2.Text + " F, " + tempStr + "|");
                        textOut.Close();
                        fs.Close();
                        textBox3.Text = ((val == 100) ? "Water boils" : (val == 40) ? "Hot Bath" : (val == 37) ? "Body temperature" : (val == 30) ? "Beach wather" :
                                        (val == 21) ? "Room temperature" : (val == 10) ? "Cool Day" : (val == 0) ? "Freezing point of water" : (val == -18) ? "Very Cold Day" :
                                        (val == -40) ? "Extremely Cold Day\r\n(and the same number!)" : " ");
                    }
                    else
                    {
                        MessageBox.Show("Please enter digit number");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

             if (radioButton2.Checked == true)
            {
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                StreamWriter textOut = new StreamWriter(fs);
                DateTime d = DateTime.Now;
                string tempStr = d.ToShortDateString();
                tempStr += " " + d.ToLongTimeString();
                double val;
                try
                {


                    if (pattern.IsMatch(textBox1.Text.Trim()) == true)
                    {
                        val = Convert.ToDouble(textBox1.Text);
                        textBox2.Text = ((val - 32) * 5 / 9).ToString();
                        textOut.WriteLine(textBox1.Text.Trim() + " C = " + textBox2.Text + " F, " + tempStr + "|");
                        textOut.Close();
                        fs.Close();
                        textBox3.Text = ((val == 212) ? "Water boils" : (val == 104) ? "Hot Bath" : (val == 98.6) ? "Body temperature" : (val == 86) ? "Beach wather" :
                       (val == 70) ? "Room temperature" : (val == 50) ? "Cool Day" : (val == 32) ? "Freezing point of water" : (val == 0) ? "Very Cold Day" :
                       (val == -40) ? "Extremely Cold Day\r\n(and the same number!)" : " ");
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader textIn = new StreamReader(fs);
            string textToPrint = "";

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                for(int i=0;i<columns.Length;i++)
                {
                    textToPrint += columns[i] + "\n";
                }
            }
            MessageBox.Show(textToPrint);
            textIn.Close();
            fs.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label2.Visible = true;
            label3.Visible = true;
            label5.Visible = false;
            label6.Visible = false;
        }
    }
}
