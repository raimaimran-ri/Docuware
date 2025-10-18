using FluentValidation;
using EventManagement.Application.DTOs;
using System.Data;
using EventManagement.Infrastructure.Interfaces;

public class CreateEventRegistrationDtoValidator : AbstractValidator<CreateEventRegistrationDTO>
{
    public CreateEventRegistrationDtoValidator()
    {
        RuleFor(x => x.EventId)
            .GreaterThan(0).WithMessage("EventId must be greater than 0.");
        When(x => x.UserId == null, () =>
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Name is required when UserId is null.");
            RuleFor(x => x.UserEmail)
                .NotEmpty().WithMessage("Email is required when UserId is null.");
            RuleFor(x => x.UserPhoneNumber)
                .NotEmpty().WithMessage("Phone number is required when UserId is null.");
        });
    }
}
