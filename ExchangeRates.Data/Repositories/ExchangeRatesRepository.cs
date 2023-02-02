using ExchangeRates.Data.Models;
using ExchangeRates.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRates.Data.Repositories;

public class ExchangeRatesRepository : IExchangeRatesRepository<ExchangeRateEntity>
{
    private readonly ExchangeRatesContext _context;

    public ExchangeRatesRepository(ExchangeRatesContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyCollection<ExchangeRateEntity>> GetAllAsync(string currency)
    {
        return await _context.ExchangeRates
            .Where(x => x.Currency.Equals(currency, StringComparison.Ordinal))
            .ToListAsync();
    }
}