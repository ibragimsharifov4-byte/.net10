using System.Net;
using Application.Interfaces;
using Application.Responses;
using Application.DTOs.BookDtos;
using Domain.Models;
using Domain.Interfaces;

namespace Application.Services;

public class BookService(IBooknestRepository bookRepository) : IBookService
{
    private IBooknestRepository _repository = bookRepository;

    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        var booknest = new Booknest
        {
            Title = bookDto.Title,
            CreateYear = bookDto.CreateYear,
            Price = bookDto.Price
        };
        var res = await _repository.AddBook(booknest);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var res = await _repository.DeleteBook(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", false);
    }

    public async Task<ApiResponse<BookByIdDto?>> GetBook(int id)
    {
        var res = await _repository.GetBooknest(id);
        if (res == null)
            return new ApiResponse<BookByIdDto?>(HttpStatusCode.InternalServerError, "Not found.", null);

        var bookDto = new BookByIdDto
        {
            Id = res.Id,
            Title = res.Title,
            CreateYear = res.CreateYear,
            Price = res.Price
        };
        return new ApiResponse<BookByIdDto?>(HttpStatusCode.OK, "Found!", bookDto);
    }

    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        var res = await _repository.GetBooknests();
        var booksDto = new List<BookDto>();
        foreach (var book in res)
        {
            var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                CreateYear = book.CreateYear,
                Price = book.Price
            };
            booksDto.Add(bookDto);
        }
        return new ApiResponse<List<BookDto>>(HttpStatusCode.OK, "List of Bookne!", booksDto);
    }

    public async Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto bookDto)
    {
        var booknest = new Booknest
        {
            Id = id,
            Title = bookDto.Title,
            CreateYear = bookDto.CreateYear,
            Price = bookDto.Price
        };
        var res = await _repository.UpdateBook(booknest);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", false);
    }
}
