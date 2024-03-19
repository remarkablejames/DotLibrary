namespace DotLibrary.Domain;

public class Publisher
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<Book> PublishedBooks { get; set; }
}