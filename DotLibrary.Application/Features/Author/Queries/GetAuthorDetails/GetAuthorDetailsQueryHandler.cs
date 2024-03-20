using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Application.Exceptions;
using MediatR;

namespace DotLibrary.Application.Features.Author.Queries.GetAuthorDetails;

public class GetAuthorDetailsQueryHandler: IRequestHandler<GetAuthorDetailsQuery, AuthorDetailsDto>
{
    private readonly IAuthorRepository _repository;
    private readonly IMapper _mapper;

    public GetAuthorDetailsQueryHandler(IAuthorRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AuthorDetailsDto> Handle(GetAuthorDetailsQuery request, CancellationToken cancellationToken)
    {
        var author = await _repository.GetByIdAsync(request.Id);
        if (author is null)
        {
            throw new NotFoundException(nameof(Domain.Author), request.Id);
        }
        return  _mapper.Map<AuthorDetailsDto>(author);
    }
}