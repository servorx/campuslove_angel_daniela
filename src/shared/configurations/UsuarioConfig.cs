using campuslove_angel_daniela.src.modules.usuario.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen_csharp.src.shared.configurations;
public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("usuarios");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Nombre).HasMaxLength(80).IsRequired();
        builder.Property(u => u.Apellido).HasMaxLength(80).IsRequired();
        builder.Property(u => u.Correo).HasMaxLength(80).IsRequired();
        builder.Property(u => u.Contrasenia).HasMaxLength(40).IsRequired();
        builder.Property(u => u.Edad).IsRequired();
        builder.Property(u => u.Carrera).HasMaxLength(100);
        builder.Property(u => u.Frase).HasMaxLength(255);
        builder.Property(u => u.Orientacion).HasMaxLength(70).IsRequired();
        builder.Property(u => u.Busqueda).HasMaxLength(40).IsRequired();

    }
}
