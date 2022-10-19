using MediatR;
using SSLibrary.API.Entities;
using SSLibrary.API.Exceptions;

namespace SSLibrary.API.CQRS.Persons.DeletePerson;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Persons
            .FindAsync(new object[] {request.Id}, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }

        _context.Persons.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}