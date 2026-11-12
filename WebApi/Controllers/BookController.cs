using Application.Responses;
using Application.Interfaces;
using Application.DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService apiBookService) : ControllerBase
{
    private readonly IBookService _service = apiBookService;

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        return await _service.GetBooks();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookByIdDto?>> GetBook(int id)
    {

        return await _service.GetBook(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        return await _service.AddBook(bookDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto bookDto)
    {
        return await _service.UpdateBook(id, bookDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await _service.DeleteBook(id);
    }
}
