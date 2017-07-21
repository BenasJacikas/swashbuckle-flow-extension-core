using System.Reflection;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters
{
    public class SchemaFilter : ISchemaFilter
    {
        public void Apply(Schema model, SchemaFilterContext context)
        {
            if(model is null || context is null)
            {
                return;
            }

            var attribute = context.SystemType.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
            model.Extensions.AddRange(attribute.GetSwaggerExtensions());

            if(context.JsonContract is JsonObjectContract objectContract)
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