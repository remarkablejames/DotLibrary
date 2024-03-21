namespace DotLibrary.Domain;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = String.Empty;
    public string ISBN { get; set; } = String.Empty;
    // Foreign Key property
    // Navigation property to represent the relationship
    public string Publisher { get; set; } = String.Empty;
    
    public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public List<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    
}