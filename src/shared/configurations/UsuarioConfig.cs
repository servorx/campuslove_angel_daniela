using examen_csharp.src.modules.usuario.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen_csharp.src.shared.configurations;
public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        // Nombre de la tabla en la BD
        builder.ToTable("usuarios");

        // Definir clave primaria
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).ValueGeneratedOnAdd();
        // definir las tablas
        builder.Property(u => u.Nombre).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Apellido).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Genero).IsRequired().HasMaxLength(15);
        builder.Property(u => u.Carrera).IsRequired().HasMaxLength(40);
        builder.Property(u => u.Intereses).IsRequired().HasMaxLength(200);
        builder.Property(u => u.Frase).IsRequired().HasMaxLength(255);

    }
}
