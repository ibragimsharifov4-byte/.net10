using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<List<Genre>>> GetGenres();
    Task<ApiResponse<bool>> AddGenre(Genre genre);
    Task<ApiResponse<bool>> DeleteGenre(int id);
    Task<ApiResponse<Genre>> GetGenre(int id);
    Task<ApiResponse<bool>> UpdateGenre(Genre genre);
}
