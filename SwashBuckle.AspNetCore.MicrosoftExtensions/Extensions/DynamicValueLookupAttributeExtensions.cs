using System.Collections.Generic;
using SwashBuckle.MicrosoftExtensions.Attributes;

namespace SwashBuckle.MicrosoftExtensions.Extensions
{
    internal static class DynamicValueLookupAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerExtensions (this DynamicValueLookupAttribute attribute)
        {
            if(attribute is null)
                yield break;
            
        }
    }
}