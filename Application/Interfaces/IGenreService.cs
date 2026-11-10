using Application.Responses;
using Application.DTOs.GenreDtos;

namespace Application.Interfaces;

public interface IGenreService
{
    Task<ApiResponse<List<GenreDto>>> GetGenres();
    Task<ApiResponse<bool>> AddGenre(CreateGenreDto genreDto);
    Task<ApiResponse<bool>> DeleteGenre(int id);
    Task<ApiResponse<GenreByIdDto?>> GetGenre(int id);
    Task<ApiResponse<bool>> UpdateGenre(int id, UpdateGenreDto genreDto);
}
