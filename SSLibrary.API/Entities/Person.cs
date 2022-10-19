namespace SSLibrary.API.Entities;

public class Person : Timestamps
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; } 
    
    // Navigation properties
    public ICollection<LibraryCard> LibraryCards { get; set; }
}