using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BooknestRepository(AppDbContext appDbContext) : IBooknestRepository
{
    private AppDbContext _context = appDbContext;

    public async Task<bool> AddBook(Booknest booknest)
    {
        _context.Booknests.Add(booknest);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Booknest> GetBooknest(int id)
    {
        var res = await _context.Booknests.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _context.Booknests.FirstOrDefaultAsync(x => x.Id == id);
        if (book == null)
            return false;

        _context.Booknests.Remove(book);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Booknest>> GetBooknests()
    {
        return await _context.Booknests.ToListAsync();
    }

    public async Task<bool> UpdateBook(Booknest booknest)
    {
        var book = await _context.Booknests.FirstOrDefaultAsync(x => x.Id == booknest.Id);
        if (book == null)
            return false;

        book.Title = booknest.Title;
        book.CreateYear = booknest.CreateYear;
        book.Price = booknest.Price;
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
}
