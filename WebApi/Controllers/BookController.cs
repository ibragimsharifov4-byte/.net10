using Application.Responses;
using Application.Interfaces;
using Application.DTOs.BookDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService apiBookService, ILogger<BookController> logger) : ControllerBase
{
    private readonly IBookService _service = apiBookService;
    private readonly ILogger<BookController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<BookDto>>> GetBooks()
    {
        _logger.LogInformation("Geting the books");
        return await _service.GetBooks();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<BookByIdDto?>> GetBook(int id)
    {
        _logger.LogInformation("Get book by id");
        return await _service.GetBook(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto bookDto)
    {
        _logger.LogInformation("Adding the book");
        return await _service.AddBook(bookDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateBook(int id, UpdateBookDto bookDto)
    {
        _logger.LogInformation("Update the book");
        return await _service.UpdateBook(id, bookDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        _logger.LogInformation("Delete the book");
        return await _service.DeleteBook(id);
    }
}
