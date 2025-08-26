using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.like.domain.models;

namespace campuslove_angel_daniela.src.modules.like.application.interfaces;

public interface ILikeRepository
{
    Task AddAsync(Like like);
    Task UpdateAsync(Like like);
    Task DeleteAsync(int id);
    Task<Like?> GetByIdAsync(int id);
    Task<IEnumerable<Like>> GetAllAsync();
    // logica de la clase y sus consultas
    Task<Like?> RegistrarLikeAsync(int emisorId, int receptorId);
    Task<IEnumerable<Like>> GetLikesDeUsuarioAsync(int usuarioId);
    Task<IEnumerable<Like>> GetMatchesAsync(int usuarioId);
    Task<Like?> GetUsuarioConMasLikesAsync();
    Task<int> ContarLikesHoyAsync(int usuarioId);
}
