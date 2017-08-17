using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters
{
    internal class OperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if(operation is null || context is null)
                return;

            operation.Extensions.AddRange(GetOperationExtensions(context.ApiDescription));

            ApplyParametersMetadata(operation.Parameters, context.ApiDescription.ActionDescriptor.Parameters);
        }

        private static IEnumerable<KeyValuePair<string, object>> GetOperationExtensions(ApiDescription apiDescription)
        {
            var metadataAttribute = apiDescription.ActionAttributes().OfType<MetadataAttribute>().SingleOrDefault();
            var dynamicSchemaAttribute = apiDescription.ActionAttributes().OfType<DynamicSchemaLookupAttribute>().SingleOrDefault();

            var extensions = metadataAttribute.GetSwaggerExtensions();
            return extensions.Concat(dynamicSchemaAttribute.GetSwaggerExtensions());
        }

        private static void ApplyParametersMetadata
        (
            IEnumerable<IParameter> parameters,
            IList<ParameterDescriptor> parameterDescriptions
        )
        {
            if(parameters is null) 
                return;
            
            foreach (var operationParameter in parameters)
            {
                var parameterDescription = parameterDescriptions.FirstOrDefault(x => x.Name == operationParameter.Name);
                switch (parameterDescription)
                {
                    case ControllerParameterDescriptor controllerParameterDescriptor:
                        operationParameter.Extensions.AddRange(GetParameterExtensions(controllerParameterDescriptor.ParameterInfo));
                        break;
                    case ControllerBoundPropertyDescriptor controllerBoundPropertyDescriptor:
                        operationParameter.Extensions.AddRange(GetParameterExtensions(controllerBoundPropertyDescriptor.PropertyInfo));
                        break;
                    default:
                        continue;
                }
            }
        }

        private static IEnumerable<KeyValuePair<string, object>> GetParameterExtensions(ICustomAttributeProvider attributeProvider)
        {
            return GetValueLookupProperties(attributeProvider)
                .Concat(GetValueLookupCapabilityProperties(attributeProvider))
                .Concat(GetMetadataProperties(attributeProvider))
                .Concat(GetSchemaLookupProperties(attributeProvider));
        }

        private static IEnumerable<KeyValuePair<string, object>> GetValueLookupProperties(ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupAttribute), true).SingleOrDefault() as DynamicValueLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, object>> GetValueLookupCapabilityProperties (ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupCapabilityAttribute), true).SingleOrDefault() as DynamicValueLookupCapabilityAttribute;
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, object>> GetMetadataProperties(ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(MetadataAttribute), true).SingleOrDefault() as MetadataAttribute;
            return attribute.GetSwaggerExtensions();
        }

        private static IEnumerable<KeyValuePair<string, object>> GetSchemaLookupProperties(ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicSchemaLookupAttribute), true).SingleOrDefault() as DynamicSchemaLookupAttribute;
            return attribute.GetSwaggerExtensions();
        }
    }
}