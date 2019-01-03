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
using PhoneService.Core.Models.Repair;
using PhoneService.Core.Models.Healpers;
using PhoneService.Core.Models.Customer;

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

        #region Send Email

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

        #endregion

        #region Sepcify Emails

        public async Task SendRepairStatusChangeEmailAsync(string templateName, string subject, RepairDetailsResponse repair, CustomerDecisionLink links)
        {
            var email = repair.CustomerDetails.Email;

            // Use diferent messageBody Builder if links are empty.
            if (links != null)
            {
                string messageBody = BuildCustomerDecisionMessageBody(templateName, repair, links);
                await SendEmailAsync(email, subject, messageBody);
            }
            else
            {
                string messageBody = BuildStatusChangeMessageBody(templateName, repair, links);
                await SendEmailAsync(email, subject, messageBody);
            }

        }

        public async Task SendRepairAddNotifyEmailAsync(string templateName, string subject, RepairDetailsResponse repair)
        {
            var email = repair.CustomerDetails.Email;
            var builder = new BodyBuilder();
            var _pathToFile = GetTemplateFilePathAsync(templateName);

            using (StreamReader SourceReader = System.IO.File.OpenText(_pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //{0} : Customer.Name  
            //{1} : RepairStatus.name

            string messageBody = string.Format(builder.HtmlBody,
            repair.CustomerDetails.Name,
            repair.StatusName
            );

            await SendEmailAsync(email, subject, messageBody);
        }

        public async Task SendCustomerAddNotifyEmailAsync(string templateName, string subject, CustomerDetailsResponse custoemr)
        {
            var email = custoemr.Email;
            var builder = new BodyBuilder();
            var _pathToFile = GetTemplateFilePathAsync(templateName);

            using (StreamReader SourceReader = System.IO.File.OpenText(_pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //{0} : Customer.Name  
            //{1} : Customer.LastName
            //{2} : Customer.PhoneNum  
            //{3} : Customer.Email  
            //{4} : Customer.City  
            //{5} : Customer.PostCode  

            string messageBody = string.Format(builder.HtmlBody,
            custoemr.Name,
            custoemr.LastName,
            custoemr.PhoneNum,
            custoemr.Email,
            custoemr.City,
            custoemr.PostCode
            );

            await SendEmailAsync(email, subject, messageBody);
        }

        #endregion

        #region Healpers

        public string GetTemplateFilePathAsync(string templateName)
        {
            var webRootPath = _hostingEnvironment.WebRootPath;
            var pathToFile = webRootPath
                            + Path.DirectorySeparatorChar.ToString()
                            + "Template"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailTemplate"
                            + Path.DirectorySeparatorChar.ToString()
                            + templateName;

            return pathToFile;
        }

        public string BuildCustomerDecisionMessageBody(string templateName, RepairDetailsResponse repair, CustomerDecisionLink links)
        {
            var builder = new BodyBuilder();
            var _pathToFile = GetTemplateFilePathAsync(templateName);

            using (StreamReader SourceReader = System.IO.File.OpenText(_pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //{0} : Customer.Name  
            //{1} : RepairStatus.name
            //{2} : AcceptLink
            //{3} : RejectLink

            string messageBody = string.Format(builder.HtmlBody,
            repair.CustomerDetails.Name,
            repair.StatusName,
            links.DecisionLink
            );

            return messageBody;
        }

        public string BuildStatusChangeMessageBody(string templateName, RepairDetailsResponse repair, CustomerDecisionLink links)
        {
            var email = repair.CustomerDetails.Email;
            var builder = new BodyBuilder();
            var _pathToFile = GetTemplateFilePathAsync(templateName);

            using (StreamReader SourceReader = System.IO.File.OpenText(_pathToFile))
            {
                builder.HtmlBody = SourceReader.ReadToEnd();
            }

            //{0} : Customer.Name  
            //{1} : RepairStatus.name

            string messageBody = string.Format(builder.HtmlBody,
            repair.CustomerDetails.Name,
            repair.StatusName
            );

            return messageBody;
        }

        #endregion
    }
}

