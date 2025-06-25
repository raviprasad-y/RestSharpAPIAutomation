using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.Validators
{
    public static class ApiResponseValidator
    {
        /// <summary>
        /// Validates that the response has status code 200 OK and data is not null.
        /// </summary>
        public static void ShouldBeSuccess<T>(RestResponse<T> response)
        {
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK), "Expected 200 OK");
            Assert.That(response.Data, Is.Not.Null, "Response data should not be null");
        }

        /// <summary>
        /// Validates that the response has the expected status code.
        /// </summary>
        public static void ShouldHaveStatus<T>(RestResponse<T> response, HttpStatusCode expectedStatusCode)
        {
            Assert.That(response.StatusCode, Is.EqualTo(expectedStatusCode), $"Expected status code: {expectedStatusCode}");
        }

        /// <summary>
        /// Validates that the response content contains expected string.
        /// </summary>
        public static void ShouldContainText(RestResponse response, string expectedText)
        {
            Assert.That(response.Content, Does.Contain(expectedText), $"Expected response to contain: {expectedText}");
        }

        /// <summary>
        /// Validates that the response has non-null and non-empty content.
        /// </summary>
        public static void ShouldHaveContent(RestResponse response)
        {
            Assert.That(response.Content, Is.Not.Null.And.Not.Empty, "Response content should not be null or empty");
        }

        /// <summary>
        /// Validates that the response failed (not 2xx).
        /// </summary>
        public static void ShouldBeFailure<T>(RestResponse<T> response)
        {
            Assert.That((int)response.StatusCode, Is.GreaterThanOrEqualTo(400), "Expected failure status code (4xx or 5xx)");
        }

        /// <summary>
        /// Validates response header exists and contains expected value.
        /// </summary>
        public static void ShouldHaveHeader(RestResponse response, string headerName, string expectedValue)
        {
            var header = response.Headers.FirstOrDefault(h => h.Name?.ToString() == headerName);
            Assert.That(header, Is.Not.Null, $"Header '{headerName}' not found");
            Assert.That(header.Value?.ToString(), Does.Contain(expectedValue), $"Header '{headerName}' does not contain expected value: {expectedValue}");
        }

        /// <summary>
        /// Validates that response time is within acceptable limit.
        /// </summary>
        //public static void ShouldRespondWithin(RestResponse response, int milliseconds)
        //{
        //    Assert.That(response.ResponseTime.TotalMilliseconds, Is.LessThan(milliseconds), $"Expected response time < {milliseconds} ms");
        //}
        
    }
}
