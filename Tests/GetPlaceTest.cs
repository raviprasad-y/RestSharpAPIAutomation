using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using RestSharpAPIAutomation.Models;
using RestSharpAPIAutomation.Services;
using RestSharpAPIAutomation.TestBase;
using RestSharpAPIAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Tests
{
    [TestFixture]
    public class GetPlaceTest: APITestBase
    {
        [Test]
        public async Task GetPlace_ShouldReturnPlaceDetails()
        {
            var placeServices = serviceProvider.GetRequiredService<PlaceServices>();

            var addPlaceBody = TestDataLoader.Load<AddPlaceRequest>("AddPlace.json");
            var addPlaceResponse = await placeServices.AddPlace(addPlaceBody);
            Assert.That(addPlaceResponse.place_id, Is.Not.Null.Or.Empty);

            var placeId = addPlaceResponse.place_id;
            TestContext.WriteLine($"Place ID: {placeId}");

            var getPlacementResponse = await placeServices.GetPlace(placeId);
            
            Assert.That(getPlacementResponse, Is.Not.Null);
            Assert.That(getPlacementResponse.name, Is.EqualTo(addPlaceBody.name));
            Assert.That(getPlacementResponse.address, Is.EqualTo(addPlaceBody.address));
            Assert.That(getPlacementResponse.language, Is.EqualTo(addPlaceBody.language));
        }
    }
}
