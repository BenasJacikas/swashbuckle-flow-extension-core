using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Swagger;
using TestApi;
using TestApi.Controllers;
using Xunit;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class MetadataAttributeTests
    {
        private readonly HttpClient _client;

        public MetadataAttributeTests()
        {
            // Arrange
            var server = new TestServer
            (
                new WebHostBuilder().UseStartup<Startup>()
            );
            _client = server.CreateClient();
        }

        [Fact]
        public async void PropertyMetadata()
        {
            // Act
            var response = await _client.GetAsync("/swagger/v1/swagger.json");
            response.EnsureSuccessStatusCode();

            var swaggerDoc =
                JsonConvert.DeserializeObject<SwaggerDocument>(await response.Content.ReadAsStringAsync());

            var definitions = swaggerDoc.Definitions;

            // Assert
            var testy = definitions.First(x => x.Key == nameof(Testy)).Value;
            var testyProperty = testy.Properties.Single();
            Assert.Equal(testyProperty.Key, "ohNoes");
            Assert.Equal("advanced", testyProperty.Value.Extensions["x-ms-visibility"]);
            Assert.Equal("Friendly", testyProperty.Value.Extensions["x-ms-summary"]);
            Assert.Equal("Description", testyProperty.Value.Extensions["x-ms-description"]);
        }

        [Fact]
        public async void ActionMetadata()
        {
            var response = await _client.GetAsync("/swagger/v1/swagger.json");
            response.EnsureSuccessStatusCode();

            var responseString =
                JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

            var operation = responseString["paths"]["/api/Values"]["post"];

            Assert.Equal("important", operation["x-ms-visibility"]);
            Assert.Equal("FriendlyAction", operation["x-ms-summary"]);
            Assert.Equal("ActionDescription", operation["x-ms-description"]);
        }
        
        [Fact]
        public async void ActionParameterMetada()
        {
            var response = await _client.GetAsync("/swagger/v1/swagger.json");
            response.EnsureSuccessStatusCode();

            var responseString =
                JsonConvert.DeserializeObject<JObject>(await response.Content.ReadAsStringAsync());

            var parameter = responseString["paths"]["/api/Values"]["post"][0];
            
            Assert.Null(parameter["x-ms-visibility"]);
            Assert.Equal("FriendlyParameter", parameter["x-ms-summary"]);
            Assert.Equal("ActionDescription", parameter["x-ms-description"]);

        }
    }
}