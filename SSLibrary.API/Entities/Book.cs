namespace SSLibrary.API.Entities;

public class Book : Timestamps
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly PublicationDate { get; set; }
    
    // Foreign Keys
    public Guid AuthorId { get; set; }
    // Navigation properties
    public Author Author { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<LibraryCard> LibraryCards { get; set; }
}