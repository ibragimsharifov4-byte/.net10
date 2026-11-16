using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddGenre(Genre genre)
    {
        _context.Genres.Add(genre);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        if (genre == null)
            return false;

        _context.Genres.Remove(genre);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Genre>> GetGenres()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<Genre> GetGenre(int id)
    {
        var res = await _context.Genres.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<bool> UpdateGenre(Genre genre)
    {
        var gen = await _context.Genres.FirstOrDefaultAsync(x => x.Id == genre.Id);
        if (gen == null)
            return false;

        gen.Name = genre.Name;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
