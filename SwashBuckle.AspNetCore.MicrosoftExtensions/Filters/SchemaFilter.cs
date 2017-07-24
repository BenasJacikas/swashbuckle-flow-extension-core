using System.Collections.Generic;
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

            model.Extensions.AddRange(GetClassExtensions(context));

            if(context.JsonContract is JsonObjectContract objectContract)
            {
                model.Properties.ExtendProperties(objectContract.Properties);
            }
        }

        private IEnumerable<KeyValuePair<string, object>> GetClassExtensions(SchemaFilterContext context)
        {
            var attribute = context.SystemType.GetTypeInfo().GetCustomAttribute<DynamicSchemaLookupAttribute>();
            return attribute.GetSwaggerExtensions();
        }
    }
}