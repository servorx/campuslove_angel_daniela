using campuslove_angel_daniela.src.modules.interes.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace campuslove_angel_daniela.src.shared.configurations;
public class InteresConfig : IEntityTypeConfiguration<Interes>
{
    public void Configure(EntityTypeBuilder<Interes> builder)
    {
        builder.ToTable("intereses");
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Nombre).HasMaxLength(50).IsRequired();
    }
}