using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;

namespace DotLibrary.Persistence.Repositories;

public class AuthorRepository: GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(DotLibraryDbContext context) : base(context)
    {
    }
}