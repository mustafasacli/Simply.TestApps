using FluentValidation;

namespace Mst.Project.Entity
{
    public class OfficesValidator : AbstractValidator<Offices>
    {
        public OfficesValidator()
        {
            RuleFor(entity => entity.OfficeCode).NotEmpty().WithMessage("OfficeCode alan� bo� ge�ilemez.");
            RuleFor(entity => entity.OfficeCode).MaximumLength(10).WithMessage("OfficeCode alan� 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alan� bo� ge�ilemez.");
            RuleFor(entity => entity.City).MaximumLength(50).WithMessage("City alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Phone).MaximumLength(50).WithMessage("Phone alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.AddressLine1).NotEmpty().WithMessage("AddressLine1 alan� bo� ge�ilemez.");
            RuleFor(entity => entity.AddressLine1).MaximumLength(50).WithMessage("AddressLine1 alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Country).MaximumLength(50).WithMessage("Country alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.PostalCode).NotEmpty().WithMessage("PostalCode alan� bo� ge�ilemez.");
            RuleFor(entity => entity.PostalCode).MaximumLength(15).WithMessage("PostalCode alan� 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.Territory).NotEmpty().WithMessage("Territory alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Territory).MaximumLength(10).WithMessage("Territory alan� 10 karakterden uzun olamaz.");
        }
    }
}