using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.usuario.application.interfaces;
using examen_csharp.src.modules.usuario.domain.models;
using examen_csharp.src.modules.usuario.infrastructure.repositories;

namespace examen_csharp.src.modules.usuario.application.services;

public class UsuarioService : IUsuarioService
{
    private readonly UsuarioRepository _usuarioRepository;
    public UsuarioService(UsuarioRepository usuarioRepository) => _usuarioRepository = usuarioRepository;
    public async Task<Usuario> AgregarUsuarioAsync(Usuario usuario)
    {
        _usuarioRepository.Add(usuario);
        await _usuarioRepository.SaveAsync();
        return usuario;
    }
    public async Task<Usuario> ObtenerUsuarioPorIdAsync(int id) => await _usuarioRepository.GetById(id);
    public async Task<IEnumerable<Usuario>> ObtenerTodosLosUsuariosAsync() => await _usuarioRepository.GetAllAsync();
}
