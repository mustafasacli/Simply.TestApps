using FluentValidation;

namespace Mst.Project.Entity
{
    public class OrderdetailsValidator : AbstractValidator<Orderdetails>
    {
        public OrderdetailsValidator()
        {
            RuleFor(entity => entity.OrderNumber).NotNull().WithMessage("OrderNumber alan� bo� ge�ilemez.");

            RuleFor(entity => entity.ProductCode).NotEmpty().WithMessage("ProductCode alan� bo� ge�ilemez.");
            RuleFor(entity => entity.ProductCode).MaximumLength(15).WithMessage("ProductCode alan� 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.QuantityOrdered).NotNull().WithMessage("QuantityOrdered alan� bo� ge�ilemez.");

            RuleFor(entity => entity.PriceEach).NotNull().WithMessage("PriceEach alan� bo� ge�ilemez.");

            RuleFor(entity => entity.OrderLineNumber).NotNull().WithMessage("OrderLineNumber alan� bo� ge�ilemez.");
        }
    }
}