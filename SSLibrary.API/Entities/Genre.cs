namespace SSLibrary.API.Entities;

public class Genre : Timestamps
{
    public Guid Id { get; set; }
    public string GenreName { get; set; }
    
    // Navigation properties
    public ICollection<BookGenre> BookGenres { get; set; }
}