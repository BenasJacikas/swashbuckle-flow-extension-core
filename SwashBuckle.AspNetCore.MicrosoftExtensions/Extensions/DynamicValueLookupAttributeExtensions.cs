using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
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
                    ParseParameters(attribute.Parameters)
                )
            );

        }

        private static Dictionary<string, object> ParseParameters(string s)
        {
            var parameters = QueryHelpers.ParseQuery(s);
            return parameters.Select(ParseParameter).ToDictionary(x => x.Key, x => x.Value);
        }

        private static KeyValuePair<string, object> ParseParameter(KeyValuePair<string, StringValues> parameter)
        {
            var matches = Regex.Match(parameter.Value, @"^{(.+)}$");
            if(matches.Success)
            {
                return new KeyValuePair<string, object>
                (
                    parameter.Key,
                    new Dictionary<string, string> {{Constants.Parameter, matches.Groups[1].Value}}
                );
            }
            return new KeyValuePair<string, object>(parameter.Key, parameter.Value[0]);
        }

    }
}