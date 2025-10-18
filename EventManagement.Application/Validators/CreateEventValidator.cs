using FluentValidation;
using EventManagement.Application.DTOs;
using System.Data;
using EventManagement.Infrastructure.Interfaces;

public class CreateEventDtoValidator : AbstractValidator<CreateEventDTO>
{
    private readonly IUserRepository _userRepository;
    public CreateEventDtoValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Event name is required")
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required");

        RuleFor(x => x.StartTime)
            .LessThan(x => x.EndTime)
            .WithMessage("Start time must be before end time");

        RuleFor(x => x.EndTime)
            .GreaterThan(x => x.StartTime)
            .WithMessage("End time must be after start time");

        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be a positive integer")
            .MustAsync(async (userId, cancellation) => await _userRepository.IsUserCreator(userId))
            .WithMessage("User must be of creator type");
    }
}
