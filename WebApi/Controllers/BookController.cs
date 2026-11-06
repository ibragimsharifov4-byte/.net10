using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService apiBookService) : ControllerBase
{
    private IBookService _bookService = apiBookService;

    [HttpGet]
    public async Task<ApiResponse<List<Booknest>>> GetBooks()
    {
        return await _bookService.GetBooks();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Booknest>> GetBook(int id)
    {
        return await _bookService.GetBook(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(Booknest booknest)
    {
        return await _bookService.AddBook(booknest);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(Booknest booknest)
    {
        return await _bookService.UpdateBook(booknest);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await _bookService.DeleteBook(id);
    }
}