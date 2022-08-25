using FluentValidation;

namespace Mst.Project.Entity
{
    public class OrderdetailsValidator : AbstractValidator<Orderdetails>
    {
        public OrderdetailsValidator()
        {
            RuleFor(entity => entity.OrderNumber).NotNull().WithMessage("OrderNumber alaný boþ geçilemez.");

            RuleFor(entity => entity.ProductCode).NotEmpty().WithMessage("ProductCode alaný boþ geçilemez.");
            RuleFor(entity => entity.ProductCode).MaximumLength(15).WithMessage("ProductCode alaný 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.QuantityOrdered).NotNull().WithMessage("QuantityOrdered alaný boþ geçilemez.");

            RuleFor(entity => entity.PriceEach).NotNull().WithMessage("PriceEach alaný boþ geçilemez.");

            RuleFor(entity => entity.OrderLineNumber).NotNull().WithMessage("OrderLineNumber alaný boþ geçilemez.");
        }
    }
}