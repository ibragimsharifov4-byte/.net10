using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IGenreRepository
{
    Task AddGenre(Genre genre);
    Task DeleteGenre(int id);
    Task<List<Genre>> GetGenres();
    Task UpdateGenre(Genre genre);
}