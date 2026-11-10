using Application.Responses;
using Application.DTOs.BookDtos;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<List<BookDto>>> GetBooks();
    Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto bookDto);
    Task<ApiResponse<BookByIdDto?>> GetBook(int id);
}
