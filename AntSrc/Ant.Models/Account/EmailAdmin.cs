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

//            From: My Google Apps E-mail Address
//Delivery Method: Network
//Network Host: smtp.gmail.com
//Password: My Google Apps E-mail Password
//Port: 465
//Enable SSL: true
//Username: My Google Apps E-mail Address

            System.Net.Mail.SmtpClient client = new SmtpClient("smtp.olivemail.net");

            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("master@kaogmat.com", "makee.cn");
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;


            MailAddress addressFrom = new MailAddress("master@kaogmat.com");
            MailAddress addressTo = new MailAddress(targetEmail, userName);

            System.Net.Mail.MailMessage message = new MailMessage(addressFrom, addressTo);
            message.Sender = new MailAddress("master@kaogmat.com");
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            message.Subject = "Your password";
            message.Body = "Hi, your password is:" + password;
            client.Send(message);
        }
    }
}
