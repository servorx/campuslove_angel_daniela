using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examen_csharp.src.modules.configuracion.domain.models;

namespace examen_csharp.src.modules.configuracion.application.interfaces;

public interface IConfiguracionService
{
    Task<int> ObtenerMaxLikesPorDiaAsync();
}
