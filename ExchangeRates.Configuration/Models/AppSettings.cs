#nullable disable

using System.ComponentModel.DataAnnotations;

namespace ExchangeRates.Configuration.Models;

public class AppSettings
{
    [Required]
    private IReadOnlyCollection<string> PreferredMarkets { get; init; }
}