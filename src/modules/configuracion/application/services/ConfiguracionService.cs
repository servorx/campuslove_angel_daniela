using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.configuracion.application.interfaces;
using examen_csharp.src.modules.configuracion.infrastructure.repositories;

namespace examen_csharp.src.modules.configuracion.application.services;
public class ConfiguracionService : IConfiguracionService
{
    private readonly ConfiguracionRepository _configuracionRepository;
    public ConfiguracionService(ConfiguracionRepository configuracionRepository) => _configuracionRepository = configuracionRepository;
    public async Task<int> ObtenerMaxLikesPorDiaAsync() => await _configuracionRepository.ObtenerValorAsync("max_likes_por_dia");

}