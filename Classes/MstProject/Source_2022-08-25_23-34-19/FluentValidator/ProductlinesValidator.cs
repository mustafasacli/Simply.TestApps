using FluentValidation;

namespace Mst.Project.Entity
{
    public class ProductlinesValidator : AbstractValidator<Productlines>
    {
        public ProductlinesValidator()
        {
            RuleFor(entity => entity.ProductLine).NotEmpty().WithMessage("ProductLine alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductLine).MaximumLength(50).WithMessage("ProductLine alaný 50 karakterden uzun olamaz.");
        }
    }
}