namespace DotLibrary.Domain;

public class Category
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<BookCategory> Books { get; set; }
}