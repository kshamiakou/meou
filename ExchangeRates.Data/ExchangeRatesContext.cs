using ExchangeRates.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRates.Data;

public sealed class ExchangeRatesContext : DbContext
{
    public ExchangeRatesContext(DbContextOptions<ExchangeRatesContext> options)
        : base(options)
    {
        this.Database.EnsureCreated();
    }

    public DbSet<ExchangeRateEntity> ExchangeRates { get; set; }
}