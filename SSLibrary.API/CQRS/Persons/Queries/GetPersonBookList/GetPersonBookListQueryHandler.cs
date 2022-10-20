using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SSLibrary.API.Entities;

namespace SSLibrary.API.CQRS.Persons.Queries.GetPersonBookList;

public class GetPersonBookListQueryHandler : IRequestHandler<GetPersonBookListQuery, PersonsBooksListVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetPersonBookListQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PersonsBooksListVm> Handle(GetPersonBookListQuery request, CancellationToken cancellationToken)
    {
        return new PersonsBooksListVm();
    }
}