namespace Infra.EmailService.Contratos
{
    public interface IEmailCadastrado
    {
        string user { get; set; }
        string email { get; set; }
    }

}