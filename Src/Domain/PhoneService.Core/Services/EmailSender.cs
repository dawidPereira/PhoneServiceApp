using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using PhoneService.Core.Interfaces;
using PhoneService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using PhoneService.Domain;

namespace PhoneService.Core.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public EmailSender(IOptions<EmailSettings> emailSettings, IHostingEnvironment hostingEnvironment)
            {
                _emailSettings = emailSettings.Value;
                _hostingEnvironment = hostingEnvironment;
            }

            public EmailSettings _emailSettings { get; }

            public Task SendEmailAsync(string email, string subject, string message)
            {

                Execute(email, subject, message).Wait();
                return Task.FromResult(0);
            }

            public async Task Execute(string email, string subject, string message)
            {
                try
                {
                    string toEmail = string.IsNullOrEmpty(email)
                                     ? _emailSettings.ToEmail
                                     : email;

                    MailMessage mail = new MailMessage()
                    {
                        From = new MailAddress(_emailSettings.UsernameEmail, "TelMax")
                    };
                    mail.To.Add(new MailAddress(toEmail));
                //mail.CC.Add(new MailAddress(_emailSettings.CcEmail));

                var d = mail.From.Address;  
                    mail.Subject = subject;
                    mail.Body = message;
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;

                    using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(_emailSettings.UsernameEmail, _emailSettings.UsernamePassword);
                        smtp.EnableSsl = true;
                        await smtp.SendMailAsync(mail);
                    }
                }
                catch (Exception ex)
                {

                var x = ex;
                return;
                }
            }

        public async Task SendRepairStatusChangeEmailAsync(string templateName, string subject, Repair repair)
        {
            var builder = new BodyBuilder();

            var _pathToFile = GetTemplateFilePathAsync(templateName);

            using (StreamReader SourceReader = System.IO.File.OpenText(_pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            var email = repair.Customer.Email;

            //{0} : Customer.Name  
            //{1} : RepairStatus.name
            
            string messageBody = string.Format(builder.HtmlBody,
                        repair.Customer.Name,
                        repair.RepairStatus.Name
                        );

            await SendEmailAsync(email, subject, messageBody);
        }

        public string GetTemplateFilePathAsync(string templateName)
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailTemplate"
                            + Path.DirectorySeparatorChar.ToString()
                            + templateName;

            return pathToFile;
        }



        }
    }

