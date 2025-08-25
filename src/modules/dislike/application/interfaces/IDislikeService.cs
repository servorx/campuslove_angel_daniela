using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.dislike.domain.models;

namespace campuslove_angel_daniela.src.modules.dislike.application.interfaces;
public interface IDislikeService
{

    Task<Dislike> CrearDislikeAsync(Dislike dislike);
    Task<Dislike?> ObtenerPorIdAsync(int id);
    Task<IEnumerable<Dislike>> ObtenerTodosAsync();
    Task<IEnumerable<Dislike>> ObtenerPorEmisorAsync(int idEmisor);
    Task<IEnumerable<Dislike>> ObtenerPorReceptorAsync(int idReceptor);
    Task EliminarAsync(int id);
}
