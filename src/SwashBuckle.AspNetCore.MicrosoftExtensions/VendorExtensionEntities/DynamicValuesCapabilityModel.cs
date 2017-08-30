using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
   internal class DynamicValuesCapabilityModel
    {
        [JsonProperty("capability")]
        internal string Capability { get; }
        [JsonProperty("value-path")]
        internal string ValuePath { get; }
        [JsonProperty("value-title")]
        internal string ValueTitle { get; }
        [JsonProperty("parameters")]
        internal IDictionary<string, object> Parameters { get; }

        internal DynamicValuesCapabilityModel (string capability, string valuePath, string valueTitle, IDictionary<string, object> parameters)
        {
            Capability = capability;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            Parameters = parameters;
        }
    }
}