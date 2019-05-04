using System;
using Business.Interfaces;

namespace Business.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepositorio Usuarios { get; }
        IPartidaRepositorio Partidas { get; }
        void commit();
    }
}