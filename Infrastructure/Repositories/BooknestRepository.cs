using System.Data;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Npgsql;
namespace Infrastructure.Repositories;

public class BooknestRepository : IBooknestRepository
{
    public void AddBook(Booknest booknest)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "insert into booknest(title , create_year , price) values (@title , @create_year , @price)";
        con.Execute(sql , new{booknest.Title , booknest.CreateYear , booknest.Price});
    }

    public void Delete(int id)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "delete from booknest";
        con.Execute(sql , new{id});
    }

    public List<Booknest> GetBooknests()
    {
        using var con = Database.Connection();
        var sql = "select * from booknest";
        var books =  con.Query<Booknest>(sql).ToList();
        return books;
    }
    public void Update(Booknest booknest)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "update booknest set title = @title , price = @price , @create_year = create_year where id = @id";
        con.Execute(sql , new{booknest.Id , booknest.Title , booknest.CreateYear ,booknest.Price });
    }
    public void GetBookAmount()
    {
        using var con = Database.Connection();
        con.Open();
        var query = "select count(*) from booknest";
        var books = con.ExecuteScalar<int>(query);
        Console.WriteLine($"Total books: {books}");
    }
    public void GetMinPublishedYearByAuthor(int authorId)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select min(create_year) from booknest where author_id = @authorId";
        var minYear = con.ExecuteScalar<int>(sql, new { authorId });
        Console.WriteLine($"Minimum published year for author {authorId}: {minYear}");
    }
    
    public void GetMaxPublishedYearByAuthor(int authorId)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select max(create_year) from booknest where author_id = @authorId";
        var maxYear = con.ExecuteScalar<int>(sql, new { authorId });
        Console.WriteLine($"Maximum published year for author {authorId}: {maxYear}");
    }

    public void GetMinPublishedYearByGenre(int genreId)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select min(create_year) from booknest where genre_id = @genreId";
        var minYear = con.ExecuteScalar<int>(sql, new { genreId });
        Console.WriteLine($"Minimum published year for genre {genreId}: {minYear}");
    }

    public void GetMaxPublishedYearByGenre(int genreId)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select max(create_year) from booknest where genre_id = @genreId";
        var maxYear = con.ExecuteScalar<int>(sql, new { genreId });
        Console.WriteLine($"Maximum published year for genre {genreId}: {maxYear}");
    }

    public void GetAmountByPublishedYear(int year)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from booknest where create_year = @year";
        var amount = con.ExecuteScalar<int>(sql, new { year });
        Console.WriteLine($"Amount of books published in {year}: {amount}");
    }
    
    public void GetAmountByGenre(int genreId)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from booknest where genre_id = @genreId";
        var amount = con.ExecuteScalar<int>(sql, new { genreId });
        Console.WriteLine($"Amount of books in genre {genreId}: {amount}");
    }
}
