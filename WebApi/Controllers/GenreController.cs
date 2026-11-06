using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private IGenreService _genreService = genreService;

    [HttpGet]
    public async Task<ApiResponse<List<Genre>>> GetGenres()
    {
        return await _genreService.GetGenres();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Genre>> GetGenre(int id)
    {
        return await _genreService.GetGenre(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenre(Genre genre)
    {
        return await _genreService.AddGenre(genre);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenre(Genre genre)
    {
        return await _genreService.UpdateGenre(genre);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        return await _genreService.DeleteGenre(id);
    }
}
