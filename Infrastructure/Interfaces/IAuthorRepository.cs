using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IAuthorRepository
{
    void AddAuthor(Author author);
    void DeleteAuthor(int id);
    List<Author> GetAuthors();
    void UpdateAuthor(Author author);
}