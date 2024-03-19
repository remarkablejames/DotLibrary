namespace DotLibrary.Application.Features.Book.Queries.GetAllBooks;

public class BookDto
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string ISBN { get; set; } = String.Empty;
}