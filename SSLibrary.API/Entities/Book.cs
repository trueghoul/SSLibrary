namespace SSLibrary.API.Entities;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly PublicationDate { get; set; }
    
    // Foreign Keys
    public int AuthorId { get; set; }
    // Navigation properties
    public Author Author { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
    public ICollection<LibraryCard> LibraryCards { get; set; }
}