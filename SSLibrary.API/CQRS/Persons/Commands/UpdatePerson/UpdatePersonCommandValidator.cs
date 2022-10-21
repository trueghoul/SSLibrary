using FluentValidation;

namespace SSLibrary.API.CQRS.Persons.Commands.UpdatePerson;

public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
{
    public UpdatePersonCommandValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.BirthDate).LessThan(DateTime.Now);
        RuleFor(command =>
            command.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.LastName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.MiddleName).MaximumLength(30);
    }
}