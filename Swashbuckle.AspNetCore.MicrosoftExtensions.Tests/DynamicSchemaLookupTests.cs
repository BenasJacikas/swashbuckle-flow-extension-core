using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestApi;
using Xunit;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class DynamicSchemaLookupTests
    {
        private readonly HttpClient _client;

        public DynamicSchemaLookupTests()
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
            var operationExtensions = swaggerDoc.Paths["/api/schema"].Get.Parameters[0].VendorExtensions;

            dynamic dynamicValues = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicValues);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicValues.operationId);
            Assert.Equal("schema", (string) dynamicValues["value-path"]);
            Assert.Equal("test", (string) dynamicValues.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicValues.parameters.param2);
        }
        
        [Fact]
        public async void PropertyValueLookup()
        {
            
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Definitions["DynamicSchemaLookupClass"].Properties["lookupProperty"].Extensions;

            dynamic dynamicValues = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicValues);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicValues.operationId);
            Assert.Equal("schema", (string) dynamicValues["value-path"]);
            Assert.Equal("test", (string) dynamicValues.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicValues.parameters.param2);
        }
        
        [Fact]
        public async void ClassValueLookup()
        {
            
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Definitions["DynamicSchemaLookupClass"].Extensions;

            dynamic dynamicValues = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicValues);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicValues.operationId);
            Assert.Equal("schema", (string) dynamicValues["value-path"]);
            Assert.Equal("test", (string) dynamicValues.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicValues.parameters.param2);
        }
        
    }
}