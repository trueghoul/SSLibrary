namespace SSLibrary.API.Entities;

public class Genre
{
    public int Id { get; set; }
    public string GenreName { get; set; }
    
    // Navigation properties
    public ICollection<BookGenre> BookGenres { get; set; }
}