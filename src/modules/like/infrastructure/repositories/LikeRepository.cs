
using campuslove_angel_daniela.src.modules.like.domain.models;
using campuslove_angel_daniela.src.modules.usuario.domain.models;
using campuslove_angel_daniela.src.shared.context;
using Microsoft.EntityFrameworkCore;

namespace campuslove_angel_daniela.src.modules.like.infrastructure.repositories;

public class LikeRepository
{
    private readonly AppDbContext _context;

    public LikeRepository(AppDbContext context) => _context = context;

    public async Task<Like?> GetByIdAsync(int id) => await _context.Likes.FindAsync(id);

    public async Task<IEnumerable<Like>> GetAllAsync() => await _context.Likes.Include(l => l.Emisor).Include(l => l.Receptor).ToListAsync();

    public async Task AddAsync(Like like)
    {
        await _context.Likes.AddAsync(like);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Like like)
    {
        _context.Likes.Update(like);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var like = await _context.Likes.FindAsync(id);
        if (like != null)
        {
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Like?> RegistrarLikeAsync(int emisorId, int receptorId)
    {
        // Verificar si el receptor ya dio like al emisor (posible match)
        var likeReceptor = await _context.Likes
            .FirstOrDefaultAsync(l => l.IdEmisor == receptorId && l.IdReceptor == emisorId);

        var nuevoLike = new Like
        {
            IdEmisor = emisorId,
            IdReceptor = receptorId,
            // si el receptor ya dio like al emisor, el match es true
            EsMatch = likeReceptor != null
        };

        await _context.Likes.AddAsync(nuevoLike);
        await _context.SaveChangesAsync();

        if (likeReceptor != null)
        {
            likeReceptor.EsMatch = true;
            await _context.SaveChangesAsync();
        }
        return nuevoLike;
    }

    public async Task<IEnumerable<Like>> GetLikesDeUsuarioAsync(int usuarioId) =>
        await _context.Likes
            .Include(l => l.Emisor)
            .Include(l => l.Receptor)
            .Where(l => l.IdEmisor == usuarioId || l.IdReceptor == usuarioId)
            .ToListAsync();

    public async Task<IEnumerable<Like>> GetMatchesAsync(int usuarioId) =>
        await _context.Likes
            .Include(l => l.Emisor)
            .Include(l => l.Receptor)
            .Where(l => (l.IdEmisor == usuarioId || l.IdReceptor == usuarioId) && l.EsMatch)
            .ToListAsync();
    public async Task<Usuario?> GetUsuarioConMasLikesAsync()
    {
        var usuario = await _context.Likes
            .Where(l => l.EsMatch == true)
            .GroupBy(l => l.Receptor)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefaultAsync();
        return usuario;
    }
    public async Task<int> ContarLikesAsync(int usuarioId, DateTime fecha)
    {
        return await _context.Likes
            .Where(l => l.IdEmisor == usuarioId && l.EsMatch && l.Fecha.Date == fecha)
            .CountAsync();
    }
}
