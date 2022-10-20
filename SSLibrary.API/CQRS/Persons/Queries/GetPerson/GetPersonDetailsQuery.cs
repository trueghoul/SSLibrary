using MediatR;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPerson;

public class GetPersonDetailsQuery : IRequest<PersonDetailsVm>
{
    public Guid Id { get; set; }
}