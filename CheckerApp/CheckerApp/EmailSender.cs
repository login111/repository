using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckerApp
{
    class EmailSender : ISender
    {
        public void Sending()
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("dest@gmail.com");
            message.Subject = "Ошибка";
            message.From = new System.Net.Mail.MailAddress("from@gmail.com");
            message.Body = "Ошибка";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");
            smtp.Send(message);
        }
    }
}
