using Microsoft.Extensions.DependencyInjection;
using RestSharpAPIAutomation.Models;
using RestSharpAPIAutomation.Services;
using RestSharpAPIAutomation.TestBase;
using RestSharpAPIAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Tests
{
    [TestFixture]
    public class DeletePlaceTest : APITestBase
    {
        [Test]
        public async Task DeletePlace_ShoulDeletePlaceDetails()
        {
            var placeServices = serviceProvider.GetRequiredService<PlaceServices>();

            var addPlaceBody = TestDataLoader.Load<AddPlaceRequest>("AddPlace.json");

            var addPlaceResponse = await placeServices.AddPlace(addPlaceBody);
            Assert.That(addPlaceResponse.place_id, Is.Not.Null.Or.Empty);

            var placeId = addPlaceResponse.place_id;
            TestContext.WriteLine($"Place ID: {placeId}");

            var getPlacementResponse = await placeServices.GetPlace(placeId);

            Assert.That(getPlacementResponse, Is.Not.Null);

            var deletePlacementResponse = await placeServices.DeletePlace(placeId);
            Assert.That(deletePlacementResponse, Is.Not.Null);

        }
    }
}
