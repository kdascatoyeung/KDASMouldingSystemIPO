using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Mould_System
{
    public class EmailUtil
    {
        public static void SendEmail(string from, string to, string subject)
        {
            string hostname = "Kdmail.km.local";
            string text = "Fixed Asset Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\M System\\Mould System.application\">HERE</a> to approval process.";
            string content = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage(from, to);
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = content;
            client.Send(mail);
        }

        public static void NotificationEmail(string from, string to, string subject)
        {
            string hostname = "Kdmail.km.local";
            string text = "Ringi Approval (Fixed Asset) required. Please click <a href=\"\\\\kdthk-dm1\\project\\IT System\\KDTHK_MOULD_SYSTEM\\KDTHK_MOULD_SYSTEM.application\">HERE</a> to approval process.";
            string content = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage(from, to);
            mail.IsBodyHtml = true;
            mail.Subject = subject;
            mail.Body = content;
            client.Send(mail);
        }
    }
}
