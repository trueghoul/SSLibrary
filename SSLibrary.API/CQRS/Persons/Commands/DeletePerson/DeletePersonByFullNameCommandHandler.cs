using MediatR;
using Microsoft.EntityFrameworkCore;
using SSLibrary.API.Entities;
using SSLibrary.API.Exceptions;

namespace SSLibrary.API.CQRS.Persons.Commands.DeletePerson;

public class DeletePersonByFullNameCommandHandler : IRequestHandler<DeletePersonByFullNameCommand>
{
    private readonly IApplicationDbContext _context;

    public DeletePersonByFullNameCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeletePersonByFullNameCommand request, CancellationToken cancellationToken)
    {
        var entities = await _context.Persons
            .Where(p => p.FirstName == request.FirstName &&
                        p.MiddleName == request.MiddleName &&
                        p.LastName == request.LastName)
            .ToListAsync(cancellationToken);
        if (!entities.Any())
        {
            throw new NotFoundException(nameof(Person),
                $"{request.FirstName} {request.MiddleName} {request.LastName}");
        }
        
        foreach (var entity in entities)
        {
            _context.Persons.Remove(entity);
        }

        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}