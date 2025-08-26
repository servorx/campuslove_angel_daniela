using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes_usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.modules.interes_usuario.infrastructure.repositories;
public class InteresUsuarioRepository : IInteresUsuarioRepository
{
    private readonly AppDbContext _context;
    public InteresUsuarioRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<InteresUsuario>> GetAllAsync()
    {
        return await _context.InteresesUsuarios
            .Include(iu => iu.Usuario)
            .Include(iu => iu.Interes)
            .ToListAsync();
    }

    public async Task<InteresUsuario?> GetByIdAsync(int idUsuario, int idInteres)
    {
        return await _context.InteresesUsuarios
            .Include(iu => iu.Usuario)
            .Include(iu => iu.Interes)
            .FirstOrDefaultAsync(iu => iu.IdUsuario == idUsuario && iu.IdIntereses == idInteres);
    }

    public async Task AddAsync(InteresUsuario interesUsuario)
    {
        _context.InteresesUsuarios.Add(interesUsuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int idUsuario, int idInteres)
    {
        var interesUsuario = await GetByIdAsync(idUsuario, idInteres);
        if (interesUsuario != null)
        {
            _context.InteresesUsuarios.Remove(interesUsuario);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<InteresUsuario>> GetByUsuarioAsync(int idUsuario)
    {
        return await _context.InteresesUsuarios
            .Include(iu => iu.Interes)
            .Where(iu => iu.IdUsuario == idUsuario)
            .ToListAsync();
    }

    public async Task<IEnumerable<InteresUsuario>> GetByInteresAsync(int idInteres)
    {
        return await _context.InteresesUsuarios
            .Include(iu => iu.Usuario)
            .Where(iu => iu.IdIntereses == idInteres)
            .ToListAsync();
    }
}
