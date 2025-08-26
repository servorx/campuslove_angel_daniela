using campuslove_angel_daniela.src.modules.dislike.domain.models;
using campuslove_angel_daniela.src.modules.interes_usuario.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campuslove_angel_daniela.src.shared.configurations;
public class DislikeConfig : IEntityTypeConfiguration<Dislike>
{
    public void Configure(EntityTypeBuilder<Dislike> builder)
    {
        builder.ToTable("dislikes");
        builder.HasKey(d => d.Id);

        builder.Property(l => l.Fecha)
            .IsRequired()
            .HasColumnType("datetime")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
        builder.HasOne(d => d.Emisor)
                .WithMany(u => u.DislikesEnviados)
                .HasForeignKey(d => d.IdEmisor)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(d => d.Receptor)
                .WithMany(u => u.DislikesRecibidos)
                .HasForeignKey(d => d.IdReceptor)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
