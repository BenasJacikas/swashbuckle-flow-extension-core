using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestApi;
using Xunit;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class DynamicValueLookupCapabilityTests
    {
        private readonly HttpClient _client;

        public DynamicValueLookupCapabilityTests()
        {
            // Arrange
            var server = new TestServer
            (
                new WebHostBuilder().UseStartup<Startup>()
            );
            _client = server.CreateClient();
        }

        [Fact]
        public async void ParameterValueLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Paths["/api/capability"].Get.Parameters[0].VendorExtensions;

            Assert.NotNull(operationExtensions["x-ms-dynamic-values"]);
            dynamic dynamicValues = operationExtensions["x-ms-dynamic-values"];
            Assert.Equal("capabilityName", (string) dynamicValues.capability);
            Assert.Equal("id", (string) dynamicValues["value-path"]);
            Assert.Equal("name", (string) dynamicValues["value-title"]);
            Assert.Equal(true, (bool) dynamicValues.parameters.isFolder);
            Assert.Equal("static", (string) dynamicValues.parameters.test);
            Assert.Equal("dynamic", (string) dynamicValues.parameters.test2.parameter);
        }

        [Fact]
        public async void PropertyValueLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Definitions["DynamicValueLookupCapabilityClass"].Properties["lookupProperty"].Extensions;

            Assert.NotNull(operationExtensions["x-ms-dynamic-values"]);
            dynamic dynamicValues = operationExtensions["x-ms-dynamic-values"];
            Assert.Equal("DynamicValuePropertyName", (string) dynamicValues.capability);
            Assert.Equal("id", (string) dynamicValues["value-path"]);
            Assert.Equal("name", (string) dynamicValues["value-title"]);
            Assert.Equal("test", (string) dynamicValues.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicValues.parameters.param2);
            Assert.Equal(true, (bool) dynamicValues.parameters.param3);
            }
    }
}