using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.domain.models;

namespace campuslove_angel_daniela.src.modules.interes.application.interfaces;
public interface IInteresRepository
{
    Task AddAsync(Interes interes);    
    Task AddRangeAsync(List<Interes> intereses);
    Task UpdateAsync(Interes interes);
    Task DeleteAsync(int id);
    Task<List<Interes>> GetAllAsync();
    Task<List<Interes>> GetByNombresAsync(List<string> nombres);
    Task<Interes?> GetByIdAsync(int id);
}
