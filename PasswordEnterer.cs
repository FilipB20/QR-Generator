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

namespace QR_Generator
{
    public partial class PasswordEnterer : Form
    {
        Main main;

        public PasswordEnterer(Main main)
        {
            InitializeComponent();
            this.main = main;
            textBox1.KeyDown += textBox1_KeyDown;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // if (autentikacija na mail) onda ovo ostalo
            if (e.KeyCode == Keys.Enter)
            {
                MailMessage email = new MailMessage(new MailAddress(main.mail), new MailAddress("durica2235@gmail.com"));
                email.Subject = "Testing out email sending";
                email.Body = "Hello all the way from the land of C#";

                /*
                 * Gmail SMTP server address	smtp.gmail.com
Gmail SMTP name	Your full name
Gmail SMTP username	Your full Gmail address (e.g. you@gmail.com)
Gmail SMTP password	The password that you use to log in to Gmail
Gmail SMTP port (TLS)	587
Gmail SMTP port (SSL)	465
                */
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(main.mail,main.password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;

                try
                {
                    /* Send method called below is what will send off our email 
                     * unless an exception is thrown.
                     */
                    smtp.Send(email);
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

    } }

