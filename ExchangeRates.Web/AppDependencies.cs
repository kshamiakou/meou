using ExchangeRates.Business.Services;
using ExchangeRates.Business.Services.Interfaces;
using ExchangeRates.Business.Validators;
using ExchangeRates.Data.Models;
using ExchangeRates.Data.Repositories;
using ExchangeRates.Data.Repositories.Interfaces;
using FluentValidation;
using Kantar.Syndicated.Orchestrator.ExternalServices.RetryPolicies;

namespace ExchangeRates.Web;

internal static class AppDependencies
{
    public const string HttpClientName = "RetryOn500";

    public static IServiceCollection RegisterAppDependencies(this IServiceCollection services)
    {
        return services
            .RegisterHttpClient()
            .AddScoped<AbstractValidator<string>, CurrencyInputValidator>()
            .AddScoped<IExchangeRatesRepository<ExchangeRateEntity>, ExchangeRatesRepository>()
            .AddScoped<IExchangeRatesService, ExchangeRatesService>()
            .Decorate<IExchangeRatesService, ExchangeRatesServiceLogDecorator>();
    }

    private static IServiceCollection RegisterHttpClient(this IServiceCollection services)
    {
        services
            .AddHttpClient(HttpClientName)
            .AddPolicyHandler(Policies.CreateRetryWhenInternalServiceErrorPolicy());

        return services.AddSingleton(serviceProvider =>
        {
            var clientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            return clientFactory.CreateClient(HttpClientName);
        });
    }
}