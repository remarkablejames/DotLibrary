namespace DotLibrary.Domain;

public class Author
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<BookAuthor> AuthoredBooks { get; set; }
}