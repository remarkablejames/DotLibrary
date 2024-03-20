using MediatR;

namespace DotLibrary.Application.Features.Book.Queries.GetBookDetails;

public record GetBookDetailsQuery(int Id): IRequest<BookDetailsDto>;