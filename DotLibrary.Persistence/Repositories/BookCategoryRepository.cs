using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;

namespace DotLibrary.Persistence.Repositories;

public class BookCategoryRepository:GenericRepository<BookCategory>, IBookCategoryRepository
{
    public BookCategoryRepository(DotLibraryDbContext context) : base(context)
    {
    }
}