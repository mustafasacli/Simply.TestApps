using FluentValidation;

namespace Mst.Project.Entity
{
    public class ProductsValidator : AbstractValidator<Products>
    {
        public ProductsValidator()
        {
            RuleFor(entity => entity.ProductCode).NotEmpty().WithMessage("ProductCode alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductCode).MaximumLength(15).WithMessage("ProductCode alaný 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductName).NotEmpty().WithMessage("ProductName alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductName).MaximumLength(70).WithMessage("ProductName alaný 70 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductLine).NotEmpty().WithMessage("ProductLine alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductLine).MaximumLength(50).WithMessage("ProductLine alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductScale).NotEmpty().WithMessage("ProductScale alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductScale).MaximumLength(10).WithMessage("ProductScale alaný 10 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductVendor).NotEmpty().WithMessage("ProductVendor alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductVendor).MaximumLength(50).WithMessage("ProductVendor alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.ProductDescription).NotEmpty().WithMessage("ProductDescription alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductDescription).MaximumLength(65535).WithMessage("ProductDescription alaný 65535 karakterden uzun olamaz.");

            RuleFor(entity => entity.QuantityInStock).NotNull().WithMessage("QuantityInStock alaný boþ geçilemez.");

            RuleFor(entity => entity.BuyPrice).NotNull().WithMessage("BuyPrice alaný boþ geçilemez.");

            RuleFor(entity => entity.Msrp).NotNull().WithMessage("Msrp alaný boþ geçilemez.");
        }
    }
}