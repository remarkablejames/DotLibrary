using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Application.Exceptions;
using MediatR;

namespace DotLibrary.Application.Features.Book.Queries.GetBookDetails;

public class GetBookDetailsQueryHandler: IRequestHandler<GetBookDetailsQuery, BookDetailsDto>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookDetailsQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    public async Task<BookDetailsDto> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);
        
        // if the book is not found, throw a NotFoundException
        if (book is null)
        {
            throw new NotFoundException(nameof(Domain.Book), request.Id);
        }
        return _mapper.Map<BookDetailsDto>(book);
    }
}