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
    public partial class Lotto649 : Form
    {
        //Gobal Variables
        string dir = @"..\TextFile";
        string path = @"..\TextFile\LottoNbrs.txt";
        FileStream fs = null;

        public Lotto649()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to quit this application?","Exit",MessageBoxButtons.YesNo).ToString()=="Yes")
            {
                this.Close();
            }
                    
                    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            StreamWriter textOut = new StreamWriter(fs);
            Random random = new Random();
       
            string nbrs = "";
            string boxnbrs = "";
            string tempStr = "649, ";
            int[] randomNumber = new int[8];
            DateTime d = DateTime.Now;
            tempStr += d.ToShortDateString();
            tempStr += " " + d.ToLongTimeString();
            
            for(int i=0;i<7;i++)
            {
                int TempNo;
                do
                {
                    TempNo = random.Next(1, 49);
                } while (randomNumber.Contains(TempNo));
                randomNumber[i] = TempNo;            
             
                boxnbrs += randomNumber[i].ToString() + "\r\n";
            }
            for(int i=0;i<6;i++)
            {
                nbrs += randomNumber[i].ToString()+",";
            }
            int Bonus = randomNumber[6];
            textBox1.Text =boxnbrs;
            //write the fields to into text file
            textOut.WriteLine(tempStr + " " + nbrs + " Bonus "+Bonus.ToString()+'|');
            //close the output stream for the text file
            textOut.Close();
            fs.Close();
        }
        
    
           
        private void button3_Click(object sender, EventArgs e)
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
            MessageBox.Show(textToPrint);
            textIn.Close();
            fs.Close();
        }
    }
}
