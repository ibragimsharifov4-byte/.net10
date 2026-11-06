using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Domain.Interfaces;

using System.Net;


namespace Application.Services;

public class BookService(IBooknestRepository bookRepository) : IBookService
{
    private IBooknestRepository _repository = bookRepository;
    public async Task<ApiResponse<bool>> AddBook(Booknest booknest)
    {
        var res = await _repository.AddBook(booknest);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", false);
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var res = await _repository.DeleteBook(id);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", false);
    }

    public async Task<ApiResponse<Booknest>> GetBook(int id)
    {
        var res = await _repository.GetBooknest(id);
        return res != null
        ? new ApiResponse<Booknest>(HttpStatusCode.OK, "Found!", res)
        : new ApiResponse<Booknest>(HttpStatusCode.InternalServerError, "Not found.", null);
    }

    public async Task<ApiResponse<List<Booknest>>> GetBooks()
    {
        var res = await _repository.GetBooknests();
        return new ApiResponse<List<Booknest>>(HttpStatusCode.OK, "List of Bookne!", res);
    }

    public async Task<ApiResponse<bool>> UpdateBook(Booknest booknest)
    {
        var res = await _repository.UpdateBook(booknest);
        return res
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", true)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", false);
    }
}

