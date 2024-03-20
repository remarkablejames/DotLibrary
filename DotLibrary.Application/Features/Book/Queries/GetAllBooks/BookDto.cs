namespace DotLibrary.Application.Features.Book.Queries.GetAllBooks;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string ISBN { get; set; } = String.Empty;
    // public List<BookCategoriesDto> BookCategories { get; set; } = new List<BookCategoriesDto>();
    // public List<BookAuthorsDto> BookAuthors { get; set; } = new List<BookAuthorsDto>();
    
}

// public class BookCategoriesDto
// {
//     public int BookId { get; set; }
//     public int CategoryId { get; set; }
// }
//
// public class BookAuthorsDto
// {
//     public int BookId { get; set; }
//     public int AuthorId { get; set; }
// }

