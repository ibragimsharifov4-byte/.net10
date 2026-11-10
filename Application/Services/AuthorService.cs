using System.Net;
using Application.Interfaces;
using Application.Responses;
using Application.DTOs.AuthorDtos;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private IAuthorRepository _repo = authorRepository;

    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto authorDto)
    {
        var author = new Author
        {
            Fullname = authorDto.Fullname,
            Country = authorDto.Country,
            Birthdate = authorDto.Birthdate
        };
        var res = await _repo.AddAuthor(author);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added!", false);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var res = await _repo.DeleteAuthor(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", false);
    }

    public async Task<ApiResponse<AuthorByIdDto?>> GetAuthor(int id)
    {
        var res = await _repo.GetAuthor(id);
        if (res == null)
            return new ApiResponse<AuthorByIdDto?>(HttpStatusCode.InternalServerError, "Not Found!", null);

        var authorDto = new AuthorByIdDto
        {
            Id = res.Id,
            Fullname = res.Fullname,
            Country = res.Country,
            Birthdate = res.Birthdate
        };
        return new ApiResponse<AuthorByIdDto?>(HttpStatusCode.OK, "Found!", authorDto);
    }

    public async Task<ApiResponse<List<AuthorDto>>> GetAuthors()
    {
        var res = await _repo.GetAuthors();
        var authorsDto = new List<AuthorDto>();
        foreach (var author in res)
        {
            var authorDto = new AuthorDto
            {
                Id = author.Id,
                Fullname = author.Fullname,
                Country = author.Country,
                Birthdate = author.Birthdate
            };
            authorsDto.Add(authorDto);
        }
        return new ApiResponse<List<AuthorDto>>(HttpStatusCode.OK, "List of Authors!", authorsDto);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(int id, UpdateAuthorDto authorDto)
    {
        var author = new Author
        {
            Id = id,
            Fullname = authorDto.Fullname,
            Country = authorDto.Country,
            Birthdate = authorDto.Birthdate
        };
        var res = await _repo.UpdateAuthor(author);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated!", false);
    }
}
