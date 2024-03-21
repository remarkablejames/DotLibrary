using AutoMapper;
using DotLibrary.Application.Contracts.Persistence;
using DotLibrary.Domain;
using MediatR;
using Newtonsoft.Json;
using Exception = System.Exception;

namespace DotLibrary.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly IBookCategoryRepository _bookCategoryRepository;
    private readonly IBookAuthorRepository _bookAuthorRepository;

    public CreateBookCommandHandler(IBookRepository bookRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository, IMapper mapper,IBookCategoryRepository bookCategoryRepository,IBookAuthorRepository bookAuthorRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _bookCategoryRepository = bookCategoryRepository;
        _bookAuthorRepository = bookAuthorRepository;
    }
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        // 1. Validate the request
        // 2. Map the request to the entity using auto mapper
        var book = _mapper.Map<Domain.Book>(request);

        // Save the book to the database before adding authors and categories
        book = await _bookRepository.AddAsync(book);

        // 3. add author, category, publisher
        foreach (var authorId in request.AuthorIds)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            if (author is null)
            {
                Console.WriteLine(">>>>>>> Author not found");
                throw new Exception("Author not found");
            }
            
            Console.ForegroundColor = ConsoleColor.Green; // Set the text color to green
            Console.WriteLine(">>>>>>> Author: " + JsonConvert.SerializeObject(author));
            Console.ResetColor(); // Reset the color to the default

            book.BookAuthors.Add(new BookAuthor { AuthorId = author.Id, Author = author});
            // book.BookAuthors = [new BookAuthor { AuthorId = author.Id, Author = author}];
        }

        foreach (var categoryId in request.CategoryIds)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category is null)
            {
                Console.WriteLine(">>>>>>> Category not found");
                throw new Exception("Category not found");
            }
            
            book.BookCategories.Add(new BookCategory { CategoryId = category.Id, Category = category});
        }

        Console.ForegroundColor = ConsoleColor.Green; // Set the text color to green
        // Console.WriteLine(">>>>>>> Book: " + JsonConvert.SerializeObject(book));
        Console.ResetColor(); // Reset the color to the default

        // Update the book in the repository with the added authors and categories
         await _bookRepository.UpdateAsync(book);
        return book.Id;
    }
}