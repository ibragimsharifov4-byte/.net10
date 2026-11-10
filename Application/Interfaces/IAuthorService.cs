using Application.Responses;
using Application.DTOs.AuthorDtos;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<List<AuthorDto>>> GetAuthors();
    Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto);
    Task<ApiResponse<bool>> DeleteAuthor(int id);
    Task<ApiResponse<AuthorByIdDto?>> GetAuthor(int id);
    Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto authorDto);
}
