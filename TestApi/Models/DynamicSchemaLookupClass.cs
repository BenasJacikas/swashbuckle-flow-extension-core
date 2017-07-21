using System.Collections.Generic;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Models
{
    [DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
    public class DynamicSchemaLookupClass
    {
        [DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
        public IDictionary<string, object> LookupProperty { get; set; }
    }
}