using System.Collections.Generic;
using Business.Modelos;

namespace Business.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario ConsultarUsuarioPorId(string nickName);
        Usuario ConsultarUsuarioPorEmail(string email);
        IEnumerable<Usuario> ConsultarUsuariosComPartidas(string user = null);
    }
}