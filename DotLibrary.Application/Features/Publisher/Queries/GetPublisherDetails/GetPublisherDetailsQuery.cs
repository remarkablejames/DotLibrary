using MediatR;

namespace DotLibrary.Application.Features.Publisher.Queries.GetPublisherDetails;

public record GetPublisherDetailsQuery(int Id) : IRequest<PublisherDetailsDto>;
