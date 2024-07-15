using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Net;
using System.Net.Mail;
using GmailAPIHelper;
using Google.Apis.Gmail.v1;

namespace QR_Generator
{
    public partial class PasswordEnterer : Form
    {
        Main main;
        Generator generator;

        public PasswordEnterer(Main main)
        {
            InitializeComponent();
            this.main = main;
            textBox2.Text = "Google disabled authorization on less secure apps - cannot send a mail through Google.";
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EmailSender emailSender = new EmailSender(main.mail, main.password,generator);
                emailSender.SendEmail("durica2235@gmail.com");
                textBox2.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            main.SetPassword(textBox1.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }
    }
}

