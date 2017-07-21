using System.Linq;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using TestApi;
using TestApi.Models;
using Xunit;
using Xunit.Abstractions;

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
            var swaggerDoc = await _client.GetSwaggerDocument();
            var definitions = swaggerDoc.Definitions;

            // Assert
            var testy = definitions.First(x => x.Key == nameof(MetdataAttributeClass)).Value;
            var testyProperty = testy.Properties.Single();
            Assert.Equal(testyProperty.Key, "customName");
            Assert.Equal("advanced", testyProperty.Value.Extensions["x-ms-visibility"]);
            Assert.Equal("Friendly", testyProperty.Value.Extensions["x-ms-summary"]);
            Assert.Equal("Description", testyProperty.Value.Extensions["x-ms-description"]);
        }

        [Fact]
        public async void ActionMetadata()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var operationExtensions = swaggerDoc.Paths["/api/MetadataAttribute"].Post.VendorExtensions;

            Assert.Equal("important", operationExtensions["x-ms-visibility"]);
            Assert.Equal("FriendlyAction", operationExtensions["x-ms-summary"]);
            Assert.Equal("ActionDescription", operationExtensions["x-ms-description"]);
        }
        
        [Fact]
        public async void ActionParameterMetada()
        {
            var swaggerDoc = await _client.GetSwaggerDocument();
            var parameterExtensions = swaggerDoc.Paths["/api/MetadataAttribute"].Post.Parameters[0].VendorExtensions;
            
            //TODO:
            //Assert.Null(parameterExtensions["x-ms-visibility"]);
            Assert.Equal("FriendlyParameter", parameterExtensions["x-ms-summary"]);
            Assert.Equal("ParameterDescription", parameterExtensions["x-ms-description"]);

        }
    }
}