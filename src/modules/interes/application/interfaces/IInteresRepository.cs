using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.domain.models;

namespace campuslove_angel_daniela.src.modules.interes.application.interfaces;
public interface IInteresRepository
{
    Task<List<Interes>> GetAllAsync();
    Task<Interes?> GetByIdAsync(int id);
    Task AddAsync(Interes interes);
    Task UpdateAsync(Interes interes);
    Task DeleteAsync(int id);
}
