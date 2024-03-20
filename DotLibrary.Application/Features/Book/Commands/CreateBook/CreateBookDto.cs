namespace DotLibrary.Application.Features.Book.Commands.CreateBook;

public class CreateBookDto
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int PublisherId { get; set; }
}