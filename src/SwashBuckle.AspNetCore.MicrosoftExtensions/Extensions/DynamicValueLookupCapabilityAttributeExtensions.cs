using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Helpers;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class DynamicValueLookupCapabilityAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerExtensions(this DynamicValueLookupCapabilityAttribute attribute)
        {
            if (attribute is null)
                yield break;

            yield return new KeyValuePair<string, object>
            (
                Constants.XMsDynamicValueLookup,
                new DynamicValuesCapabilityModel
                (
                    attribute.Capability,
                    attribute.ValuePath,
                    attribute.ValueTitle,
                    ParameterParser.Parse(attribute.Parameters)
                )
            );
        }
    }
}