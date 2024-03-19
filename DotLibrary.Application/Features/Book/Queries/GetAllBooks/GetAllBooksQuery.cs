using MediatR;

namespace DotLibrary.Application.Features.Book.Queries.GetAllBooks;

public record GetAllBooksQuery: IRequest<List<BookDto>>;