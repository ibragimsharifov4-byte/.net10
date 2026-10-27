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
}
