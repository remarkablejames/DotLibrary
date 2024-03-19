using AutoMapper;
using DotLibrary.Application.Features.Book.Queries.GetAllBooks;

namespace DotLibrary.Application.MappingProfiles;

public class BookMappingProfile:Profile
{
    public BookMappingProfile()
    {
        CreateMap<Domain.Book, BookDto>().ReverseMap();
    }
    
}