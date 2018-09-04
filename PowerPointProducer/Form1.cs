using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PowerPointProducer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void aBoldCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.SelectionFont = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e) //populate images and assign text to ViewModel
        {


            try
            {
string titleText = textBox1.Text;

            var punctuation = titleText.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = titleText.Split().Select(x => x.Trim(punctuation));

            string searchString = titleText;
            char[] searchable = richTextBox1.Rtf.ToCharArray();
            int startIndex; int stringLength;
            for (int i = 0; i < searchable.Length - 5; i++)
            {
                //find first bold key /b/ start
                if (searchable[i] == 92 && searchable[i + 1] == 'b' && searchable[i + 2] == 92)
                {
                    //inner loop: find first blank and start, end at first  / find end of bold

                    while (searchable[i] != ' ')
                    {
                        i++;
                    }
                    startIndex = i;
                    while (searchable[i] != 92)
                    {
                        i++;
                    }
                    stringLength = i - startIndex;

                    searchString += new string(richTextBox1.Rtf.ToCharArray(startIndex, stringLength));

                }

            }
            richTextBox2.Text = searchString;

            var searchTerm = textBox1.Text + " " + searchString;

            string[] searchTermArray = searchTerm.Split(' ');

            if (searchTermArray[(searchTermArray.Length - 1)] == "")
            {
                searchTermArray[(searchTermArray.Length - 1)] = "image";
            }

            string searchTermString = string.Join("+", searchTermArray);

            RestClient rClient = new RestClient();

            rClient.endPoint = "https://www.googleapis.com/customsearch/v1?key=AIzaSyDrvqQuRIQvQ_yeKfy1knUXZpxAeQlTh8U&cx=007365820605907751637:tuepjecdrqe&searchType=image&q=" + searchTermString;

            //debugOutput("REST Client Created")  https://cse.google.com/cse?cx=007365820605907751637:tuepjecdrqe
            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();
            dynamic json = JsonConvert.DeserializeObject(strResponse);


            pictureBox1.ImageLocation = json.items[1].link;
            pictureBox2.ImageLocation = json.items[2].link;
            pictureBox3.ImageLocation = json.items[3].link;
            pictureBox4.ImageLocation = json.items[4].link;
            pictureBox5.ImageLocation = json.items[5].link;
            pictureBox6.ImageLocation = json.items[6].link;
            pictureBox7.ImageLocation = json.items[7].link;
            pictureBox8.ImageLocation = json.items[8].link;
            }
            catch
            {

            }
            
        }
            
                

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            sumCheckBoxes();
        }

        int sum = 0;
        private void sumCheckBoxes()
        {

            ViewModel.urlList = new List<string>();
            sum = 0;
            if (checkBox1.Checked) { sum++; ViewModel.urlList.Add(pictureBox1.ImageLocation); }
            if (checkBox2.Checked) { sum++; ViewModel.urlList.Add(pictureBox2.ImageLocation); }
            if (checkBox3.Checked) { sum++; ViewModel.urlList.Add(pictureBox3.ImageLocation); }
            if (checkBox4.Checked) { sum++; ViewModel.urlList.Add(pictureBox4.ImageLocation); }
            if (checkBox5.Checked) { sum++; ViewModel.urlList.Add(pictureBox5.ImageLocation); }
            if (checkBox6.Checked) { sum++; ViewModel.urlList.Add(pictureBox6.ImageLocation); }
            if (checkBox7.Checked) { sum++; ViewModel.urlList.Add(pictureBox7.ImageLocation); }
            if (checkBox8.Checked) { sum++; ViewModel.urlList.Add(pictureBox8.ImageLocation); }

            textBox2.Text = Convert.ToString(sum);
            label5.ForeColor = Color.Black;

            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewModel.Title = textBox1.Text;
            ViewModel.Descrip = richTextBox1.Text;
            if (sum == 1)
            {
                Form2 frm2 = new Form2();
                {
                    frm2.ShowDialog();
                }
            }

            else if (sum == 2)
            {
                Form3 frm3 = new Form3();
                {
                    frm3.ShowDialog();
                }
            }
            else if (sum == 3)
            {
                Form4 frm4 = new Form4();
                {
                    frm4.ShowDialog();
                }
            }
            else if (sum == 4)
            {
                Form5 frm5 = new Form5();
                {
                    frm5.ShowDialog();
                }
            }
            else
            {
                label5.ForeColor = Color.Red;
            }

        }

        private void timer1_Tick(object sender, EventArgs e) //populate images and assign text to ViewModel every second
        {
            


       }
    }
    
}
