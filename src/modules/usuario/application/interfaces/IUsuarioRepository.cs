using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.usuario.application.interfaces;

public interface IUsuarioRepository
{
    void Add(Usuario usuario);
    Task<Usuario> GetById(int id);
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task SaveAsync();
}
