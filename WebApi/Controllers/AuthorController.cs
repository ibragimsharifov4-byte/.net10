using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService _authorService = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        return await _authorService.GetAuthors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        return await _authorService.GetAuthor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        return await _authorService.AddAuthor(author);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        return await _authorService.UpdateAuthor(author);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await _authorService.DeleteAuthor(id);
    }
}
