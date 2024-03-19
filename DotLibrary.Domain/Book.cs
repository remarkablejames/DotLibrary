namespace DotLibrary.Domain;

public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    // Foreign Key property
    public int PublisherID { get; set; }
    
    // Navigation property to represent the relationship
    public Publisher Publisher { get; set; }
    
    public List<BookAuthor> BookAuthors { get; set; }
    public List<BookCategory> BookCategories { get; set; }
    
}