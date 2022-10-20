using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSLibrary.API.Entities;
using SSLibrary.API.Exceptions;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPerson;

public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsVm>
{
    private IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonDetailsQueryHandler(IMapper mapper, IApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<PersonDetailsVm> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _context.Persons
            .FirstOrDefaultAsync(person => person.Id == request.Id, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Person), request.Id);
        }
        
        return _mapper.Map<PersonDetailsVm>(entity);
    }
}