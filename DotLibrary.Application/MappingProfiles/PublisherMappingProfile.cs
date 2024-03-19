using AutoMapper;
using DotLibrary.Application.Features.Publisher.Queries.GetPublisherDetails;

namespace DotLibrary.Application.MappingProfiles;

public class PublisherMappingProfile:Profile
{
    public PublisherMappingProfile()
    {
        CreateMap<Domain.Publisher, PublisherDetailsDto>().ReverseMap();
    }
    
}