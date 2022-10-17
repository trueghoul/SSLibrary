using System.ComponentModel.DataAnnotations;

namespace SSLibrary.API.Entities;

public class LibraryCard
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    [DisplayFormat(DataFormatString = "MM/dd/yyyy HH:mm:ss", ApplyFormatInEditMode = true)]
    public DateTimeOffset BorrowingTime { get; set; }
}