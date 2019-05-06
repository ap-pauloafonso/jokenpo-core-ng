using System;

namespace Infra.EmailService.Contratos
{
    public class IEmailConfirmado
    {
        public string user { get; set; }
        public DateTime dataConfirmacao { get; set; }
    }
}