using System;
using FluentValidation;

namespace Mst.Project.Entity
{
    public class PaymentsValidator : AbstractValidator<Payments>
    {
        public PaymentsValidator()
        {
            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CheckNumber).NotEmpty().WithMessage("CheckNumber alan� bo� ge�ilemez.");
            RuleFor(entity => entity.CheckNumber).MaximumLength(50).WithMessage("CheckNumber alan� 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.PaymentDate).NotNull().WithMessage("PaymentDate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Amount).NotNull().WithMessage("Amount alan� bo� ge�ilemez.");
        }
    }
}