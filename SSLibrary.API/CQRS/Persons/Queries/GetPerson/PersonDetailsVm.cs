using AutoMapper;
using SSLibrary.API.Entities;
using SSLibrary.API.Mappings;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPerson;

public class PersonDetailsVm : IMapWith<Person>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Person, PersonDetailsVm>()
            .ForMember(personVm => personVm.Id,
                opt => opt.MapFrom(person => person.Id))
            .ForMember(personVm => personVm.FirstName,
                opt => opt.MapFrom(person => person.FirstName))
            .ForMember(personVm => personVm.MiddleName,
                opt => opt.MapFrom(person => person.MiddleName))
            .ForMember(personVm => personVm.LastName,
                opt => opt.MapFrom(person => person.LastName))
            .ForMember(personVm => personVm.BirthDate,
                opt => opt.MapFrom(person => person.BirthDate));
    }
}