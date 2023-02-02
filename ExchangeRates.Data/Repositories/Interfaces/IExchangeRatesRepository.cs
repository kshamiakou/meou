namespace ExchangeRates.Data.Repositories.Interfaces;

public interface IExchangeRatesRepository<TModel>
{
    Task<IReadOnlyCollection<TModel>> GetAllAsync(string currency);

    // etc.
}