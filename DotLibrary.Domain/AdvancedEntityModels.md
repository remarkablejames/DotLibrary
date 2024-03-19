
# Here are advanced model classes of each entity. 
some of the added fields may prove to be useful in the future

```csharp
public class Book
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public List<BookAuthor> BookAuthors { get; set; }
    public List<BookCategory> BookCategories { get; set; }
    
}

public class Author
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<BookAuthor> AuthoredBooks { get; set; }
}

public class Publisher
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<Book> PublishedBooks { get; set; }
}

public class Category
{
    public int ID { get; set; }
    public string Name { get; set; }
    // Other properties...

    public List<BookCategory> Books { get; set; }
}

public class BookAuthor
{
    public int BookID { get; set; }
    public Book Book { get; set; }

    public int AuthorID { get; set; }
    public Author Author { get; set; }
}

public class BookCategory
{
    public int BookID { get; set; }
    public Book Book { get; set; }

    public int CategoryID { get; set; }
    public Category Category { get; set; }
}
```