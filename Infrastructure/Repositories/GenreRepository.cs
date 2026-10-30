using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    public async Task AddGenre(Genre genre)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "insert into genres (name) values (@Name)";
        await con.ExecuteAsync(sql, genre);
    }

    public async Task DeleteGenre(int id)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "delete from genres where id = @id";
        await con.ExecuteAsync(sql, new { id });
    }

    public async Task<List<Genre>> GetGenres()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select * from genres";
        var genres = (await con.QueryAsync<Genre>(sql)).ToList();
        return genres;
    }

    public async Task UpdateGenre(Genre genre)
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "update genres set name = @Name where id = @Id";
        await con.ExecuteAsync(sql, genre);
    }
    public async Task<int> GetGenresAmount()
    {
        using var con = Database.Connection();
        con.Open();
        var sql = "select count(*) from genres";
        var genresAmount = await con.ExecuteScalarAsync<int>(sql);
        Console.WriteLine($"Genres amount: {genresAmount}");
        return genresAmount;
    }
}