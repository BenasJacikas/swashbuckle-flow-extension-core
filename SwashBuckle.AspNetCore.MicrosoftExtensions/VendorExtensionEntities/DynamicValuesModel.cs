using System.Collections.Generic;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    public class DynamicValuesModel
    {
        [JsonProperty("operationId")]
        public string OperationId { get; }
        [JsonProperty("value-path")]
        public string ValuePath { get; }
        [JsonProperty("value-title")]
        public string ValueTitle { get; }
        [JsonProperty("value-collection")]
        public string ValueCollection { get; }
        [JsonProperty("parameters")]
        public Dictionary<string, object> Parameters { get; }

        public DynamicValuesModel(string operationId, string valuePath, string valueTitle, string valueCollection, Dictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            ValueCollection = valueCollection;
            Parameters = parameters;
        }
    }
}