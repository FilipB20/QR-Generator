using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Imaging;
using QR_Generator;

namespace QR_Generator
{
    public partial class Main : Form
    {
        Form generator;
        string firstName { get; set; }
        string lastName { get; set; }
        string company { get; set; }
        string mail { get; set; }
        public Main()
        {
            InitializeComponent();
            string firstName = "";
            string lastName = "";
            string company = "";
            string mail="";
        }

        public string GetQRData()
        {
            return $"{firstName} {lastName} {company} {mail}";
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

        private void button2_Click(object sender, EventArgs e)//GENERATE
        {
            generator = new Generator(this);
            generator.Show();
        }
    }
}
