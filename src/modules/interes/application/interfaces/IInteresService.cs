using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.domain.models;

namespace campuslove_angel_daniela.src.modules.interes.application.interfaces;
public interface IInteresService
{
    Task<List<Interes>> ListarInteresesAsync();
    Task<Interes?> BuscarInteresAsync(int id);
    Task CrearInteresAsync(string nombre, string descripcion);
    Task ActualizarInteresAsync(int id, string nombre, string descripcion);
    Task EliminarInteresAsync(int id);
}
