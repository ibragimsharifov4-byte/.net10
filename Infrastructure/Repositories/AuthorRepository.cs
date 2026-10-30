using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public async Task AddAuthor(Author author)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "insert into author (fullname, country, birthdate) values (@Fullname, @Country, @Birthdate)";
        await con.ExecuteAsync(sql, author);
    }

    public async Task DeleteAuthor(int id)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "delete from author where id = @id";
        await con.ExecuteAsync(sql, new { id });
    }

    public async Task<List<Author>> GetAuthors()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select * from author";
        var authors = (await con.QueryAsync<Author>(sql)).ToList();
        return authors;
    }

    public async Task UpdateAuthor(Author author)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "update author set fullname = @Fullname, country = @Country, birthdate = @Birthdate where id = @Id";
        await con.ExecuteAsync(sql, author);
    }
    public async Task<int> GetAuthorsAmount()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from author";
        var authorsAmount = await con.ExecuteScalarAsync<int>(sql);
        Console.WriteLine($"Authors amount: {authorsAmount}");
        return authorsAmount;
    }
    
}