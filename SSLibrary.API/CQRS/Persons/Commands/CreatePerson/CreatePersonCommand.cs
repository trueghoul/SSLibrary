using MediatR;

namespace SSLibrary.API.CQRS.Persons.Commands.CreatePerson;

public class CreatePersonCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime BirthDate { get; set; }
}