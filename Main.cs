using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Imaging;
using QR_Generator;

namespace QR_Generator
{
    public partial class Main : Form
    {
        Form generator;
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string company { get; private set; }
        public string mail { get; private set; }

        public string FormattedName { get; private set; }

        public string password { get; private set; }


        public Main()
        {
            InitializeComponent();
            string firstName = "";
            string lastName = "";
            string company = "";
            string mail = "";
            string password = "";
        }

        public string GetQRData()
        {
            return $"{firstName} {lastName} {company} {mail}";
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//LAST NAME
        {
            lastName = textBox2.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)//title
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)//FIRST NAME
        {
            firstName = textBox1.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)//COMPANY
        {
            company = textBox4.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)//EMAIL
        {
            mail = textBox3.Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void ShowGenerator(Main main)
        {
            generator = new Generator(this);
            generator.Show();
        }
        private void button2_Click(object sender, EventArgs e)//GENERATE
        {
            if (firstName == null || lastName == null || mail == null || company == null)
            {
                button2.Text = "Please input all required fields!";
            }
            else
            {
                button2.Text = "GENERATE";
                ShowGenerator(this);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
