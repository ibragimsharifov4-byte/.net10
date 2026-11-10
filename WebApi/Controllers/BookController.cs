using Application.Responses;
using Application.Interfaces;
using Application.DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService apiBookService) : ControllerBase
{
    private IBookService _bookService = apiBookService;

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        return await _bookService.GetBooks();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookByIdDto?>> GetBook(int id)
    {
        return await _bookService.GetBook(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        return await _bookService.AddBook(bookDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto bookDto)
    {
        return await _bookService.UpdateBook(id, bookDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await _bookService.DeleteBook(id);
    }
}
