using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.usuario.application.interfaces;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using campuslove_angel_daniela.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.modules.usuario.infrastructure.repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;

    public UsuarioRepository(AppDbContext context) => _context = context;

    public async Task<Usuario?> GetByIdAsync(int id)
    {
        return await _context.Usuarios
            .Include(u => u.InteresesUsuarios)
            .Include(u => u.LikesEnviados)
            .Include(u => u.LikesRecibidos)
            .Include(u => u.DislikesEnviados)
            .Include(u => u.DislikesRecibidos)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<Usuario?> GetByCorreoAsync(string correo) => await _context.Usuarios.FirstOrDefaultAsync(u => u.Correo == correo);

    public async Task<List<Usuario>> GetAllAsync() => await _context.Usuarios.ToListAsync();

    public async Task AddAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
    
}
