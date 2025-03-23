using FluentValidation;
using Todolist.Communication.Requests;
using Todolist.Exception;

namespace Todolist.Application.UseCases.Tasks.Register;

public class RegisterTaskValidator : AbstractValidator<RequestTaskJson>
{
    public RegisterTaskValidator()
    {
        RuleFor(task => task.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NAME_REQUIRED);
        RuleFor(task => task.Priority)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.PRIORITY_INVALID);
        RuleFor(task => task.Deadline)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessages.DATE_CANNOT_BE_IN_PAST);
        RuleFor(task => task.Status)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.STATUS_INVALID);
    }
}