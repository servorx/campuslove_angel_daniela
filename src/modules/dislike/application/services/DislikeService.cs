using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.dislike.application.interfaces;
using campuslove_angel_daniela.src.modules.dislike.domain.models;

namespace campuslove_angel_daniela.src.modules.dislike.application.services;
public class DislikeService
{
    private readonly IDislikeRepository _repository;

    public DislikeService(IDislikeRepository repository) =>_repository = repository;
    public async Task<Dislike> CrearDislikeAsync(Dislike dislike) => await _repository.CrearDislikeAsync(dislike);
    public async Task<Dislike?> ObtenerPorIdAsync(int id) => await _repository.ObtenerPorIdAsync(id);
    public async Task<IEnumerable<Dislike>> ObtenerTodosAsync() => await _repository.ObtenerTodosAsync();
    public async Task<IEnumerable<Dislike>> ObtenerPorEmisorAsync(int idEmisor) => await _repository.ObtenerPorEmisorAsync(idEmisor);
    public async Task<IEnumerable<Dislike>> ObtenerPorReceptorAsync(int idReceptor) => await _repository.ObtenerPorReceptorAsync(idReceptor);
    public async Task EliminarAsync(int id) =>await _repository.EliminarAsync(id);
}
