using FluentValidation;

namespace WorkshopManager.Api.DTOs.Employee.Validations;

public class EmployeeCreateDTOValidation : AbstractValidator<EmployeeCreateDTO>
{
    public EmployeeCreateDTOValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required");
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Email is not valid")
            ;
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required");
        RuleFor(x => x.Role)
            .IsInEnum()
            .WithMessage("Role is not valid");
    }
}
