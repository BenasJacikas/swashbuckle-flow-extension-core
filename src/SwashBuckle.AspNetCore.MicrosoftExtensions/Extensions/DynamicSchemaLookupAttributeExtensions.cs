using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Helpers;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class DynamicSchemaLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerExtensions (this DynamicSchemaLookupAttribute attribute)
        {
            if(attribute is null)
                yield break;

            yield return new KeyValuePair<string, object>
            (
                Constants.XMsDynamicSchemaLookup,
                new DynamicSchemaModel(attribute.LookupOperation, attribute.ValuePath, ParameterParser.Parse(attribute.Parameters))
            );
        }
    }
}