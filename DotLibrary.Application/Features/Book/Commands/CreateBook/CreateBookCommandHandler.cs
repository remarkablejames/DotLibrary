using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using MediatR;
using Exception = System.Exception;

namespace DotLibrary.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        // 1. Validate the request
        // 2. Map the request to the entity using auto mapper
        var book = _mapper.Map<Domain.Book>(request);
        // 3. add author, category, publisher
        foreach (var authorId in request.AuthorIds)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            if (author is null)
            {
                Console.WriteLine(">>>>>>> Author not found");
                throw new Exception("Author not found");
            }
            book.BookAuthors.Add(new BookAuthor { AuthorId = author.Id, BookId = book.Id });
        }

        foreach (var categoryId in request.CategoryIds)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category is null)
            {
                Console.WriteLine(">>>>>>> Category not found");
                throw new Exception("Category not found");
            }
            book.BookCategories.Add(new BookCategory { CategoryId = category.Id, BookId = book.Id });
        }

        // 4. Add the book to the repository
        book = await _bookRepository.AddAsync(book);
        return book.Id;
    }
}