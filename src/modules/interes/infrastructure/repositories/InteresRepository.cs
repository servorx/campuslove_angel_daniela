using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.application.interfaces;
using campuslove_angel_daniela.src.modules.interes.domain.models;
using campuslove_angel_daniela.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.modules.interes.infrastructure.repositories;

public class InteresRepository : IInteresRepository
{
    private readonly AppDbContext _context;
    public InteresRepository(AppDbContext context) => _context = context;
    public async Task<List<Interes>> GetAllAsync() => await _context.Intereses.ToListAsync();
    public async Task<Interes?> GetByIdAsync(int id)
    {
        return await _context.Intereses.FirstOrDefaultAsync(i => i.Id == id);
    }
    public async Task AddAsync(Interes interes)
    {
        _context.Intereses.Add(interes);
        await _context.SaveChangesAsync();
    }
    public async Task AddRangeAsync(List<Interes> intereses)
    {
        _context.Intereses.AddRange(intereses);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Interes interes)
    {
        _context.Intereses.Update(interes);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var interes = await _context.Intereses.FindAsync(id);
        if (interes != null)
        {
            _context.Intereses.Remove(interes);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<List<Interes>> GetByNombresAsync(List<string> nombres) => await _context.Intereses.Where(i => nombres.Contains(i.Nombre)).ToListAsync();
}
