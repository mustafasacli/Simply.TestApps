using FluentValidation;

namespace Mst.Project.Entity
{
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(entity => entity.ProductCode).NotEmpty().WithMessage("ProductCode alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductCode).MaximumLength(15).WithMessage("ProductCode alan� 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductName).NotEmpty().WithMessage("ProductName alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductName).MaximumLength(70).WithMessage("ProductName alan� 70 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductLine).NotEmpty().WithMessage("ProductLine alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductLine).MaximumLength(50).WithMessage("ProductLine alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductScale).NotEmpty().WithMessage("ProductScale alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductScale).MaximumLength(10).WithMessage("ProductScale alan� 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductVendor).NotEmpty().WithMessage("ProductVendor alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductVendor).MaximumLength(50).WithMessage("ProductVendor alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductDescription).NotEmpty().WithMessage("ProductDescription alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductDescription).MaximumLength(65535).WithMessage("ProductDescription alan� 65535 karakterden uzun olamaz.");

            RuleFor(entity => entity.QuantityInStock).NotNull().WithMessage("QuantityInStock alan� bo� ge�ilemez.");

            RuleFor(entity => entity.BuyPrice).NotNull().WithMessage("BuyPrice alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Msrp).NotNull().WithMessage("Msrp alan� bo� ge�ilemez.");
        }
    }
}