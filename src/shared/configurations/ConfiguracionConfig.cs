using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.configuracion.domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen_csharp.src.shared.configurations;

public class ConfiguracionConfig : IEntityTypeConfiguration<Configuracion>
{
    public void Configure(EntityTypeBuilder<Configuracion> builder)
    {
        builder.ToTable("configuracion");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Clave).IsRequired().HasMaxLength(50);
        builder.Property(c => c.Valor).IsRequired();
        builder.HasIndex(c => c.Clave).IsUnique();
    }
}