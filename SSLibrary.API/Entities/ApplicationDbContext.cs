using Microsoft.EntityFrameworkCore;

namespace SSLibrary.API.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :base(options)
    {
        
    }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<LibraryCard> LibraryCards { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("author");
            entity.HasKey(a => a.Id);
            entity.Property(a => a.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(a => a.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
            entity.Property(a => a.LastName)
                .IsRequired()
                .HasColumnName("last_name");
            entity.Property(a => a.MiddleName)
                .HasColumnName("middle_name");
            entity.Property(a => a.CreationDate)
                .HasColumnName("creation_date");
            entity.Property(a => a.EditDate)
                .HasColumnName("edit_date");
        });
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("book");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(b => b.Name)
                .IsRequired()
                .HasColumnName("book");
            entity.Property(b => b.PublicationDate)
                .HasColumnName("publication_date");
            entity.Property(b => b.AuthorId)
                .IsRequired()
                .HasColumnName("author_id");
            entity.Property(b => b.CreationDate)
                .HasColumnName("creation_date");
            entity.Property(b => b.EditDate)
                .HasColumnName("edit_date");
            entity.HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId);
        });
        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("person");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(p => p.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("first_name");
            entity.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("last_name");
            entity.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("middle_name");
            entity.Property(p => p.CreationDate)
                .HasColumnName("creation_date");
            entity.Property(p => p.EditDate)
                .HasColumnName("edit_date");
        });
        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("genre");
            entity.HasKey(g => g.Id);
            entity.Property(g => g.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(g => g.GenreName)
                .IsRequired()
                .HasColumnName("genre_name");
            entity.Property(g => g.CreationDate)
                .HasColumnName("creation_date");
            entity.Property(g => g.EditDate)
                .HasColumnName("edit_date");
        });
        modelBuilder.Entity<BookGenre>(entity =>
        {
            entity.ToTable("book_genre");
            entity.Property(bg => bg.BookId).HasColumnName("book_id");
            entity.Property(bg => bg.GenreId).HasColumnName("genre_id");
            entity.HasKey(bg => new {bg.BookId, bg.GenreId});
            entity.HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);
            entity.HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);
        });
        modelBuilder.Entity<LibraryCard>(entity =>
        {
            entity.ToTable("library_card");
            entity.Property(lc => lc.BookId).HasColumnName("book_id");
            entity.Property(lc => lc.PersonId).HasColumnName("person_id");
            entity.Property(lc => lc.BorrowingTime).HasColumnName("borrowing_time");
            entity.HasKey(lc => new {lc.BookId, lc.PersonId});
            entity.HasOne(lc => lc.Book)
                .WithMany(b => b.LibraryCards)
                .HasForeignKey(lc => lc.BookId);
            entity.HasOne(lc => lc.Person)
                .WithMany(p => p.LibraryCards)
                .HasForeignKey(lc => lc.PersonId);
        });
        base.OnModelCreating(modelBuilder);
    }
}