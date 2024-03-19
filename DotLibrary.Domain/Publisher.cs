namespace DotLibrary.Domain;

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    // Other properties...

    public List<Book> PublishedBooks { get; set; } = new List<Book>();
}