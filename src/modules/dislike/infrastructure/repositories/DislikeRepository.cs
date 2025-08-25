using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.dislike.domain.models;
using campuslove_angel_daniela.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.modules.dislike.infrastructure.repositories;
public class DislikeRepository
{
    private readonly AppDbContext _context;

    public DislikeRepository(AppDbContext context) =>_context = context;    

    public async Task<Dislike> CrearDislikeAsync(Dislike dislike)
    {
        _context.Dislikes.Add(dislike);
        await _context.SaveChangesAsync();
        return dislike;
    }

    public async Task<Dislike?> ObtenerPorIdAsync(int id)
    {
        return await _context.Dislikes
            .Include(d => d.Emisor)
            .Include(d => d.Receptor)
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<IEnumerable<Dislike>> ObtenerTodosAsync()
    {
        return await _context.Dislikes
            .Include(d => d.Emisor)
            .Include(d => d.Receptor)
            .ToListAsync();
    }

    public async Task<IEnumerable<Dislike>> ObtenerPorEmisorAsync(int idEmisor)
    {
        return await _context.Dislikes
            .Include(d => d.Emisor)
            .Include(d => d.Receptor)
            .Where(d => d.IdEmisor == idEmisor)
            .ToListAsync();
    }

    public async Task<IEnumerable<Dislike>> ObtenerPorReceptorAsync(int idReceptor)
    {
        return await _context.Dislikes
            .Include(d => d.Emisor)
            .Include(d => d.Receptor)
            .Where(d => d.IdReceptor == idReceptor)
            .ToListAsync();
    }

    public async Task EliminarAsync(int id)
    {
        var dislike = await _context.Dislikes.FindAsync(id);
        if (dislike != null)
        {
            _context.Dislikes.Remove(dislike);
            await _context.SaveChangesAsync();
        }
    }
}
