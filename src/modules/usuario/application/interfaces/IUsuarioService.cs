using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.usuario.domain.models;

namespace examen_csharp.src.modules.usuario.application.interfaces;

public interface IUsuarioService
{
    Task<Usuario> AgregarUsuarioAsync(Usuario usuario);
    Task<Usuario> ObtenerUsuarioPorIdAsync(int id);
    Task<IEnumerable<Usuario>> ObtenerTodosLosUsuariosAsync();
}
