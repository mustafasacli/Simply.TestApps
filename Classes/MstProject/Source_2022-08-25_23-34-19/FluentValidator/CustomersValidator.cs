using FluentValidation;

namespace Mst.Project.Entity
{
    public class CustomersValidator : AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alaný boþ geçilemez.");

            RuleFor(entity => entity.CustomerName).NotEmpty().WithMessage("CustomerName alaný boþ geçilemez.");
            RuleFor(entity => entity.CustomerName).MaximumLength(50).WithMessage("CustomerName alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ContactLastName).NotEmpty().WithMessage("ContactLastName alaný boþ geçilemez.");
            RuleFor(entity => entity.ContactLastName).MaximumLength(50).WithMessage("ContactLastName alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ContactFirstName).NotEmpty().WithMessage("ContactFirstName alaný boþ geçilemez.");
            RuleFor(entity => entity.ContactFirstName).MaximumLength(50).WithMessage("ContactFirstName alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alaný boþ geçilemez.");
            RuleFor(entity => entity.Phone).MaximumLength(50).WithMessage("Phone alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.AddressLine1).NotEmpty().WithMessage("AddressLine1 alaný boþ geçilemez.");
            RuleFor(entity => entity.AddressLine1).MaximumLength(50).WithMessage("AddressLine1 alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alaný boþ geçilemez.");
            RuleFor(entity => entity.City).MaximumLength(50).WithMessage("City alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alaný boþ geçilemez.");
            RuleFor(entity => entity.Country).MaximumLength(50).WithMessage("Country alaný 50 karakterden uzun olamaz.");
        }
    }
}