using MediatR;

namespace SSLibrary.API.CQRS.Persons.UpdatePerson;

public class UpdatePersonCommand : IRequest
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; } 
}