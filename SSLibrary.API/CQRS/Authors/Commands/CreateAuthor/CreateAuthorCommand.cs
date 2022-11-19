using MediatR;

namespace SSLibrary.API.CQRS.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
}