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