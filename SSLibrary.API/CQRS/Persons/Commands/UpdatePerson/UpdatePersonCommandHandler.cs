using MediatR;
using Microsoft.EntityFrameworkCore;
using SSLibrary.API.Entities;
using SSLibrary.API.Exceptions;

namespace SSLibrary.API.CQRS.Persons.Commands.UpdatePerson;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdatePersonCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        var entity = 
            await _context.Persons.FirstOrDefaultAsync(person => 
                person.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }
        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.MiddleName = request.MiddleName;
        entity.BirthDate = request.BirthDate;
        entity.EditDate = DateTimeOffset.Now;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}