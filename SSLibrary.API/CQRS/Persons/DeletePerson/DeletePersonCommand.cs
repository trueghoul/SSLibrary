using MediatR;

namespace SSLibrary.API.CQRS.Persons.DeletePerson;

public class DeletePersonCommand : IRequest
{
    public Guid Id { get; set; }
}