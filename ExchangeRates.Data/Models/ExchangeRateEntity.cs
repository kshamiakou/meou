namespace ExchangeRates.Data.Models;

public record ExchangeRateEntity
{
    public Guid Id { get; init; }

    public string Currency { get; init; } = string.Empty;

    public decimal Amount { get; init; }

    private DateTimeOffset Date { get; init; }
};
