using System;
using System.Net;
using System.Net.Mail;
using Business.Interfaces;
using Infra.EmailService.Contratos;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace Infra.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private IBusControl bus;
        private IJokenpoService jokenpoService;
        public EmailService(IConfiguration configuration, IBusControl buscontrol, IJokenpoService jokenpoService)
        {
            _configuration = configuration;
            bus = buscontrol;
            this.jokenpoService = jokenpoService;
        }
        public void MandarEmail(string user, string email)
        {
            bus.Publish<IEmailCadastrado>(new { user = user, email = email });
        }

        public void ReceberConfirmacao(string user, DateTime data)
        {
            this.jokenpoService.ConfirmarUsuario(user, data);
        }
    }
}
