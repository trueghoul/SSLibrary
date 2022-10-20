using MediatR;
using SSLibrary.API.Entities;

namespace SSLibrary.API.CQRS.Persons.Commands.CreatePerson;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            BirthDate = request.BirthDate,
            CreationDate = DateTimeOffset.Now,
            EditDate = null,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName
        };
        await _context.Persons.AddAsync(person, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return person.Id;
    }
}