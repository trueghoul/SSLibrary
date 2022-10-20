using AutoMapper;
using SSLibrary.API.Entities;
using SSLibrary.API.Mappings;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPersonBookList;

public class PersonBookLookupDto : IMapWith<Book>
{
    // For book
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string AuthorId { get; set; }
    // For Author
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    // For Genre
    //public List<Genre> Genres { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Book, PersonBookLookupDto>()
            .ForMember(pb => pb.Id,
                opt => opt.MapFrom(book => book.Id))
            .ForMember(pb => pb.Name,
                opt => opt.MapFrom(book => book.Name))
            .ForMember(pb => pb.AuthorId,
                opt => opt.MapFrom(book => book.AuthorId))
            .ForMember(pb => pb.FirstName,
                opt => opt.MapFrom(author => author.Author.FirstName))
            .ForMember(pb => pb.LastName,
                opt => opt.MapFrom(author => author.Author.LastName))
            .ForMember(pb => pb.MiddleName,
                opt => opt.MapFrom(author => author.Author.MiddleName));
        //.ForMember(pb => pb.Genres, opt => opt.MapFrom());
    }
}