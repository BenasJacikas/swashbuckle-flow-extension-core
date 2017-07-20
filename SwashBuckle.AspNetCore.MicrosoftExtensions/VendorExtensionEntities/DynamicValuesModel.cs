using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.MicrosoftExtensions.VendorExtensionEntities
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
        public IDictionary<string, object> Parameters { get; }

        public DynamicValuesModel(string operationId, string valuePath, string valueTitle, string valueCollection, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            ValueCollection = valueCollection;
            Parameters = parameters;
        }
    }
}