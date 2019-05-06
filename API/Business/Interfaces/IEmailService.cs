using System;

namespace Business.Interfaces
{
    public interface IEmailService
    {
        void MandarEmail(string user, string email);

        void ReceberConfirmacao(string user, DateTime data);

    }
}