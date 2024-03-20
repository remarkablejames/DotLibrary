using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DotLibrary.Persistence.Repositories;

public class BookRepository: GenericRepository<Book>, IBookRepository
{
    private readonly DotLibraryDbContext _context;

    public BookRepository(DotLibraryDbContext context) : base(context)
    {
        _context = context;
    }
    
    // public new async Task<IReadOnlyList<Book>> GetAllAsync()
    // {
    //     var entities =  await _context.Set<Book>()
    // .Include(b => b.BookAuthors)
    // .Include(b => b.BookCategories)
    // .ToListAsync();
    //     return entities;
    // }
    
    public new async Task<Book?> GetByIdAsync(int id)
    {
        var entity = await _context.Set<Book>()
            .Include(b => b.BookAuthors)
            .Include(b => b.BookCategories)
            .FirstOrDefaultAsync(b => b.Id == id);
        return entity;
    }
}