using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<List<Booknest>>> GetBooks();
    Task<ApiResponse<bool>> AddBook(Booknest booknest);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<bool>> UpdateBook(Booknest booknest);
    Task<ApiResponse<Booknest>> GetBook(int id);
}
