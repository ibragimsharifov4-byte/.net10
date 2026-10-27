using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    public void AddGenre(Genre genre)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "insert into genres (name) values (@Name)";
        con.Execute(sql, genre);
    }

    public void DeleteGenre(int id)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "delete from genres where id = @id";
        con.Execute(sql, new { id });
    }

    public List<Genre> GetGenres()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select * from genres";
        var genres = con.Query<Genre>(sql).ToList();
        return genres;
    }

    public void UpdateGenre(Genre genre)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "update genres set name = @Name where id = @Id";
        con.Execute(sql, genre);
    }
    public void GetGenresAmount()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from genres";
        var genresAmount = con.ExecuteScalar<int>(sql);
        Console.WriteLine($"Genres amount: {genresAmount}");
    }
}