using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public static class ClientExtensions
    {
        public static async Task<SwaggerDocument> GetSwaggerDocument(this HttpClient client)
        {
            var response = await client.GetAsync("/swagger/v1/swagger.json");
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<SwaggerDocument>(await response.Content.ReadAsStringAsync());
        }
    }
}