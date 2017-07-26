using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    internal class DynamicValuesModel
    {
        [JsonProperty("operationId")]
        internal string OperationId { get; }
        [JsonProperty("value-path")]
        internal string ValuePath { get; }
        [JsonProperty("value-title")]
        internal string ValueTitle { get; }
        [JsonProperty("value-collection")]
        internal string ValueCollection { get; }
        [JsonProperty("parameters")]
        internal IDictionary<string, object> Parameters { get; }

        internal DynamicValuesModel(string operationId, string valuePath, string valueTitle, string valueCollection, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            ValueCollection = valueCollection;
            Parameters = parameters;
        }
    }
}