using System.Threading.Tasks;
using Business.Interfaces;
using Infra.EmailService.Contratos;
using MassTransit;

namespace JokenpoAPI.Consumidores
{
    public class EmailConfirmadoConsumer : IConsumer<IEmailConfirmado>
    {
        IEmailService emailService;
        public EmailConfirmadoConsumer(IEmailService EmailService)
        {
            this.emailService = EmailService;
        }
        public Task Consume(ConsumeContext<IEmailConfirmado> context)
        {
            this.emailService.ReceberConfirmacao(context.Message.user, context.Message.dataConfirmacao);
            return Task.CompletedTask;
        }
    }
}