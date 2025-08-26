using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.shared.context;
using examen_csharp.src.modules.configuracion.application.interfaces;
using Microsoft.EntityFrameworkCore;

namespace examen_csharp.src.modules.configuracion.infrastructure.repositories;

public class ConfiguracionRepository : IConfiguracionRepository
{
    private readonly AppDbContext _context;
    public ConfiguracionRepository(AppDbContext context) =>_context = context;
    public async Task<int> ObtenerValorAsync(string clave)
    {
        var config = await _context.Configuraciones
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Clave == clave);

        return config?.Valor ?? 0;
    }
}