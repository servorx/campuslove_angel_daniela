
using campuslove_angel_daniela.src.modules.dislike.domain.models;
using campuslove_angel_daniela.src.modules.interes.domain.models;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.modules.like.domain.models;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.shared.context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    // en esta parte deben de ir los DbSet de cada entidad, este es un ejemplo 
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Interes> Intereses { get; set; }
    public DbSet<InteresUsuario> InteresesUsuarios { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Dislike> Dislikes { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}