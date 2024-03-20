using MediatR;

namespace DotLibrary.Application.Features.Author.Queries.GetAuthorDetails;

public record GetAuthorDetailsQuery(int Id): IRequest<AuthorDetailsDto>;