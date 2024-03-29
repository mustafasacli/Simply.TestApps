using FluentValidation;

namespace Mst.Project.Entity
{
    public class ProductlinesValidator : AbstractValidator<Productlines>
    {
        public ProductlinesValidator()
        {
            RuleFor(entity => entity.ProductLine).NotEmpty().WithMessage("ProductLine alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductLine).MaximumLength(50).WithMessage("ProductLine alan� 50 karakterden uzun olamaz.");
        }
    }
}