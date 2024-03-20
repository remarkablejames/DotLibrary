using MediatR;

namespace DotLibrary.Application.Features.Book.Commands.CreateBook;

public class CreateBookCommand: IRequest<int>
{
    public string Title { get; set; }
    public string ISBN { get; set; }
    public int PublisherId { get; set; }
    public List<int> AuthorIds { get; set; }
    public List<int> CategoryIds { get; set; }
}