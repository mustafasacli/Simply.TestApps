using FluentValidation;

namespace Mst.Project.Entity
{
    public class OfficesValidator : AbstractValidator<Offices>
    {
        public OfficesValidator()
        {
            RuleFor(entity => entity.OfficeCode).NotEmpty().WithMessage("OfficeCode alaný boþ geçilemez.");
            RuleFor(entity => entity.OfficeCode).MaximumLength(10).WithMessage("OfficeCode alaný 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.City).NotEmpty().WithMessage("City alaný boþ geçilemez.");
            RuleFor(entity => entity.City).MaximumLength(50).WithMessage("City alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Phone).NotEmpty().WithMessage("Phone alaný boþ geçilemez.");
            RuleFor(entity => entity.Phone).MaximumLength(50).WithMessage("Phone alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.AddressLine1).NotEmpty().WithMessage("AddressLine1 alaný boþ geçilemez.");
            RuleFor(entity => entity.AddressLine1).MaximumLength(50).WithMessage("AddressLine1 alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.Country).NotEmpty().WithMessage("Country alaný boþ geçilemez.");
            RuleFor(entity => entity.Country).MaximumLength(50).WithMessage("Country alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.PostalCode).NotEmpty().WithMessage("PostalCode alaný boþ geçilemez.");
            RuleFor(entity => entity.PostalCode).MaximumLength(15).WithMessage("PostalCode alaný 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.Territory).NotEmpty().WithMessage("Territory alaný boþ geçilemez.");
            RuleFor(entity => entity.Territory).MaximumLength(10).WithMessage("Territory alaný 10 karakterden uzun olamaz.");
        }
    }
}