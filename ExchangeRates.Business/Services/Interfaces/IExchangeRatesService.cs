using ExchangeRates.Business.Models;

namespace ExchangeRates.Business.Services.Interfaces;

public interface IExchangeRatesService
{
    ValueTask<IReadOnlyCollection<ExchangeRateMetadata>> GetCurrentExchangeRates(string currency);

    Task SyncExchangeRatesDataAsync();
}