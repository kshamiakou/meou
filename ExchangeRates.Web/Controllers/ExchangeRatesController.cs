using ExchangeRates.Business.Models;
using ExchangeRates.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeRates.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ExchangeRatesController : ControllerBase
{
    private readonly IExchangeRatesService _exchangeRatesService;

    public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
    {
        _exchangeRatesService = exchangeRatesService;
    }

    [HttpGet]
    [Route("{currency}")]
    public async Task<IReadOnlyCollection<ExchangeRateMetadata>> Get(string currency)
    {
        return await _exchangeRatesService.GetCurrentExchangeRates(currency);
    }
}