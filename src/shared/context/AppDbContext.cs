using examen_csharp.src.modules.entidad.domain.models;
using examen_csharp.src.modules.usuario.domain.models;
using Microsoft.EntityFrameworkCore;

namespace examen_csharp.src.shared.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // en esta parte deben de ir los DbSet de cada entidad, este es un ejemplo 
    public DbSet<Usuario> Usuarios { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}