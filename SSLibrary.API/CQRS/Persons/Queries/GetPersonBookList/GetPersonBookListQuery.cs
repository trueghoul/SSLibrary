using MediatR;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPersonBookList;

public class GetPersonBookListQuery : IRequest<PersonsBooksListVm>
{
    public Guid PersonId { get; set; }
}