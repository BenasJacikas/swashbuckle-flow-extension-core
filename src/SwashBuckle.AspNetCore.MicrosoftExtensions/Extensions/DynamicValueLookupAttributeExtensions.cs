using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Helpers;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class DynamicValueLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerExtensions (this DynamicValueLookupAttribute attribute)
        {
            if(attribute is null)
                yield break;

            yield return new KeyValuePair<string, object>
            (
                Constants.XMsDynamicValueLookup,
                new DynamicValuesModel
                (
                    attribute.LookupOperation,
                    attribute.ValuePath,
                    attribute.ValueTitle,
                    attribute.ValueCollection,
                    ParameterParser.Parse(attribute.Parameters)
                )
            );

        }


    }
}