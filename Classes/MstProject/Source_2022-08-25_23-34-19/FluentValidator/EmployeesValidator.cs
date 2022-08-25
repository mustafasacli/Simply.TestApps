using FluentValidation;

namespace Mst.Project.Entity
{
    public class EmployeesValidator : AbstractValidator<Employees>
    {
        public EmployeesValidator()
        {
            RuleFor(entity => entity.EmployeeNumber).NotNull().WithMessage("EmployeeNumber alaný boþ geçilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alaný boþ geçilemez.");
            RuleFor(entity => entity.LastName).MaximumLength(50).WithMessage("LastName alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alaný boþ geçilemez.");
            RuleFor(entity => entity.FirstName).MaximumLength(50).WithMessage("FirstName alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Extension).NotEmpty().WithMessage("Extension alaný boþ geçilemez.");
            RuleFor(entity => entity.Extension).MaximumLength(10).WithMessage("Extension alaný 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.Email).NotEmpty().WithMessage("Email alaný boþ geçilemez.");
            RuleFor(entity => entity.Email).MaximumLength(100).WithMessage("Email alaný 100 karakterden uzun olamaz.");

            RuleFor(entity => entity.OfficeCode).NotEmpty().WithMessage("OfficeCode alaný boþ geçilemez.");
            RuleFor(entity => entity.OfficeCode).MaximumLength(10).WithMessage("OfficeCode alaný 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.JobTitle).NotEmpty().WithMessage("JobTitle alaný boþ geçilemez.");
            RuleFor(entity => entity.JobTitle).MaximumLength(50).WithMessage("JobTitle alaný 50 karakterden uzun olamaz.");
        }
    }
}