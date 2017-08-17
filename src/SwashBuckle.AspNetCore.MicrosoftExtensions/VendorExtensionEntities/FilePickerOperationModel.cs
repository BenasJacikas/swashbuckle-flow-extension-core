using System.Collections.Generic;
using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    public class FilePickerOperationModel
    {
        [JsonProperty("operation-id")]
        public string OperationId { get; }

        [JsonProperty("parameters")]
        public Dictionary<string, FilePickerParameterValue> Parameters { get; }

        /// <summary>
        /// Initializes a new instance of file picker operation with given parameters
        /// </summary>
        /// <param name="operationId">Id of operation</param>
        /// <param name="parameters">Parameter name and value pair</param>
        public FilePickerOperationModel(string operationId, Dictionary<string, string> parameters)
        {
            //no operation - dont create parameters
            if (string.IsNullOrEmpty(operationId))
                return;

            OperationId = operationId;
            if (parameters == null)
                return;
            Parameters = new Dictionary<string, FilePickerParameterValue>();
            foreach (var param in parameters)
            {
                Parameters.Add(param.Key, new FilePickerParameterValue(param.Value));
            }
        }
    }

    public class FilePickerParameterValue
    {
        [JsonProperty("value-property")]
        public string Value { get; }

        public FilePickerParameterValue(string value)
        {
            Value = value;
        }
    }
}