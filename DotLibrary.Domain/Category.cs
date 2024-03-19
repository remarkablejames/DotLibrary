namespace DotLibrary.Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = String.Empty;
    // Other properties...

    public List<BookCategory> Books { get; set; } = new List<BookCategory>();
}