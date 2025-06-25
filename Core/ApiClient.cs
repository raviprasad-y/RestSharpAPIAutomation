using RestSharp;
using RestSharpAPIAutomation.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Core
{
    public class ApiClient : IDisposable
    {
        private readonly RestClient client;

        public ApiClient()
        {
            var options = new RestClientOptions
            {
                BaseUrl = new Uri(ConfigurationReader.GetSectionValue("API", "BaseUrl")),
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };
            client = new RestClient(options);
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            int maxRetries = ConfigurationReader.GetIntValue("API", "RetryCount");
            int delayBetweenRetries = ConfigurationReader.GetIntValue("API", "RetryDelayMs"); 
            int attempt = 0;

            while (attempt < maxRetries)
            {
                attempt++;
                Logger.Info($"🔁 Attempt {attempt}: {request.Method} {request.Resource}");

                var response = await client.ExecuteAsync<T>(request);
                Logger.Info($"[RESPONSE] Status: {(int)response.StatusCode} {response.StatusCode}");

                if (response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.Created)
                {
                    return response.Data;
                }
                if (attempt < maxRetries && IsTransientStatus(response.StatusCode))
                {
                    Logger.Warn($"Transient error received. Retrying after {delayBetweenRetries}ms...");
                    await Task.Delay(delayBetweenRetries);
                }
                else
                {
                    Logger.Error($"❌ Request failed after {attempt} attempts. Status: {response.StatusCode}");
                    throw new ApplicationException($"API call failed: {response.StatusCode}\n{response.Content}");
                }
            }
            throw new Exception("Unexpected retry exit");
        }

        private bool IsTransientStatus(HttpStatusCode status)
        {
            return status == HttpStatusCode.RequestTimeout ||      // 408
                   status == HttpStatusCode.InternalServerError || // 500
                   status == HttpStatusCode.BadGateway ||          // 502
                   status == HttpStatusCode.ServiceUnavailable ||  // 503
                   status == HttpStatusCode.GatewayTimeout;        // 504
        }
        public void Dispose()
        {
            client?.Dispose();
        }

    }
}
