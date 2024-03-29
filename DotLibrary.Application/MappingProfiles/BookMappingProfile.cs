using AutoMapper;
using DotLibrary.Application.Features.Book.Commands.CreateBook;
using DotLibrary.Application.Features.Book.Queries.GetAllBooks;
using DotLibrary.Application.Features.Book.Queries.GetBookDetails;
using DotLibrary.Domain;

namespace DotLibrary.Application.MappingProfiles;

public class BookMappingProfile:Profile
{
    public BookMappingProfile()
    {
        // CreateMap<Domain.Book, BookDto>().ReverseMap();
        CreateMap<Domain.Book, CreateBookCommand>().ReverseMap();
        CreateMap<Book, BookDto>();
        
        CreateMap<Book, BookDetailsDto>()
            .ForMember(dest => dest.BookCategories, opt => opt.MapFrom(src => src.BookCategories.Select(bc => new BookCategoriesDto {  CategoryId = bc.CategoryId, CategoryName = bc.Category.Name})))
            .ForMember(dest => dest.BookAuthors, opt => opt.MapFrom(src => src.BookAuthors.Select(ba => new BookAuthorsDto {  AuthorId = ba.AuthorId, AuthorName = ba.Author.Name })));
        
    }
    
}