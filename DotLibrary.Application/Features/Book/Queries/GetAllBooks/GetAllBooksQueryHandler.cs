using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using MediatR;

namespace DotLibrary.Application.Features.Book.Queries.GetAllBooks;

public class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetAllBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
    {
        var allBooks = await _bookRepository.GetAllAsync();
        return _mapper.Map<List<BookDto>>(allBooks);
    }
}