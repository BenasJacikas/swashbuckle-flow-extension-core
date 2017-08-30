using Newtonsoft.Json;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Models
{
    public class MetadataAttributeClass
    {
        [JsonProperty("customName")]
        [Metadata("Friendly", "Description", VisibilityType.Advanced)]
        public string Name { get; }

        public MetadataAttributeClass(string name)
        {
            Name = name;
        }
    }
}