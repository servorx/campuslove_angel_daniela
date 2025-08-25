using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.interes_usuario.application.interfaces;
public interface IInteresUsuarioService
{
    Task<IEnumerable<InteresUsuario>> GetAllAsync();
    Task<InteresUsuario?> GetByIdAsync(int idUsuario, int idInteres);
    Task AddAsync(InteresUsuario interesUsuario);
    Task DeleteAsync(int idUsuario, int idInteres);
    Task<IEnumerable<InteresUsuario>> GetByUsuarioAsync(int idUsuario);
    Task<IEnumerable<InteresUsuario>> GetByInteresAsync(int idInteres);
}
