using FluentValidation;

namespace SSLibrary.API.CQRS.Persons.Commands.DeletePerson;

public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
{
    public DeletePersonCommandValidator()
    {
        RuleFor(deletePersonCommand =>
            deletePersonCommand.Id).NotEqual(Guid.Empty);
    }
}