using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private IAuthorRepository _repo = authorRepository;
    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        var res = await _repo.AddAuthor(author);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Added!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Added!" , false);
    }

    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        var res = await _repo.DeleteAuthor(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Deleted!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Deleted!" , false);
    }

    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        var res = await _repo.GetAuthor(id);
        return res != null
        ? new ApiResponse<Author>(HttpStatusCode.OK , "Found!" , res)
        : new ApiResponse<Author>(HttpStatusCode.InternalServerError , "Not Found!" , null);
    }

    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        var res = await _repo.GetAuthors();
        return new ApiResponse<List<Author>>(HttpStatusCode.OK , "List of Authors!" , res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        var res = await _repo.UpdateAuthor(author);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK , "Updated!" , true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError , "Not Updated!" , false);
    }

}
