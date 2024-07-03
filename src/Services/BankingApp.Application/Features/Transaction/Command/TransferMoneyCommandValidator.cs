using FluentValidation;

namespace BankingApp.Application.Features.Transaction.Command
{
    public class TransferMoneyCommandValidator : AbstractValidator<TransferMoneyCommand>
    {
        public TransferMoneyCommandValidator()
        {
            RuleFor(x => x.FromAccountId).NotEmpty().WithMessage("{FromAccountId} could not be empty")
                    .NotNull()
                    .LessThanOrEqualTo(11)
                    .WithMessage("{FromAccountId} must be less than 11");
            RuleFor(x => x.ToAccountId).NotEmpty().WithMessage("{ToAccountId} could not be empty")
                  .NotNull()
                  .LessThanOrEqualTo(11)
                  .WithMessage("{ToAccountId} must be less than 11");


            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("{Amount} could not be empty")
                 .NotNull().WithMessage("{Amount} could not be null")
            .GreaterThanOrEqualTo(0).WithMessage("Price must be greater than or equal to 0.")
            .ScalePrecision(2, 10).WithMessage("Price must have up to 2 decimal places and be no more than 10 digits in total.");
        }
    }
}
