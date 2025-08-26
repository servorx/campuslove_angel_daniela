using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.application.interfaces;
using campuslove_angel_daniela.src.modules.interes.domain.models;
using campuslove_angel_daniela.src.modules.interes_usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.modules.usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using examen_csharp.src.shared.utils;

namespace campuslove_angel_daniela.src.modules.usuario.application.services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IInteresRepository _interesRepository;
    private readonly IInteresUsuarioRepository _interesUsuarioRepository;
    // utiliza sobrecarga de constructor para inyectar dependencias de la parte de infraestructura 
    public UsuarioService(
        IUsuarioRepository usuarioRepository,
        IInteresRepository interesRepository,
        IInteresUsuarioRepository interesUsuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
        _interesRepository = interesRepository;
        _interesUsuarioRepository = interesUsuarioRepository;
    }
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
    public async Task<Usuario> CrearUsuarioConInteresesAsync(Usuario usuario, List<string> interesesNombres)
    {
        // registrar usuario
        await _usuarioRepository.AddAsync(usuario);

        // Buscar los intereses existentes
        var interesesExistentes = await _interesRepository.GetByNombresAsync(interesesNombres);

        // Crea los que no existan
        var nuevosInteresesNombres = interesesNombres
            .Except(interesesExistentes.Select(i => i.Nombre))
            .ToList();

        var nuevosIntereses = nuevosInteresesNombres
            .Select(nombre => new Interes { Nombre = nombre })
            .ToList();

        if (nuevosIntereses.Any())
            await _interesRepository.AddRangeAsync(nuevosIntereses);

        // vincular los intereses
        var todosIntereses = interesesExistentes.Concat(nuevosIntereses).ToList();

        foreach (var interes in todosIntereses)
        {
            var interesUsuario = new InteresUsuario
            {
                IdUsuario = usuario.Id,
                IdIntereses = interes.Id
            };
            await _interesUsuarioRepository.AddAsync(interesUsuario);
        }

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
    public async Task<bool> VerificarLoginAsync(string correo, string contrasenia)
    {
        var usuario = await _usuarioRepository.GetByCorreoAsync(correo);
        if (usuario == null) return false;

        return PasswordHasher.VerifyPassword(contrasenia, usuario.Contrasenia);
    }
    public async Task<Usuario?> GetUsuarioPorCredencialesAsync(string email, string password)
    {
        var usuarios = await _usuarioRepository.GetAllAsync(); 
        return usuarios.FirstOrDefault(u =>
            u.Correo == email &&
            PasswordHasher.VerifyPassword(password, u.Contrasenia));
    }
}
