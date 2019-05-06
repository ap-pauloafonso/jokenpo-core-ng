using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace EmailAPI.Service
{
    public class SMTPService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SMTPService(IConfiguration cfg, IHttpContextAccessor httpContextAccessor)
        {
            this._configuration = cfg;
            this._httpContextAccessor = httpContextAccessor;
        }
        public Task SendEmail(string user, string email)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = _configuration["EmailSettings:Email"],
                    Password = _configuration["EmailSettings:Password"]
                };

                client.Credentials = credential;
                client.Host = _configuration["EmailSettings:Host"];
                client.Port = int.Parse(_configuration["EmailSettings:Port"]);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_configuration["EmailSettings:Email"]);
                    emailMessage.Subject = "Confirmação de email Jokenpo-core-ng";
                    emailMessage.Body = $"Olá {user}, obrigado por se cadastrar no Jokenpo-core-ng acesse o link para confirmar seu cadastro:http://localhost:5050/api/email/confirmation/" + user;
                    client.Send(emailMessage);
                }
            }
            return Task.CompletedTask;
        }
    }
}