using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IBooknestRepository
{
    void AddBook(Booknest booknest);
    List<Booknest> GetBooknests();
    void Update(Booknest booknest);
    void Delete(int id);
}
