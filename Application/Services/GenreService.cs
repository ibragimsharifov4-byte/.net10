using System.Net;
using Application.Interfaces;
using Application.Responses;
using Application.DTOs.GenreDtos;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    private IGenreRepository _repository = genreRepository;

    public async Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto)
    {
        var genre = new Genre
        {
            Name = genreDto.Name
        };
        var result = await _repository.AddGenre(genre);
        return result
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", false);
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var res = await _repository.DeleteGenre(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", false);
    }

    public async Task<ApiResponse<GenreByIdDto?>> GetGenre(int id)
    {
        var res = await _repository.GetGenre(id);
        if (res == null)
            return new ApiResponse<GenreByIdDto?>(HttpStatusCode.InternalServerError, "Not Found!", null);

        var genreDto = new GenreByIdDto
        {
            Id = res.Id,
            Name = res.Name
        };
        return new ApiResponse<GenreByIdDto?>(HttpStatusCode.OK, "Found!", genreDto);
    }

    public async Task<ApiResponse<List<GenreDto>>> GetGenres()
    {
        var res = await _repository.GetGenres();
        var genresDto = new List<GenreDto>();
        foreach (var genre in res)
        {
            var genreDto = new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name
            };
            genresDto.Add(genreDto);
        }
        return new ApiResponse<List<GenreDto>>(HttpStatusCode.OK, "Found!", genresDto);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(int id, UpdateGenreDto genreDto)
    {
        var genre = new Genre
        {
            Id = id,
            Name = genreDto.Name
        };
        var res = await _repository.UpdateGenre(genre);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated!", false);
    }
}
