using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    private IGenreRepository _repository = genreRepository;
    public async Task<ApiResponse<bool>> AddGenre(Genre genre)
    {
        var result = await _repository.AddGenre(genre);
        return result
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added!" , false);
    }

    public async Task<ApiResponse<bool>> DeleteGenre(int id)
    {
        var res = await _repository.DeleteGenre(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Deleted!" ,false);
    }

    public async Task<ApiResponse<Genre>> GetGenre(int id)
    {
        var res = await _repository.GetGenre(id);
        return res != null
        ? new ApiResponse<Genre>(HttpStatusCode.OK , "Found!" , res)
        : new ApiResponse<Genre>(HttpStatusCode.InternalServerError , "Not Found!" , null);
    }

    public async Task<ApiResponse<List<Genre>>> GetGenres()
    {
        var res = await _repository.GetGenres();
        return new ApiResponse<List<Genre>>(HttpStatusCode.OK , "Found!" , res);
    }

    public async Task<ApiResponse<bool>> UpdateGenre(Genre genre)
    {
        var res = await _repository.UpdateGenre(genre);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Updated!" , false);
    }

}
