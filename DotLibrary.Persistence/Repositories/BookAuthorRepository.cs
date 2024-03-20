using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;

namespace DotLibrary.Persistence.Repositories;

public class BookAuthorRepository:GenericRepository<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(DotLibraryDbContext context) : base(context)
    {
    }
}