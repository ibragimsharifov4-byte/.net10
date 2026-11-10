using Application.Responses;
using Application.Interfaces;
using Application.DTOs.GenreDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private IGenreService _genreService = genreService;

    [HttpGet]
    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        return await _genreService.GetGenres();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GenreByIdDto?>> GetGenre(int id)
    {
        return await _genreService.GetGenre(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        return await _genreService.AddGenre(genreDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateGenre(int id, UpdateGenreDto genreDto)
    {
        return await _genreService.UpdateGenre(id, genreDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        return await _genreService.DeleteGenre(id);
    }
}
