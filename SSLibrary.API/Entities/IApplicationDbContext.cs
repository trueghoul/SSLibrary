using Microsoft.EntityFrameworkCore;

namespace SSLibrary.API.Entities;

public interface IApplicationDbContext
{
    DbSet<Author> Authors { get; set; }
    DbSet<Book> Books { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Person> Persons { get; set; }
    DbSet<BookGenre> BookGenres { get; set; }
    DbSet<LibraryCard> LibraryCards { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}