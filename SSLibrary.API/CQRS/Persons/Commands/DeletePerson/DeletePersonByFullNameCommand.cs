using MediatR;

namespace SSLibrary.API.CQRS.Persons.Commands.DeletePerson;

public class DeletePersonByFullNameCommand : IRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}