using Newtonsoft.Json;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Models
{
    public class MetdataAttributeClass
    {
        [JsonProperty("customName")]
        [Metadata("Friendly", "Description", VisibilityType.Advanced)]
        public string Name { get; }

        public MetdataAttributeClass(string name)
        {
            Name = name;
        }
    }
}