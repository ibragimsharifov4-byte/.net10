using Domain.Models;

namespace Domain.Interfaces;

public interface IBooknestRepository
{
    Task<bool> AddBook(Booknest booknest);
    Task<List<Booknest>> GetBooknests();
    Task<Booknest> GetBooknest(int id);
    Task<bool> UpdateBook(Booknest booknest);
    Task<bool> DeleteBook(int id);
}
