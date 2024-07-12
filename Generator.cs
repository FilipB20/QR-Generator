using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QR_Generator;
using QRCoder;
using static QRCoder.PayloadGenerator;
using VCard.Models;
using VCard.Helpers;    

namespace QR_Generator
{
    public partial class Generator : Form
    {
        Main mainForm;
        QRCode qrCode;
        QRCodeGenerator qrGenerator;
        QRCodeData qrData;
        Bitmap qrImage;
        Payload payload;
        public Generator(Main main)
        {
            mainForm = main;
            GenerateQRImage();
            InitializeComponent();
            pictureBox1.Image = qrImage;
        }

        private void GenerateQRImage()
        {
            qrGenerator = new QRCodeGenerator();
            qrData = qrGenerator.CreateQrCode(GenerateVCard(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);
            qrImage = qrCode.GetGraphic(5);
        }

        private string GenerateVCard()
        {
            ContactData data=new ContactData(ContactData.ContactOutputType.VCard3, $"{mainForm.firstName}", $"{mainForm.lastName}", null, null, null, null, $"{mainForm.mail}", null, null, null, null, null, null, null, null, null, ContactData.AddressOrder.Default, $"{mainForm.company}", null);
            return data.ToString();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Generator_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = $"Name: {mainForm.firstName} Last name: {mainForm.lastName} E-mail: {mainForm.mail} Company: {mainForm.company}";
        }
    }
}
