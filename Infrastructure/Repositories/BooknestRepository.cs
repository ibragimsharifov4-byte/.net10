using System.Data;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Domain.Interfaces;
using Npgsql;
namespace Infrastructure.Repositories;

public class BooknestRepository(AppDbContext appDbContext) : IBooknestRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddBook(Booknest booknest)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "insert into booknest(title , create_year , price) values (@title , @create_year , @price)";
        var res = await con.ExecuteAsync(sql, new
        {
            title = booknest.Title,
            create_year = booknest.CreateYear,
            price = booknest.Price
        });
        return res>0;
    }

    public async Task<Booknest> GetBooknest(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select * from booknest where id = @id";
        var book = await con.QuerySingleOrDefaultAsync<Booknest>(sql , new{id});
        return book;
    }

    public async Task<bool> DeleteBook(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "delete from booknest";
        var res = await con.ExecuteAsync(sql , new{id});
        return res>0;
    }

    public async Task<List<Booknest>> GetBooknests()
    {
        using var con = _context.Connection();
        var sql = "select * from booknest";
        var books =  await con.QueryAsync<Booknest>(sql);
        return books.ToList();
    }
    public async Task<bool> UpdateBook(Booknest booknest)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "update booknest set title = @title , price = @price , @create_year = create_year where id = @id";
        var res = await con.ExecuteAsync(sql , new{booknest.Id , booknest.Title , booknest.CreateYear ,booknest.Price });
        return res>0;
    }
    public async Task GetBookAmount()
    {
        using var con = _context.Connection();
        con.Open();
        var query = "select count(*) from booknest";
        var books = await con.ExecuteScalarAsync<int>(query);
        Console.WriteLine($"Total books: {books}");
    }
    public async Task<int> GetMinPublishedYearByAuthor(int authorId)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select min(create_year) from booknest where author_id = @authorId";
        var minYear = await con.ExecuteScalarAsync<int>(sql, new { authorId });
        Console.WriteLine($"Minimum published year for author {authorId}: {minYear}");
        return minYear;
    }

    public async Task<int> GetMaxPublishedYearByAuthor(int authorId)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select max(create_year) from booknest where author_id = @authorId";
        var maxYear = await con.ExecuteScalarAsync<int>(sql, new { authorId });
        Console.WriteLine($"Maximum published year for author {authorId}: {maxYear}");
        return maxYear;
    }

    public async Task<int> GetMinPublishedYearByGenre(int genreId)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select min(create_year) from booknest where genre_id = @genreId";
        var minYear = await con.ExecuteScalarAsync<int>(sql, new { genreId });
        Console.WriteLine($"Minimum published year for genre {genreId}: {minYear}");
        return minYear;
    }

    public async Task<int> GetMaxPublishedYearByGenre(int genreId)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select max(create_year) from booknest where genre_id = @genreId";
        var maxYear = await con.ExecuteScalarAsync<int>(sql, new { genreId });
        Console.WriteLine($"Maximum published year for genre {genreId}: {maxYear}");
        return maxYear;
    }

    public async Task<int> GetAmountByPublishedYear(int year)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select count(*) from booknest where create_year = @year";
        var amount = await con.ExecuteScalarAsync<int>(sql, new { year });
        Console.WriteLine($"Amount of books published in {year}: {amount}");
        return amount;
    }
    
    public async Task<int> GetAmountByGenre(int genreId)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select count(*) from booknest where genre_id = @genreId";
        var amount = await con.ExecuteScalarAsync<int>(sql, new { genreId });
        Console.WriteLine($"Amount of books in genre {genreId}: {amount}");
        return amount;
    }
}
