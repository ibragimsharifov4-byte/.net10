using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IGenreRepository
{
    void AddGenre(Genre genre);
    void DeleteGenre(int id);
    List<Genre> GetGenres();
    void UpdateGenre(Genre genre);
}