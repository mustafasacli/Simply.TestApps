using System;
using FluentValidation;

namespace Mst.Project.Entity
{
    public class PaymentsValidator : AbstractValidator<Payments>
    {
        public PaymentsValidator()
        {
            RuleFor(entity => entity.CustomerNumber).NotNull().WithMessage("CustomerNumber alaný boþ geçilemez.");

            RuleFor(entity => entity.CheckNumber).NotEmpty().WithMessage("CheckNumber alaný boþ geçilemez.");
            RuleFor(entity => entity.CheckNumber).MaximumLength(50).WithMessage("CheckNumber alaný 50 karakterden uzun olamaz.");

            RuleFor(entity => entity.PaymentDate).NotNull().WithMessage("PaymentDate alaný boþ geçilemez.");

            RuleFor(entity => entity.Amount).NotNull().WithMessage("Amount alaný boþ geçilemez.");
        }
    }
}