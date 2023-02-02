using ExchangeRates.Business.Models;
using ExchangeRates.Business.Services.Interfaces;

namespace ExchangeRates.Business.Services;

// Decorator for audit/log needs
public class ExchangeRatesServiceLogDecorator : IExchangeRatesService
{
    private readonly IExchangeRatesService _service;

    public ExchangeRatesServiceLogDecorator(IExchangeRatesService service)
    {
        _service = service;
    }

    public ValueTask<IReadOnlyCollection<ExchangeRateMetadata>> GetCurrentExchangeRates(string currency)
    {
        // _logger.LogCurrencyInput(currency);
        return _service.GetCurrentExchangeRates(currency);
    }

    public Task SyncExchangeRatesDataAsync()
    {
        return _service.SyncExchangeRatesDataAsync();
    }
}