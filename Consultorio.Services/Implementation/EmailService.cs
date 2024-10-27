using Consultorio.Models;
using Consultorio.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Services.Implementation
{
    public class EmailService : IEmailServices
    {
        private readonly ILogger<EmailService> _logger;
        private readonly SmtpConfiguration _smtpConfiguration;

        public EmailService(ILogger<EmailService> logger,
            IOptions<Appsettings> options)
        {
            _logger = logger;
            _smtpConfiguration = options.Value.SmtpConfiguration;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //simulando un correo
            _logger.LogInformation(message);
            return Task.FromResult(0);

        
            //manejo de correos con outlook
            try
            {
                var mailMessage = new MailMessage(new MailAddress(_smtpConfiguration.UserName, _smtpConfiguration.FromName)
                                                 , new MailAddress(email));
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;

                // envio de correo
                using var smtClient = new SmtpClient(_smtpConfiguration.Server, _smtpConfiguration.Port)
                {
                    Credentials = new NetworkCredential(_smtpConfiguration.UserName, _smtpConfiguration.Password),
                    EnableSsl = _smtpConfiguration.EnableSsl
                };
                //await smtClient.SendMailAsync(mailMessage);
            }
            catch (SmtpException ex)
            {
                _logger.LogWarning(ex, "No se peude enviar el correo a {email}", email);
            }
            catch (Exception ex)
            {

                _logger.LogCritical(ex, "Error al enviar correo a {email}{message}", email, ex.Message);
            }
        }
        
    }
}
