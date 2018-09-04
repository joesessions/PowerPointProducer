using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerPointProducer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = ViewModel.Title;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            pictureBox1.ImageLocation = ViewModel.urlList[0];
            label2.Text = ViewModel.Descrip;
            label2.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
