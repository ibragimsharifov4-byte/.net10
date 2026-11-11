using Application.Responses;
using Application.Interfaces;
using Application.DTOs.GenreDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService, ILogger<GenreController> logger) : ControllerBase
{
    private readonly IGenreService _service = genreService;
    private readonly ILogger<GenreController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        _logger.LogInformation("Geting the genres");
        return await _service.GetGenres();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GenreByIdDto?>> GetGenre(int id)
    {
        _logger.LogInformation("Get genre by id");
        return await _service.GetGenre(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        _logger.LogInformation("Adding the genre");
        return await _service.AddGenre(genreDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGenre(int id, UpdateGenreDto genreDto)
    {
        _logger.LogInformation("Update the genre");
        return await _service.UpdateGenre(id, genreDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        _logger.LogInformation("Delete the genre");
        return await _service.DeleteGenre(id);
    }
}
