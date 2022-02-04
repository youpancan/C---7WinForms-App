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

namespace WindowsFormsProject
{
    public partial class Form5 : Form
    {


        public Form5()
        {
            InitializeComponent();
        }

        //Gobal Variables

        string dir = @"..\TextFile";
        string path = @"..\TextFile\Calculator.txt";
        FileStream fs = null;

        Calculator obj;
        string oper;


       

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "1";
           
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly=true;
            obj = new Calculator();
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "2";
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "3";
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "4";
       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "5";
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "6";
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "7";
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "8";
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "9";
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += "0";
          
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Text += ".";
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
          
        }

        private void button13_Click(object sender, EventArgs e)
        {
            obj.Operand1 = Convert.ToDecimal(textBox1.Text);
            textBox1.Text = "";
            textBox1.Text = "+";
            oper = "+";
            obj.Op = "Sum";

        }

        private void minus_Click(object sender, EventArgs e)
        {
            obj.Operand1 = Convert.ToDecimal(textBox1.Text);
            textBox1.Text = "-";
            oper = "-";
            obj.Op = "Sub";
            
        }
        private void equal_Click(object sender, EventArgs e)
        {
            fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);

            obj.Operand2 = Convert.ToDecimal(textBox1.Text);
            textBox1.Text = obj.Equals(obj.Operand1, obj.Operand2);
            string result = obj.Equals(obj.Operand1, obj.Operand2);
            // write the fields into text file
            textOut.WriteLine(obj.Operand1 + oper + obj.Operand2 + "=" + result+"\n");
            textOut.Close();
            fs.Close();
        
        
        
        
        }

        private void multiplication_Click(object sender, EventArgs e)
        {
            obj.Operand1 = Convert.ToDecimal(textBox1.Text);
            textBox1.Text = "*";
            oper = "*";
            obj.Op = "Mul";
        }

        private void division_Click(object sender, EventArgs e)
        {
            obj.Operand1 = Convert.ToDecimal(textBox1.Text);
            textBox1.Text = "/";
            oper = "/";
            obj.Op = "Div";

        }
    }


    public class Calculator
        {
            //private field
            private decimal currentvalue;
            private decimal operand1;
            private decimal operand2;
            private string  op = "";

            //public properiety
            public decimal CurrentValue
            {
                set { currentvalue = value; }
                get { return currentvalue; }

            }

            public decimal Operand1
            {
                set { operand1 = value; }
                get { return operand1; }
            }

            public decimal Operand2
            {
                set { operand2 = value; }
                get { return operand2; }
            }


            public string Op
            {
                set { op = value; }
                get { return op; }
            }
            //default constructor
            public Calculator()
            { }

          
            //public methods

          public string Equals(decimal num1,decimal num2)
            {
            switch (Op)
            {
                case "Sum":
                    return Convert.ToString(num1 + num2);
                case "Sub":
                    return Convert.ToString(num1 - num2);
                case "Mul":
                    return Convert.ToString(num1 * num2);
                case "Div":
                    return Convert.ToString(num1 / num2);
                default:
                   return  "";
            }
            }

       
           

    
        }

   
    }

