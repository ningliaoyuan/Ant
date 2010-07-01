using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace Ant.Models.Account
{
    public static class EmailAdmin
    {
        public static void SendPassword(string targetEmail, string userName, string password)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.gmail.com");

            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("kaogmat", "makee.cn");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailAddress addressFrom = new MailAddress("kaogmat@gmail.com", "Master of KaoGMAT");
            MailAddress addressTo = new MailAddress(targetEmail, userName);

            System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Sender = addressFrom;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = "Your password";
            message.Body = "Hi, your password is:" + password;

            client.Send(message);
        }

        public static void SendResetPasswordLink(string targetEmail, string userName)
        {
            string resetLink = CookResetPasswordLink(userName);

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

        private static string CookResetPasswordLink(string userName)
        {
            return string.Format("username={0}&k={1}", userName, "ningliaoyuanishandsome");
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
