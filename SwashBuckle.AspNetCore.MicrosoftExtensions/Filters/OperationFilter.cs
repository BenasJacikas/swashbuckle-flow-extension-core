using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters
{
    public class OperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if(operation is null || context is null)
                return;
            
            var metadataAttribute = context.ApiDescription.ActionAttributes().OfType<MetadataAttribute>().SingleOrDefault();

            operation.Extensions.AddRange(metadataAttribute.GetMetadataExtensions());
            
            ApplyPropertiesMetadata(operation.Parameters, context.ApiDescription.ActionDescriptor.Parameters);
        }

        private static void ApplyPropertiesMetadata
        (
            IEnumerable<IParameter> parameters,
            IList<ParameterDescriptor> parameterDescriptions
        )
        {
            if(parameters is null) 
                return;
            
            foreach (var operationParameter in parameters)
            {
                var parameterDescription =
                    parameterDescriptions.FirstOrDefault(x =>
                        x.Name == operationParameter.Name);
                switch (parameterDescription)
                {
                    case ControllerParameterDescriptor controllerParameterDescriptor:
                        AddMetadataProperties(operationParameter, controllerParameterDescriptor.ParameterInfo);
                        AddValueLookupProperties(operationParameter, controllerParameterDescriptor.ParameterInfo);
                        AddSchemaLookupProperties(operationParameter, controllerParameterDescriptor.ParameterInfo);
                        break;
                    case ControllerBoundPropertyDescriptor controllerBoundPropertyDescriptor:
                        AddMetadataProperties(operationParameter, controllerBoundPropertyDescriptor.PropertyInfo);
                        AddValueLookupProperties(operationParameter, controllerBoundPropertyDescriptor.PropertyInfo);
                        AddSchemaLookupProperties(operationParameter, controllerBoundPropertyDescriptor.PropertyInfo);
                        break;
                    default: continue;
                }
            }
        }

        private static void AddValueLookupProperties(IParameter parameter, ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicValueLookupAttribute), true).SingleOrDefault() as DynamicValueLookupAttribute;
            var extensions = attribute.GetSwaggerExtensions();
            parameter.Extensions.AddRange(extensions);
        }

        private static void AddMetadataProperties(IParameter parameter, ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(MetadataAttribute), true).SingleOrDefault() as MetadataAttribute;
            var extensions = attribute.GetMetadataExtensions();
            parameter.Extensions.AddRange(extensions);
        }

        private static void AddSchemaLookupProperties(IParameter parameter, ICustomAttributeProvider attributeProvider)
        {
            var attribute = attributeProvider.GetCustomAttributes(typeof(DynamicSchemaLookupAttribute), true).SingleOrDefault() as DynamicSchemaLookupAttribute;
            var extensions = attribute.GetSwaggerExtensions();
            parameter.Extensions.AddRange(extensions);
        }
    }
}