using AutoMapper;
using DotLibrary.Application.Features.Author.Queries.GetAuthorDetails;
using DotLibrary.Domain;

namespace DotLibrary.Application.MappingProfiles;

public class AuthorMappingProfile: Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<Author, AuthorDetailsDto>().ReverseMap();
        // CreateMap<AuthorDto, Author>();
    }
}