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
        public async void ParameterSchemaLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Paths["/api/schema"].Get.Parameters[0].VendorExtensions;

            dynamic dynamicSchema = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicSchema);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicSchema.operationId);
            Assert.Equal("schema", (string) dynamicSchema["value-path"]);
            Assert.Equal("test", (string) dynamicSchema.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicSchema.parameters.param2);
        }
        
        [Fact]
        public async void PropertySchemaLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Definitions["DynamicSchemaLookupClass"].Properties["lookupProperty"].Extensions;

            dynamic dynamicSchema = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicSchema);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicSchema.operationId);
            Assert.Equal("schema", (string) dynamicSchema["value-path"]);
            Assert.Equal("test", (string) dynamicSchema.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicSchema.parameters.param2);
        }
        
        [Fact]
        public async void ClassSchemaLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Definitions["DynamicSchemaLookupClass"].Extensions;

            dynamic dynamicSchema = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicSchema);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicSchema.operationId);
            Assert.Equal("schema", (string) dynamicSchema["value-path"]);
            Assert.Equal("test", (string) dynamicSchema.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicSchema.parameters.param2);
        }

        [Fact]
        public async void OperationSchemaLookup()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Paths["/api/schema"].Get.VendorExtensions;

            dynamic dynamicSchema = operationExtensions["x-ms-dynamic-schema"];
            Assert.NotNull(dynamicSchema);
            Assert.Equal("DynamicSchemaOpId", (string) dynamicSchema.operationId);
            Assert.Equal("schema", (string) dynamicSchema["value-path"]);
            Assert.Equal("test", (string) dynamicSchema.parameters.param1.parameter);
            Assert.Equal("test", (string) dynamicSchema.parameters.param2);
        }
    }
}