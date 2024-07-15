using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static QRCoder.PayloadGenerator;

namespace QR_Generator
{
    internal class EmailSender
    {
        private string senderEmail;
        private string senderPassword;
        Generator generator;

        public EmailSender(string email, string password,Generator generator)
        {
            this.senderEmail = email;
            this.senderPassword = password;
            this.generator = generator;
        }

        public void SendEmail(string recipientEmail)
        {
            MailMessage email = new MailMessage();
            email.From = new MailAddress(senderEmail);
            email.To.Add(new MailAddress(recipientEmail));
            email.Subject = "Sending a QR Code containing generated vCard.";
            email.Body = @"Sending a QR Code";
            email.Attachments.Add(new Attachment("qrCode.png"));

            SmtpClient smtp = new SmtpClient("smtp - mail.outlook.com");
            smtp.Host = "smtp-mail.outlook.com";
            smtp.Port = 587; // Use port 587 for TLS
            smtp.EnableSsl = true; // This enables SSL
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(senderEmail,senderPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(email);
                MessageBox.Show("Email sent successfully.");
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("Failed to send email. Error: " + ex.Message);
            }
        }
    }
}
