using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using DotLibrary.Persistence.Context;

namespace DotLibrary.Persistence.Repositories;

public class PublisherRepository: GenericRepository<Publisher>, IPublisherRepository
{
    public PublisherRepository(DotLibraryDbContext context) : base(context)
    {
    }
}