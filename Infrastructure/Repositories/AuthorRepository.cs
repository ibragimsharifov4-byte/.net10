using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext appDbContext) : IAuthorRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddAuthor(Author author)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "insert into author (fullname, country, birthdate) values (@Fullname, @Country, @Birthdate)";
        var res = await con.ExecuteAsync(sql, author);
        return res>0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "delete from author where id = @id";
        var res = await con.ExecuteAsync(sql, new { id });
        return res>0;
    }

    public async Task<List<Author>> GetAuthors()
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select * from author";
        var authors = (await con.QueryAsync<Author>(sql)).ToList();
        return authors;
    }

    public async Task<Author> GetAuthor(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select * from author where id = @id";
        var res = await con.QuerySingleOrDefaultAsync<Author>(sql , new{id});
        return res;
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "update author set fullname = @Fullname, country = @Country, birthdate = @Birthdate where id = @Id";
        var res = await con.ExecuteAsync(sql, author);
        return res>0;
    }
    public async Task<int> GetAuthorsAmount()
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select count(*) from author";
        var authorsAmount = await con.ExecuteScalarAsync<int>(sql);
        Console.WriteLine($"Authors amount: {authorsAmount}");
        return authorsAmount;
    }
    
}