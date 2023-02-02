using System.Net;
using Polly;

namespace Kantar.Syndicated.Orchestrator.ExternalServices.RetryPolicies;

public static class Policies
{
    public static IAsyncPolicy<HttpResponseMessage> CreateRetryWhenInternalServiceErrorPolicy()
    {
        return Policy<HttpResponseMessage>
            .HandleResult(response => response.StatusCode == HttpStatusCode.InternalServerError)
            .WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2), TimeSpan.FromSeconds(2) });
    }
}