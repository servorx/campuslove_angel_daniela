using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using campuslove_angel_daniela.src.modules.like.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campuslove_angel_daniela.src.shared.configurations;
public class LikeConfig : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.ToTable("likes");
        builder.HasKey(l => l.Id);

        // tabla de es_match
        builder.Property(l => l.EsMatch)
            .HasColumnName("es_match")
            .IsRequired(); 

        // define los nombres de las columnas
        builder.Property(l => l.IdEmisor).HasColumnName("id_emisor");
        builder.Property(l => l.IdReceptor).HasColumnName("id_receptor");

        builder.HasOne(l => l.Emisor)
                .WithMany(u => u.LikesEnviados)
                .HasForeignKey(l => l.IdEmisor)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.Receptor)
                .WithMany(u => u.LikesRecibidos)
                .HasForeignKey(l => l.IdReceptor)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
