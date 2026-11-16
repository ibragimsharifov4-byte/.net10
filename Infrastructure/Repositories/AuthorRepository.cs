using Domain.Models;
using Infrastructure.Data;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext appDbContext) : IAuthorRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddAuthor(Author author)
    {
        _context.Authors.Add(author);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        if(author != null)
        {
            _context.Authors.Remove(author);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task<Author> GetAuthor(int id)
    {
        var res = await _context.Authors.FirstOrDefaultAsync(x => x.Id == id);
        return res ?? new();
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        var auth = await _context.Authors.FirstOrDefaultAsync(x => x.Id == author.Id);
        if(auth !=null)
        {
            auth.Fullname = author.Fullname;
            auth.Country = author.Country;
            auth.Birthdate = author.Birthdate;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }
    
}