using Polly;
using Polly.Extensions.Http;

namespace Funda.Assignment.Danilo.Infrastructure.PollyPolicies
{
    public static class RetryPolicies
    {
        public static IAsyncPolicy<HttpResponseMessage> GetPolicy()
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.TooManyRequests || msg.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                .Or<TaskCanceledException>()
                .WaitAndRetryAsync(6, retryAttempt => TimeSpan.FromSeconds(retryAttempt * 10));
        }
    }
}
