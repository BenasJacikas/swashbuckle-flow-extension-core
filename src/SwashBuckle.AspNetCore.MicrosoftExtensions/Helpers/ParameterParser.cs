using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Helpers
{
    internal class ParameterParser
    {
        internal static IDictionary<string, object> Parse(string s)
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

            // parse true/false values as bools
            switch (parameter.Value[0])
            {
                case "true":
                    return new KeyValuePair<string, object>(parameter.Key, true);
                case "false":
                    return new KeyValuePair<string, object>(parameter.Key, false);
                default:
                    return new KeyValuePair<string, object>(parameter.Key, parameter.Value[0]);
            }
        }
    }
}