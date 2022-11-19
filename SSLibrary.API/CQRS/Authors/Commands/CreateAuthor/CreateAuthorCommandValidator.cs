using FluentValidation;

namespace SSLibrary.API.CQRS.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
{
    public CreateAuthorCommandValidator()
    {
        RuleFor(command =>
            command.FirstName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.LastName).NotEmpty().MaximumLength(30);
        RuleFor(command =>
            command.MiddleName).MaximumLength(30);
    }
}