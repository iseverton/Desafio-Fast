using FluentValidation;

namespace WorkshopManager.Api.DTOs.AuthDTOs
{
    public class LoginDTOValidation : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation() 
        { 
           RuleFor(l => l.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email is required")
                .EmailAddress()
                .WithMessage("Email is not valid");

            RuleFor(l => l.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
