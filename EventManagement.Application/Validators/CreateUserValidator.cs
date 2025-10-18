using FluentValidation;
using EventManagement.Application.DTOs;
using System.Data;
using EventManagement.Infrastructure.Interfaces;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDTO>
{
    private readonly IUserRepository _userRepository;
    public CreateUserDtoValidator(IUserRepository userRepository)
    {
        _userRepository = userRepository;

        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.")
            .MustAsync(async (email, cancellation) =>
            {
                var existingUser = await _userRepository.GetByEmailAsync(email);
                return existingUser == null;
            })
            .WithMessage("Email must be unique.");
        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.");
        RuleFor(x => x.UserRoleId)
            .GreaterThan(0).WithMessage("User role is required.");
    }
}
