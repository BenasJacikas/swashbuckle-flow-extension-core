using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestApi;
using Xunit;
using Xunit.Abstractions;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class DynamicValueLookupTests
    {
        
        private readonly HttpClient _client;
        private readonly ITestOutputHelper _logger;

        public DynamicValueLookupTests(ITestOutputHelper logger)
        {
            // Arrange
            var server = new TestServer
            (
                new WebHostBuilder().UseStartup<Startup>()
            );
            _client = server.CreateClient();
            _logger = logger;
        }

        [Fact]
        public async void ParameterValueLookup()
        {
            
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Paths["/api/dynamic"].Get.Parameters[0].VendorExtensions;
            
            Assert.NotNull(operationExtensions["x-ms-dynamic-values"]);
            dynamic dynamicValues = operationExtensions["x-ms-dynamic-values"];
            Assert.Equal("DynamicValueLookupId", (string) dynamicValues.operationId);
            Assert.Equal("id", (string) dynamicValues["value-path"]);
            Assert.Equal("name", (string) dynamicValues["value-title"]);
            Assert.Equal("static", (string) dynamicValues.parameters.test);
            Assert.Equal("dynamic", (string) dynamicValues.parameters.test2.parameter);

        }
    }
}