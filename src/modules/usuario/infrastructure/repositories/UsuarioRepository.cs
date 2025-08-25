using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.usuario.application.interfaces;
using examen_csharp.src.modules.usuario.domain.models;
using examen_csharp.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace examen_csharp.src.modules.usuario.infrastructure.repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _context;
    public UsuarioRepository(AppDbContext context) => _context = context;

    public void Add(Usuario usuario) => _context.Usuarios.Add(usuario);
    public async Task<Usuario> GetById(int id) => await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
    public async Task<IEnumerable<Usuario>> GetAllAsync() =>  await _context.Usuarios.ToListAsync();
    public async Task SaveAsync() => await _context.SaveChangesAsync();
}
