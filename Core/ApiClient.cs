using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
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
                BaseUrl = new Uri(Config.ConfigurationReader.GetSectionValue("API", "BaseUrl")),
                ThrowOnAnyError = false,
                MaxTimeout = 10000
            };
            client = new RestClient(options);
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request) where T : new()
        {
            Logger.Info($"[REQUEST] {request.Method} {request.Resource}");

            var response = await client.ExecuteAsync<T>(request);
            Logger.Info($"[RESPONSE] Status: {(int)response.StatusCode} {response.StatusCode}");
            Logger.Info($"Content: {response.Content}");
            if (!response.IsSuccessful)
            {
                Logger.Error($"❌ Request failed: {response.ErrorMessage}");
                throw new ApplicationException($"Request failed ({response.StatusCode}): {response.ErrorMessage}\nContent: {response.Content}");
            }
            return response.Data;
        }

        public void Dispose()
        {
            client?.Dispose();
        }

    }
}
