using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Imaging;

namespace QR_Generator
{
    public partial class Form1 : Form
    {
        string firstName;
        string lastName;
        string company;
        string mail;
        public Form1()
        {
            InitializeComponent();
            string firstName = "";
            string lastName = "";
            string company = "";
            string mail="";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//LAST NAME
        {
            lastName= textBox2.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)//title
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//FIRST NAME
        {
            firstName=textBox1.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//COMPANY
        {
            company = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//EMAIL
        {
            mail=textBox3.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
