namespace DotLibrary.Domain;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    // Other properties...

    public List<BookAuthor> AuthoredBooks { get; set; } = new List<BookAuthor>();
}