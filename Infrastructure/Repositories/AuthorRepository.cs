using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public void AddAuthor(Author author)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "insert into author (fullname, country, birthdate) values (@Fullname, @Country, @Birthdate)";
        con.Execute(sql, author);
    }

    public void DeleteAuthor(int id)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "delete from author where id = @id";
        con.Execute(sql, new { id });
    }

    public List<Author> GetAuthors()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select * from author";
        var authors = con.Query<Author>(sql).ToList();
        return authors;
    }

    public void UpdateAuthor(Author author)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "update author set fullname = @Fullname, country = @Country, birthdate = @Birthdate where id = @Id";
        con.Execute(sql, author);
    }
    public void GetAuthorsAmount()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from author";
        var authorsAmount = con.ExecuteScalar<int>(sql);
        Console.WriteLine($"Authors amount: {authorsAmount}");
    }
    
}