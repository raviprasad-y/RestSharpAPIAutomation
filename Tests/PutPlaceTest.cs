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
    public class PutPlaceTest : APITestBase
    {
        [Test]
        public async Task PutPlace_ShoulUpdatePlaceDetails()
        {
            var placeServices = serviceProvider.GetRequiredService<PlaceServices>();

            var addPlaceBody = TestDataLoader.Load<AddPlaceRequest>("AddPlace.json");

            var addPlaceResponse = await placeServices.AddPlace(addPlaceBody);
            Assert.That(addPlaceResponse.place_id, Is.Not.Null.Or.Empty);

            var placeId = addPlaceResponse.place_id;
            TestContext.WriteLine($"Place ID: {placeId}");

            var getPlacementResponse = await placeServices.GetPlace(placeId);

            Assert.That(getPlacementResponse, Is.Not.Null);

            var body = TestDataLoader.Load<PutPlaceRequest>("PutPlace.json");

            var putPlaceBody = new RequestBuilder<PutPlaceRequest>(body)
                .With(x => x.place_id = placeId)
                .Build();
            var putPlaceResponse = await placeServices.UpdatePlace(putPlaceBody);
            Assert.That(putPlaceResponse.msg, Is.Not.Null.Or.Empty);

            getPlacementResponse = await placeServices.GetPlace(placeId);

            Assert.That(getPlacementResponse, Is.Not.Null);
            Assert.That(getPlacementResponse.address, Is.EqualTo(putPlaceBody.address));


        }
    }
}
