using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using campuslove_angel_daniela.src.modules.like.application.interfaces;
using campuslove_angel_daniela.src.modules.like.domain.models;
using campuslove_angel_daniela.src.modules.like.infrastructure.repositories;
using campuslove_angel_daniela.src.modules.usuario.domain.models;

namespace campuslove_angel_daniela.src.modules.like.application.services;

public class LikeService
{
    private readonly LikeRepository _likeRepository;
    public LikeService(LikeRepository likeRepository) => _likeRepository = likeRepository;
    public async Task<Like?> GetByIdAsync(int id) => await _likeRepository.GetByIdAsync(id);
    public async Task<IEnumerable<Like>> GetAllAsync() => await _likeRepository.GetAllAsync();
    public async Task<Like> CrearLikeAsync(int emisorId, int receptorId) => await _likeRepository.RegistrarLikeAsync(emisorId, receptorId)
    // el ?? significa que en caso de error, se retorna null y se lanza una excepción
            ?? throw new Exception("Error al registrar el like.");
    public async Task EliminarLikeAsync(int id) => await _likeRepository.DeleteAsync(id);
    public async Task<IEnumerable<Like>> GetLikesDeUsuarioAsync(int usuarioId) => await _likeRepository.GetLikesDeUsuarioAsync(usuarioId);
    public async Task<IEnumerable<Like>> GetMatchesAsync(int usuarioId) => await _likeRepository.GetMatchesAsync(usuarioId);
    public async Task<Usuario?> GetUsuarioConMasLikesAsync() => await _likeRepository.GetUsuarioConMasLikesAsync();
}
