using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;

namespace DotLibrary.Persistence.Repositories;

public class BookRepository: GenericRepository<Book>, IBookRepository
{
    public BookRepository(DotLibraryDbContext context) : base(context)
    {
    }
}