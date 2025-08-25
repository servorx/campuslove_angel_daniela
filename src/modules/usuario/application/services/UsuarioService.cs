using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using campuslove_angel_daniela.src.modules.usuario.infrastructure.repositories;

namespace campuslove_angel_daniela.src.modules.usuario.application.services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository) =>_usuarioRepository = usuarioRepository;

    public async Task<Usuario?> ObtenerPorIdAsync(int id) => await _usuarioRepository.GetByIdAsync(id);

    public async Task<Usuario?> ObtenerPorCorreoAsync(string correo) => await _usuarioRepository.GetByCorreoAsync(correo);

    public async Task<List<Usuario>> ListarUsuariosAsync() => await _usuarioRepository.GetAllAsync();

    public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
    {
        // Validación ejemplo
        var existente = await _usuarioRepository.GetByCorreoAsync(usuario.Correo);
        if (existente != null)
            throw new Exception("El correo ya está registrado.");

        await _usuarioRepository.AddAsync(usuario);
        return usuario;
    }

    public async Task<Usuario?> ActualizarUsuarioAsync(Usuario usuario)
    {
        var existente = await _usuarioRepository.GetByIdAsync(usuario.Id);
        if (existente == null) return null;

        existente.Nombre = usuario.Nombre;
        existente.Apellido = usuario.Apellido;
        existente.Correo = usuario.Correo;
        existente.Contrasenia = usuario.Contrasenia;
        existente.Edad = usuario.Edad;
        existente.Carrera = usuario.Carrera;
        existente.Frase = usuario.Frase;
        existente.Orientacion = usuario.Orientacion;
        existente.Busqueda = usuario.Busqueda;

        await _usuarioRepository.UpdateAsync(existente);
        return existente;
    }

    public async Task<bool> EliminarUsuarioAsync(int id)
    {
        var existente = await _usuarioRepository.GetByIdAsync(id);
        if (existente == null) return false;

        await _usuarioRepository.DeleteAsync(id);
        return true;
    }
}
