using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.interes.application.interfaces;
using campuslove_angel_daniela.src.modules.interes.domain.models;
using campuslove_angel_daniela.src.modules.interes.infrastructure.repositories;

namespace campuslove_angel_daniela.src.modules.interes.application.services;
public class InteresService : IInteresService
{
    private readonly IInteresRepository _repository;
    public InteresService(IInteresRepository repository) => _repository = repository;
    public async Task<List<Interes>> ListarInteresesAsync() => await _repository.GetAllAsync();
    public async Task<Interes?> BuscarInteresAsync(int id) => await _repository.GetByIdAsync(id);
    public async Task CrearInteresAsync(string nombre, string descripcion)
    {
        var interes = new Interes(nombre, descripcion);
        await _repository.AddAsync(interes);
    }

    public async Task ActualizarInteresAsync(int id, string nombre, string descripcion)
    {
        var interes = await _repository.GetByIdAsync(id);
        if (interes != null)
        {
            interes.Nombre = nombre;
            interes.Descripcion = descripcion;
            await _repository.UpdateAsync(interes);
        }
    }

    public async Task EliminarInteresAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}