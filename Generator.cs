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

namespace QR_Generator
{
    public partial class Generator : Form
    {
        Main mainForm;
        QRCode qrCode;
        QRCodeGenerator qrCodeGenerator;
        QRCodeData qrData;
        string data;
        Bitmap qrImage;
        public Generator(Main main)
        {
            mainForm = main;
            GenerateQRImage();
            InitializeComponent();
            textBox1.Text = data;
            pictureBox1.Image = Image.FromFile("qrImage.png");
        }

        private void GenerateQRImage()
        {
            data = mainForm.GetQRData();
            qrCodeGenerator = new QRCodeGenerator();
            qrData = qrCodeGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            qrCode = new QRCode(qrData);
            qrImage = qrCode.GetGraphic(10);
            qrImage.Save("qrImage.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
