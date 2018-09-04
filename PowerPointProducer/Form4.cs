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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = ViewModel.Title;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            pictureBox1.ImageLocation = ViewModel.urlList[0];
            pictureBox2.ImageLocation = ViewModel.urlList[1];
            pictureBox3.ImageLocation = ViewModel.urlList[2];
            label2.Text = ViewModel.Descrip;
            label2.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}
