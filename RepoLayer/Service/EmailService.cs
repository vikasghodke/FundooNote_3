using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Service
{
    public class EmailService
    {
        private readonly SmtpClient smtpClient;


        public EmailService()
        {
            smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("YourPCMail@gmail.com", "Mail Password"),

                EnableSsl = true

            };
        }
        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage("YourPCMail@gmail.com", to, subject, body)
            {
                IsBodyHtml = false
            };
            await smtpClient.SendMailAsync(mailMessage);
        }
         
    }
            

    }


