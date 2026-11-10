using Application.Responses;
using Application.Interfaces;
using Application.DTOs.AuthorDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService _authorService = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        return await _authorService.GetAuthors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorByIdDto?>> GetAuthor(int id)
    {
        return await _authorService.GetAuthor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        return await _authorService.AddAuthor(authorDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto authorDto)
    {
        return await _authorService.UpdateAuthor(id, authorDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await _authorService.DeleteAuthor(id);
    }
}
