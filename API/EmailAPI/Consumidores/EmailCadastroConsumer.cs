using System.Threading.Tasks;
using EmailAPI.Service;
using Infra.EmailService.Contratos;
using MassTransit;
using Microsoft.AspNetCore.Http;

namespace EmailAPI.Consumidores
{
    public class EmailCadastroConsumer : IConsumer<IEmailCadastrado>
    {

        SMTPService _smtpService;
        public EmailCadastroConsumer(SMTPService SMTPService)
        {
            this._smtpService = SMTPService;
        }
        public Task Consume(ConsumeContext<IEmailCadastrado> context)
        {
            _smtpService.SendEmail(context.Message.user, context.Message.email);
            return Task.CompletedTask;
        }
    }
}