using Allure.Commons;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Allure.Core;
using RestSharp;
using RestSharpAPIAutomation.Config;
using RestSharpAPIAutomation.Core;
using RestSharpAPIAutomation.DependancyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAPIAutomation.TestBase
{
    [TestFixture]
    [AllureNUnit]
    public class APITestBase
    {
        protected ServiceProvider serviceProvider; 

        [OneTimeSetUp]
        public void Init()
        {
            Logger.InitLogger();
            serviceProvider = ServiceContainer.Configure();
            Logger.Info("Test suite started");
            Logger.Info($"Base URL: {ConfigurationReader.GetSectionValue("API", "BaseUrl")}");
            var testName = TestContext.CurrentContext.Test.MethodName;
        }

        [SetUp]
        public void SetTestMetadata()
        {
            var testName = TestContext.CurrentContext.Test.MethodName;

            AllureLifecycle.Instance.UpdateTestCase(x =>
            {
                x.name = testName;
                x.labels.Add(Label.Suite("API Automation Framework"));
                x.labels.Add(Label.SubSuite("CRUD Scenarios"));
                x.labels.Add(Label.Owner("Ravi"));
                x.labels.Add(Label.Severity(SeverityLevel.normal));
                x.description = $"Test method: {testName}";
            });
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
            Logger.Info("Test suite finished");
        }
    }
}
