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

/// <summary>
/// Searching from internet:www.xe.com  24,July 2021 
/// </summary>
namespace WindowsFormsProject
{
    public partial class MoneyEx : Form
    {
        public MoneyEx()
        {
            InitializeComponent();
        }
        //Gobal Variables
        MoneyExchange obj = new MoneyExchange();
        double exchangrate;
        string currency1;
        string currency2;
        //dir and path
        string dir = @"..\TextFile";
        string path = @"..\TextFile\MoneyConversions.txt";
        FileStream fs = null;
        
        //find out is match int and decimal .
        Regex pattern =new Regex (@"^(\d(\.\d{2})?){1}$");
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            obj.Rate= 1;
            currency1 = "USD";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want\nto quite the application\nMoney Exchange?", "Exit?", MessageBoxButtons.YesNo).ToString() == "Yes");

            {
                this.Close();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            obj.Rate = 1.26;
            currency1 = "CAD";
        }

     

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            exchangrate = 1;
            currency2 = "USD";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            obj.Val = Convert.ToDouble(textBox1.Text) / obj.Rate;
            textBox2.Text = obj.ConverttoOthers(obj.Val,exchangrate).ToString("f3");

            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);

            StreamWriter textOut = new StreamWriter(fs);
            DateTime d = DateTime.Now;
            string tempStr=" ";

            try
            {
                if(pattern.IsMatch(textBox1.Text.Trim())==true);
                {
                    tempStr += textBox1.Text + "" + currency1 + " = ";
                    tempStr += textBox2.Text + " " + currency2 + "," + "";
                    tempStr += d.ToShortDateString();
                    tempStr += " " + d.ToLongTimeString() + '|' + "\r\n";
                    textOut.WriteLine(tempStr);
                    textOut.Close();
                    fs.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           obj.Rate = 0.85;
            currency1 = "EUR";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            obj.Rate = 110.5;
            currency1 = "GBP";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            exchangrate = 1.26;
            currency2 = "CAD";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            obj.Rate =  6.48;
            currency1 = "CNY";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            exchangrate = 0.85;
            currency2 = "EUR";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            exchangrate = 110.5;
            currency2 = "GBP";

        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            exchangrate = 6.48;
            currency2 = "CNY";
        }

      

        private void Form4_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            textBox2.ReadOnly = true;
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
                for (int i = 0; i < columns.Length; i++)
                {
                    textToPrint += columns[i] + "\n";
                }
            }
            MessageBox.Show(textToPrint,"MoneyEx-You",MessageBoxButtons.OK);
            textIn.Close();
            fs.Close();
        }
    }
    //create another class
    public class MoneyExchange
    {
        //private field
        private double val;
        private double rate;

        //public propriery
        public double Val
        {
            set { val = value; }
            get { return val; }
        }

        public double Rate
        {
            set{ rate = value; }
            get { return rate; }
        }

        //default constructor
        public MoneyExchange()
        {
        }

        public MoneyExchange(double val,double rate)
        {
            this.Val = val;
            this.Rate = rate;
        }
        public double ConverttoOthers(double val1, double rate)
        {
            return val1 * rate;
        }

      

    }

}
