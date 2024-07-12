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
            StringBuilder fw = new StringBuilder();
            fw.Append(Header);
            fw.Append(NewLine);

            //Full Name
            if (!string.IsNullOrEmpty(data.firstName) || !string.IsNullOrEmpty(data.lastName))
            {
                fw.Append(Name);
                fw.Append(data.lastName);
                fw.Append(Separator);
                fw.Append(data.firstName);
                fw.Append(Separator);
                fw.Append(NewLine);
            }

            //Formatted Name
            if (!string.IsNullOrEmpty(data.FormattedName))
            {
                fw.Append(FormattedName);
                fw.Append(data.FormattedName);
                fw.Append(NewLine);
            }

            //Organization name
            if (!string.IsNullOrEmpty(data.company))
            {
                fw.Append(OrganizationName);
                fw.Append(data.company);
                fw.Append(NewLine);

            }

            //Email
            if (!string.IsNullOrEmpty(data.mail))
            {
                fw.Append(EmailPrefix);
                fw.Append(data.mail);
                fw.Append(NewLine);
            }

            fw.Append(Footer);

            return fw.ToString();
        }
    }
}
