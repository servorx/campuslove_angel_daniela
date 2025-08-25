using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campuslove_angel_daniela.src.shared.configurations;
public class InteresUsuarioConfig : IEntityTypeConfiguration<InteresUsuario>
{
    public void Configure(EntityTypeBuilder<InteresUsuario> builder)
    {
        builder.ToTable("intereses_usuarios");
        builder.HasKey(iu => new { iu.IdUsuario, iu.IdIntereses });

        builder.HasOne(iu => iu.Usuario)
                .WithMany(u => u.InteresesUsuarios)
                .HasForeignKey(iu => iu.IdUsuario);

        builder.HasOne(iu => iu.Interes)
                .WithMany(i => i.InteresesUsuarios)
                .HasForeignKey(iu => iu.IdIntereses);
    }
}