using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace CheckerApp
{
    class EmailSender : ISender
    {
        public void Sending(String msg)
        {
            String login = "test53421@yandex.ru";
            String pass = "qwetry123";

            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 25);
            smtp.Credentials = new NetworkCredential(login, pass);
            MailMessage message = new MailMessage();
            message.From = new MailAddress(login);
            message.To.Add(new MailAddress(login/*sergey@testor.ru*/));
            message.Subject = "Сhecker ERROR from "+System.Environment.UserName;
            message.Body = msg;

            try
            {
                smtp.Send(message);
                Console.WriteLine("EMail Successfully Sent");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error sending email : " + e.Message);
            }


       }
    }
}
