using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes_usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.interes_usuario.application.services;
public class InteresUsuarioService : IInteresUsuarioService
{
    private readonly IInteresUsuarioRepository _repository;

    public InteresUsuarioService(IInteresUsuarioRepository repository) =>_repository = repository;

    public Task<IEnumerable<InteresUsuario>> GetAllAsync() => _repository.GetAllAsync();

    public Task<InteresUsuario?> GetByIdAsync(int idUsuario, int idInteres) => _repository.GetByIdAsync(idUsuario, idInteres);
    public Task AddAsync(InteresUsuario interesUsuario) => _repository.AddAsync(interesUsuario);

    public Task DeleteAsync(int idUsuario, int idInteres) => _repository.DeleteAsync(idUsuario, idInteres);

    public Task<IEnumerable<InteresUsuario>> GetByUsuarioAsync(int idUsuario) => _repository.GetByUsuarioAsync(idUsuario);

    public Task<IEnumerable<InteresUsuario>> GetByInteresAsync(int idInteres) => _repository.GetByInteresAsync(idInteres);
}
