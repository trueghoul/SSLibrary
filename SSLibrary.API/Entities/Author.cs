namespace SSLibrary.API.Entities;

public class Author : Timestamps
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    
    // Navigation properties
    public ICollection<Book> Books { get; set; }
}