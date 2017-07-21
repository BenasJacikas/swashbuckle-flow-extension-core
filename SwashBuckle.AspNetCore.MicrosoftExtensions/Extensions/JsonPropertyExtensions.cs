using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class JsonPropertyExtensions
    {
        internal static void ExtendProperties(this IDictionary<string, Schema> schemaProperties, JsonPropertyCollection jsonProperties)
        {
            foreach (var schemaProperty in schemaProperties)
            {
                var jsonProperty = jsonProperties.FirstOrDefault(x => x.PropertyName == schemaProperty.Key);
                schemaProperty.Value.ExtendProperty(jsonProperty);
            }
        }

        private static void ExtendProperty (this Schema schema, JsonProperty jsonProperty)
        {
            schema.Extensions.AddRange(GetMetadataExtensions(jsonProperty.AttributeProvider));
        }
        
        private static IEnumerable<KeyValuePair<string, object>> GetMetadataExtensions(IAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetAttributes(typeof(MetadataAttribute), false).Single() as MetadataAttribute;

            return attribute.GetMetadataExtensions();
        }

        
    }
}