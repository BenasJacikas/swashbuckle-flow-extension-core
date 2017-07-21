using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    public class DynamicSchemaModel
    {
        [JsonProperty("operationId")]
        public string OperationId { get; }
        [JsonProperty("value-path")]
        public string ValuePath { get; }
        [JsonProperty("parameters")]
        public IDictionary<string, object> Parameters { get; }

        public DynamicSchemaModel(string operationId, string valuePath, IDictionary<string, object> parameters)
        {
            OperationId = operationId;
            ValuePath = valuePath;
            Parameters = parameters;
        }
    }
}