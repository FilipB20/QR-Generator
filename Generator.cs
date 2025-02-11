﻿using System;
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
        QRCodeGenerator qrGenerator;
        QRCodeData qrData;
        Bitmap qrImage;
        QRCode qrCode;
        EmailSender emailSender;
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
            qrCode = new QRCode(qrData);
            qrImage = qrCode.GetGraphic(5);
            qrImage.Save("qrCode.png");
        }

        public QRCode GetQRCode()
        {
            return qrCode;
        }

        private string GenerateVCard()
        {
            ContactData data = new ContactData(ContactData.ContactOutputType.VCard3, $"{mainForm.firstName}", $"{mainForm.lastName}", null, null, null, null, $"{mainForm.mail}", null, null, null, null, null, null, null, null, null, ContactData.AddressOrder.Default, $"{mainForm.company}", null);
            return data.ToString();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PasswordEnterer passwordEnterer = new PasswordEnterer(mainForm);
            passwordEnterer.Show();
            
        }
    }
}
