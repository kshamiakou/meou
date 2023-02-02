using FluentValidation;

namespace ExchangeRates.Business.Validators;

public class CurrencyInputValidator : AbstractValidator<string>
{
    public CurrencyInputValidator()
    {
        RuleFor(x => x).MaximumLength(15);

        // Add other rules to validate input
    }
}