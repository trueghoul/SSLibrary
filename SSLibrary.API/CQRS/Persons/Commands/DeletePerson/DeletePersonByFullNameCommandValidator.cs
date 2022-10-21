using FluentValidation;

namespace SSLibrary.API.CQRS.Persons.Commands.DeletePerson;

public class DeletePersonByFullNameCommandValidator : AbstractValidator<DeletePersonByFullNameCommand>
{
    public DeletePersonByFullNameCommandValidator()
    {
        RuleFor(command =>
            command.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.LastName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.MiddleName).MaximumLength(30);
    }
}