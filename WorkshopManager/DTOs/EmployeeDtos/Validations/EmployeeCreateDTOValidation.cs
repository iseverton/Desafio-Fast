using FluentValidation;
using WorkshopManager.Api.DTOs.EmployeeDtos;

namespace WorkshopManager.Api.DTOs.EmployeeDtos.Validations;

public class EmployeeCreateDTOValidation : AbstractValidator<EmployeeCreateDTO>
{
    public EmployeeCreateDTOValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid");


        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .Length(5, 50).WithMessage("Password must be between 5 and 50 characters.");
        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Role is not valid");
    }
}
