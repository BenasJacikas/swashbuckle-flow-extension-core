using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    internal class DynamicSchemaModel
    {
        [JsonProperty("operationId")]
        internal string OperationId { get; }
        [JsonProperty("value-path")]
        internal string ValuePath { get; }
        [JsonProperty("parameters")]
        internal IDictionary<string, object> Parameters { get; }

        internal DynamicSchemaModel(string operationId, string valuePath, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            Parameters = parameters;
        }
    }
}