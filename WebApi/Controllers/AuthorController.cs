using Application.Responses;
using Application.Interfaces;
using Application.DTOs.AuthorDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService) : ControllerBase
{
    private readonly IAuthorService _service = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        return await _service.GetAuthors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorByIdDto?>> GetAuthor(int id)
    {
        return await _service.GetAuthor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        return await _service.AddAuthor(authorDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto authorDto)
    {
        return await _service.UpdateAuthor(id, authorDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await _service.DeleteAuthor(id);
    }
}
