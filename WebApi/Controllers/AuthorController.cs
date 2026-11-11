using Application.Responses;
using Application.Interfaces;
using Application.DTOs.AuthorDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService, ILogger<AuthorController> logger) : ControllerBase
{
    private readonly IAuthorService _service = authorService;
    private readonly ILogger<AuthorController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        _logger.LogInformation("Geting the authors");
        return await _service.GetAuthors();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<AuthorByIdDto?>> GetAuthor(int id)
    {
        _logger.LogInformation("Get author by id");
        return await _service.GetAuthor(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        _logger.LogInformation("Adding the author");
        return await _service.AddAuthor(authorDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto authorDto)
    {
        _logger.LogInformation("Update the author");
        return await _service.UpdateAuthor(id, authorDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        _logger.LogInformation("Delete the author");
        return await _service.DeleteAuthor(id);
    }
}
