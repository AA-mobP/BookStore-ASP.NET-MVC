﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace BookStore.Models.Repository
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //string fromEmail = "ahmed-abdelhady-iti-s24@outlook.com";
            //string fromPassword = "ITI-S24-AhAb";
            string fromEmail = "abdelhady-ashraf7655@outlook.com";
            string fromPassword = "me1me2ma7655";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromEmail);
            message.To.Add(email);
            message.Subject = subject;
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient(host: "smtp-mail.outlook.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                EnableSsl = true
            };
            smtpClient.Send(message);
        }
    }
}