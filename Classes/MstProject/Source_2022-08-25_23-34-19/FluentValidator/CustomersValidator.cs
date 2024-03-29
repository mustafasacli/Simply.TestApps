using FluentValidation;

namespace Mst.Project.Entity
{
    public class CustomersValidator : AbstractValidator<Customers>
    {
        public CustomersValidator()
        {
            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CustomerName).NotEmpty().WithMessage("CustomerName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.CustomerName).MaximumLength(50).WithMessage("CustomerName alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ContactLastName).NotEmpty().WithMessage("ContactLastName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ContactLastName).MaximumLength(50).WithMessage("ContactLastName alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ContactFirstName).NotEmpty().WithMessage("ContactFirstName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ContactFirstName).MaximumLength(50).WithMessage("ContactFirstName alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Phone).MaximumLength(50).WithMessage("Phone alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.AddressLine1).NotEmpty().WithMessage("AddressLine1 alan� bo� ge�ilemez.");
            RuleFor(entity => entity.AddressLine1).MaximumLength(50).WithMessage("AddressLine1 alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alan� bo� ge�ilemez.");
            RuleFor(entity => entity.City).MaximumLength(50).WithMessage("City alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Country).MaximumLength(50).WithMessage("Country alan� 50 karakterden uzun olamaz.");
        }
    }
}