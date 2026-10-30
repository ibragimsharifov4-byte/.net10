using Domain.Models;

namespace Infrastructure.Interfaces;

public interface IBooknestRepository
{
    Task AddBook(Booknest booknest);
    Task<List<Booknest>> GetBooknests();
    Task Update(Booknest booknest);
    Task Delete(int id);
}
