using System;
using FluentValidation;

namespace Mst.Project.Entity
{
    public class OrdersValidator : AbstractValidator<Orders>
    {
        public OrdersValidator()
        {
            RuleFor(entity => entity.OrderNumber).NotNull().WithMessage("OrderNumber alan� bo� ge�ilemez.");

            RuleFor(entity => entity.OrderDate).NotNull().WithMessage("OrderDate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.RequiredDate).NotNull().WithMessage("RequiredDate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Status).NotEmpty().WithMessage("Status alan� bo� ge�ilemez.");
            RuleFor(entity => entity.Status).MaximumLength(15).WithMessage("Status alan� 15 karakterden uzun olamaz.");

            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alan� bo� ge�ilemez.");
        }
    }
}