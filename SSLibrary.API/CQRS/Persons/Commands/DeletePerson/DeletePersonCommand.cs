using MediatR;

namespace SSLibrary.API.CQRS.Persons.Commands.DeletePerson;

public class DeletePersonCommand : IRequest
{
    public Guid Id { get; set; }
}