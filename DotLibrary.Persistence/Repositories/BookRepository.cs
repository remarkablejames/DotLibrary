using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;

namespace DotLibrary.Persistence.Repositories;

public class BookRepository: GenericRepository<Book>, IBookRepository
{
    
}