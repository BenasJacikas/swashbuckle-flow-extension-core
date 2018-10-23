using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    internal static class MetadataAttributeExtensions
    {
        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerExtensions(this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;
            
            if (attribute.Visibility != VisibilityType.Default)
                yield return new KeyValuePair<string, object>(Constants.XMsVisibility, attribute.Visibility.ToString().ToLowerInvariant());
            if (attribute.Summary != null)
                yield return new KeyValuePair<string, object>(Constants.XMsSummary, attribute.Summary);
            if (attribute.Description != null)
                yield return new KeyValuePair<string, object>(Constants.Description, attribute.Description);
        }

        internal static IEnumerable<KeyValuePair<string, object>> GetSwaggerOperationExtensions (this MetadataAttribute attribute)
        {
            if (attribute is null)
                yield break;

            if (attribute.Visibility != VisibilityType.Default)
                yield return new KeyValuePair<string, object>(Constants.XMsVisibility, attribute.Visibility.ToString().ToLowerInvariant());
            if (attribute.Summary != null)
                yield return new KeyValuePair<string, object>(Constants.Summary, attribute.Summary);
            if (attribute.Description != null)
                yield return new KeyValuePair<string, object>(Constants.Description, attribute.Description);
        }
    }
}