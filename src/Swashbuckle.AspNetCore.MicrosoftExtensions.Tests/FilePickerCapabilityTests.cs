using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TestApi;
using Xunit;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class FilePickerCapabilityTests
    {
        private readonly HttpClient _client;

        public FilePickerCapabilityTests()
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
            dynamic dynamicSchemaCapabilitiesSection = swaggerDoc.VendorExtensions["x-ms-capabilities"];
            dynamic dynamicSchema = dynamicSchemaCapabilitiesSection["file-picker"];

            Assert.NotNull(dynamicSchema);
            Assert.Equal("InitialOperation", (string) dynamicSchema.open["operationId"]);
            Assert.Equal("BrowsingOperation", (string) dynamicSchema.browse["operationId"]);
            Assert.Equal("Id", (string) dynamicSchema.browse.parameters.Id["value-property"]);
            Assert.Equal("Name", (string) dynamicSchema["value-title"]);
            Assert.Equal("IsFolder", (string) dynamicSchema["value-folder-property"]);
            Assert.Equal("MediaType", (string) dynamicSchema["value-media-property"]);
        }
    }
}