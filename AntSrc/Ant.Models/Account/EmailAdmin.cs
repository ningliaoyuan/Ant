using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using Ant.Models.Common;
using System.Configuration;
using System.Web;

namespace Ant.Models.Account
{
    public static class EmailAdmin
    {
        public static void SendResetPasswordLink(string targetEmail, string userName, string hash)
        {
            string host = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            string url = ConfigurationManager.AppSettings["ResetPasswordUrl"];
            string resetLink = string.Format("{0}/{1}?username={2}&k={3}", host, url, userName, HttpUtility.UrlEncode(hash));

            MailAddress addressFrom = GetMasterMail();
            MailAddress addressTo = new MailAddress(targetEmail, userName);

            System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Sender = addressFrom;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = "Your password";
            message.Body = "Hi, please go to the following link to reset your password: " + resetLink;

            System.Net.Mail.SmtpClient client = GetSmtpClient();
            client.Send(message);
        }

       

        private static MailAddress GetMasterMail()
        {
            MailAddress addressFrom = new MailAddress("kaogmat@gmail.com", "Master of KaoGMAT");
            return addressFrom;
        }

        private static System.Net.Mail.SmtpClient GetSmtpClient()
        {
            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("kaogmat", "makee.cn");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            return client;
        }
    }
}
