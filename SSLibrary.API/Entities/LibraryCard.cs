using System.ComponentModel.DataAnnotations;

namespace SSLibrary.API.Entities;

public class LibraryCard
{
    public Guid BookId { get; set; }
    public Book Book { get; set; }
    public Guid PersonId { get; set; }
    public Person Person { get; set; }
    [DisplayFormat(DataFormatString = "yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffzzz", ApplyFormatInEditMode = true)]
    public DateTimeOffset BorrowingTime { get; set; }
}