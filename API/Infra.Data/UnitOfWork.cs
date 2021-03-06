using System;
using Business.Interfaces;
using System.Linq;

namespace Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {

        public IUsuarioRepositorio Usuarios { get; private set; }

        public IPartidaRepositorio Partidas { get; private set; }

        private readonly JokenpoContext _context;

        public UnitOfWork(JokenpoContext context, IUsuarioRepositorio  usuRepo,IPartidaRepositorio partidaRepo )
        {
            _context = context;
            Usuarios = usuRepo;
            Partidas = partidaRepo;
        }
        public void commit()
        {
           var test = this._context.ChangeTracker.Entries().Select(x=> new {x.Entity, x.State}).ToList();
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}