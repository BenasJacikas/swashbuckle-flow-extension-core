using System.Reflection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Extensions;

namespace SwashBuckle.MicrosoftExtensions.Filters
{
    public class SchemaFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            if (model is null || context is null)
            {
                return;
            }

            if (context.JsonContract is JsonObjectContract objectContract)
            {
                model.Properties.ExtendProperties(objectContract.Properties);
            }
        }
    }

    public enum VisibilityType
    {
        Default,
        Internal,
        Advanced,
        Important
    }
}