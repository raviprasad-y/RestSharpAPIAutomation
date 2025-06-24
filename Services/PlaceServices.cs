using RestSharp;
using RestSharpAPIAutomation.Core;
using RestSharpAPIAutomation.Models;
using RestSharpAPIAutomation.Config;

namespace RestSharpAPIAutomation.Services
{
    public class PlaceServices
    {
        private readonly ApiClient _apiClient;
        private readonly string _apiKey = ConfigurationReader.GetSectionValue("API", "key");

        public PlaceServices(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<AddPlaceResponse> AddPlace(AddPlaceRequest requestBody)
        {
            Logger.Info("▶ Calling AddPlace API...");
            var request = new RestRequest("/maps/api/place/add/json", Method.Post);
            request.AddQueryParameter("key", _apiKey);
            request.AddJsonBody(requestBody);
            return await _apiClient.ExecuteAsync<AddPlaceResponse>(request);
        }

        public async Task<GetPlaceResponse> GetPlace(string placeId)
        {
            Logger.Info("▶ Calling GetPlace API...");
            var request = new RestRequest("/maps/api/place/get/json", Method.Get);
            request.AddQueryParameter("key", _apiKey);
            request.AddQueryParameter("place_id", placeId);
            return await _apiClient.ExecuteAsync<GetPlaceResponse>(request);
        }

        public async Task<PutPlaceResponse> UpdatePlace(PutPlaceRequest requestBody)
        {
            Logger.Info("▶ Calling PutPlace API...");
            var request = new RestRequest("/maps/api/place/update/json", Method.Put);
            request.AddJsonBody(requestBody);
            return await _apiClient.ExecuteAsync<PutPlaceResponse>(request);
        }

        public async Task<DeletePlaceResponse> DeletePlace(string placeId)
        {
            Logger.Info("▶ Calling DeletePlace API...");
            var request = new RestRequest("/maps/api/place/delete/json", Method.Post);
            request.AddQueryParameter("key", _apiKey);
            request.AddJsonBody(new { place_id = placeId });
            return await _apiClient.ExecuteAsync<DeletePlaceResponse>(request);
        }
    }
}
