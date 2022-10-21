using FluentValidation;

namespace SSLibrary.API.CQRS.Persons.Commands.CreatePerson;

public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
{
    public CreatePersonCommandValidator()
    {
        RuleFor(createPersonCommand =>
            createPersonCommand.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(createPersonCommand =>
            createPersonCommand.LastName).NotEmpty().MaximumLength(30);
        RuleFor(createPersonCommand =>
            createPersonCommand.MiddleName).MaximumLength(30);
        RuleFor(createPersonCommand =>
            createPersonCommand.BirthDate).LessThan(DateTime.Now);
    }
}