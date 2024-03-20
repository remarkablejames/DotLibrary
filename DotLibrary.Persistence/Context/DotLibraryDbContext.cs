using DotLibrary.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotLibrary.Persistence.Context;

public class DotLibraryDbContext: DbContext
{
    public DotLibraryDbContext(DbContextOptions<DotLibraryDbContext> options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<BookCategory> BookCategories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>().HasKey(ba => new { ba.BookId, ba.AuthorId });
        modelBuilder.Entity<BookCategory>().HasKey(bg => new { bg.BookId, bg.CategoryId });
        
        // Configure relationships
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.PublishedBooks)
            .HasForeignKey(b => b.PublisherId)
            .IsRequired();

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.AuthoredBooks)
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<BookCategory>()
            .HasOne(bc => bc.Book)
            .WithMany(b => b.BookCategories)
            .HasForeignKey(bc => bc.BookId);

        modelBuilder.Entity<BookCategory>()
            .HasOne(bc => bc.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(bc => bc.CategoryId);
        
        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.PublishedBooks)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId);

        // Optionally, configure cascade delete behavior
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Publisher)
            .WithMany(p => p.PublishedBooks)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
}