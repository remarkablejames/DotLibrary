using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Application.Exceptions;
using MediatR;

namespace DotLibrary.Application.Features.Publisher.Queries.GetPublisherDetails;

public class GetPublisherDetailsQueryHandler: IRequestHandler<GetPublisherDetailsQuery, PublisherDetailsDto>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetPublisherDetailsQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }
    public async Task<PublisherDetailsDto> Handle(GetPublisherDetailsQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByIdAsync(request.Id);
        if (publisher is null)
        {

            throw new NotFoundException(nameof(Domain.Publisher), request.Id);
        }
        
        return _mapper.Map<PublisherDetailsDto>(publisher);
    }
}