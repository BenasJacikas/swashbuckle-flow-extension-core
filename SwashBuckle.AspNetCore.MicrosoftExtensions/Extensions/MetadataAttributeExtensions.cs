using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class MetadataAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetMetadataExtensions(this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;
            
            yield return new KeyValuePair<string, object>(Constants.XMsVisibility, attribute.Visibility.ToString().ToLowerInvariant());
            yield return new KeyValuePair<string, object>(Constants.XMsSummary, attribute.Summary);
            yield return new KeyValuePair<string, object>(Constants.XMsDescription, attribute.Description);
        }
    }
}