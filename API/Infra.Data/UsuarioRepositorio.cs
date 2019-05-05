using System.Collections.Generic;
using System.Linq;
using Business.Interfaces;
using Business.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {

        public JokenpoContext JokenpoContext
        {
            get { return Context as JokenpoContext; }
        }

        public IEnumerable<Usuario> ConsultarUsuariosComPartidas(string user = null)
        {
            return this.JokenpoContext.Usuarios
            .Where(x => (user == null) || (x.UsuarioId == user))
            .Include(x => x.partidas);

        }

        public UsuarioRepositorio(JokenpoContext context) : base(context)
        {
        }
        public Usuario ConsultarUsuarioPorEmail(string email)
        {
            return JokenpoContext.Usuarios.Where(x => x.email == email).FirstOrDefault();
        }

        public Usuario ConsultarUsuarioPorId(string usuario)
        {
            return JokenpoContext.Usuarios.Where(x => x.UsuarioId == usuario).FirstOrDefault();

        }
    }
}