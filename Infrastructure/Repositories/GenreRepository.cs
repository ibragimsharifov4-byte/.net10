using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddGenre(Genre genre)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "insert into genres (name) values (@Name)";
        var res = await con.ExecuteAsync(sql, genre);
        return res > 0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "delete from genres where id = @id";
        var res = await con.ExecuteAsync(sql, new { id });
        return res > 0;
    }

    public async Task<List<Genre>> GetGenres()
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select * from genres";
        var genres = (await con.QueryAsync<Genre>(sql)).ToList();
        return genres;
    }

    public async Task<Genre> GetGenre(int id)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select * from genres where id = @id";
        var genre = await con.QuerySingleOrDefaultAsync<Genre>(sql, new { id });
        return genre;
    }

    public async Task<bool> UpdateGenre(Genre genre)
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "update genres set name = @Name where id = @Id";
        var res = await con.ExecuteAsync(sql, genre);
        return res > 0;
    }
    public async Task<int> GetGenresAmount()
    {
        using var con = _context.Connection();
        con.Open();
        var sql = "select count(*) from genres";
        var genresAmount = await con.ExecuteScalarAsync<int>(sql);
        Console.WriteLine($"Genres amount: {genresAmount}");
        return genresAmount;
    }
}