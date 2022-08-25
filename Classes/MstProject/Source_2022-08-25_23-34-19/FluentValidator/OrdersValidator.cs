using System;
using FluentValidation;

namespace Mst.Project.Entity
{
    public class OrdersValidator : AbstractValidator<Orders>
    {
        public OrdersValidator()
        {
            RuleFor(entity => entity.OrderNumber).NotNull().WithMessage("OrderNumber alaný boþ geçilemez.");

            RuleFor(entity => entity.OrderDate).NotNull().WithMessage("OrderDate alaný boþ geçilemez.");

            RuleFor(entity => entity.RequiredDate).NotNull().WithMessage("RequiredDate alaný boþ geçilemez.");

            RuleFor(entity => entity.Status).NotEmpty().WithMessage("Status alaný boþ geçilemez.");
            RuleFor(entity => entity.Status).MaximumLength(15).WithMessage("Status alaný 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alaný boþ geçilemez.");
        }
    }
}