using FluentValidation;

namespace BankingApp.Application.Features.Account.Command
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator() {
                RuleFor(x => x.UserId)
               .GreaterThan(0)
               .WithMessage("UserId must be greater than 0.");

                RuleFor(x => x.Balance)
                    .GreaterThanOrEqualTo(0)
                    .WithMessage("Balance must be greater than or equal to 0.");

                RuleFor(x => x.AccountType)
                    .NotEmpty()
                    .WithMessage("AccountType is required.")
                    .Must(BeAValidAccountType)
                    .WithMessage("AccountType is not valid.");
        }
        private bool BeAValidAccountType(string accountType)
        {
            var validAccountTypes = new List<string> { "Checking", "Savings", "Business" };
            return validAccountTypes.Contains(accountType);
        }
    }
}
