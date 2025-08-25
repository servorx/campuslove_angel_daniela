using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.usuario.application.interfaces;

public interface IUsuarioService
{
    Task<Usuario> CrearUsuarioAsync(Usuario usuario);
    Task<bool> EliminarUsuarioAsync(int id);
    Task<Usuario?> ObtenerPorIdAsync(int id);
    Task<Usuario?> ObtenerPorCorreoAsync(string correo);
    Task<List<Usuario>> ListarUsuariosAsync();
    Task<Usuario?> ActualizarUsuarioAsync(Usuario usuario);
}
