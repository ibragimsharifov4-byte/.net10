using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepository
{
    Task<bool> AddGenre(Genre genre);
    Task<bool> DeleteGenre(int id);
    Task<Genre> GetGenre(int id);
    Task<List<Genre>> GetGenres();
    Task<bool> UpdateGenre(Genre genre);
}