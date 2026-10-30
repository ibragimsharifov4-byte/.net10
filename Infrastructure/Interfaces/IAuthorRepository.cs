using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IAuthorRepository
{
    Task AddAuthor(Author author);
    Task DeleteAuthor(int id);
    Task<List<Author>> GetAuthors();
    Task UpdateAuthor(Author author);
}