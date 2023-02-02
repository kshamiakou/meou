using ExchangeRates.Business.Models;
using ExchangeRates.Business.Services.Interfaces;
using ExchangeRates.Data.Models;
using ExchangeRates.Data.Repositories.Interfaces;
using FluentValidation;

namespace ExchangeRates.Business.Services;

public class ExchangeRatesService : IExchangeRatesService
{
    private readonly HttpClient _httpClient;
    private readonly IExchangeRatesRepository<ExchangeRateEntity> _repository;
    private readonly AbstractValidator<string> _currencyValidator;

    public ExchangeRatesService(
        HttpClient httpClient,
        IExchangeRatesRepository<ExchangeRateEntity> repository,
        AbstractValidator<string> currencyValidator)
    {
        _httpClient = httpClient;
        _repository = repository;
        _currencyValidator = currencyValidator;
    }

    public async ValueTask<IReadOnlyCollection<ExchangeRateMetadata>> GetCurrentExchangeRates(string currency)
    {
        if (await _currencyValidator.ValidateAsync(currency) is { IsValid: false } validationResult)
        {
            // May be log smth or return error/empty array
        }

        var result = await _repository.GetAllAsync(currency);

        // Perform some mappings via AutoMapper or smth custom

        return Array.Empty<ExchangeRateMetadata>();
    }

    public Task SyncExchangeRatesDataAsync()
    {
        // use injected _httpClient here to fetch rates data, better with any httpClient extensions
        // save fetched data to the database
        // http client lifetime managed by di container, dont worry and dont use Dispose() pls ;)
        return Task.CompletedTask;
    }
}