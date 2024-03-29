using FluentValidation;

namespace Mst.Project.Entity
{
    public class EmployeesValidator : AbstractValidator<Employees>
    {
        public EmployeesValidator()
        {
            RuleFor(entity => entity.EmployeeNumber).NotNull().WithMessage("EmployeeNumber alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.LastName).MaximumLength(50).WithMessage("LastName alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.FirstName).MaximumLength(50).WithMessage("FirstName alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Extension).NotEmpty().WithMessage("Extension alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Extension).MaximumLength(10).WithMessage("Extension alan� 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.Email).NotEmpty().WithMessage("Email alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Email).MaximumLength(100).WithMessage("Email alan� 100 karakterden uzun olamaz.");

            RuleFor(entity => entity.OfficeCode).NotEmpty().WithMessage("OfficeCode alan� bo� ge�ilemez.");
            RuleFor(entity => entity.OfficeCode).MaximumLength(10).WithMessage("OfficeCode alan� 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.JobTitle).NotEmpty().WithMessage("JobTitle alan� bo� ge�ilemez.");
            RuleFor(entity => entity.JobTitle).MaximumLength(50).WithMessage("JobTitle alan� 50 karakterden uzun olamaz.");
        }
    }
}