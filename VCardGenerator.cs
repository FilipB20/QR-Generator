using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCard.Helpers;

namespace QR_Generator
{
    internal class VCardGenerator
    {
        const string NewLine = "\r\n";
        const string Separator = ";";
        const string Header = "BEGIN:VCARD\r\nVERSION:2.1";
        const string Name = "N:";
        const string FormattedName = "FN:";
        const string OrganizationName = "ORG:";
        const string TitlePrefix = "TITLE:";
        const string PhotoPrefix = "PHOTO;ENCODING=BASE64;JPEG:";
        const string PhonePrefix = "TEL;TYPE=";
        const string PhoneSubPrefix = ",VOICE:";
        const string AddressPrefix = "ADR;TYPE=";
        const string AddressSubPrefix = ":;;";
        const string EmailPrefix = "EMAIL:";
        const string Footer = "END:VCARD";

        public static string CreateVCard(Main data)
        {
            // begin:vcard
            // fn:Matt Smith
            // n:Smith;Matt
            // org:Chilkat Software, Inc.
            // tel;work:630-784-9670
            // url:http://www.chilkatsoft.com
            // version:2.1
            // end:vcard
            
            StringBuilder fw = new StringBuilder();
            fw.Append("begin:vcard");
            fw.Append("fn"+data.firstName+" "+data.lastName);
            fw.Append("n:" + data.lastName + Separator + data.lastName);
            fw.Append("org:" + data.company);
            fw.Append("end:vcard");

            return fw.ToString();
        }
    }
}
