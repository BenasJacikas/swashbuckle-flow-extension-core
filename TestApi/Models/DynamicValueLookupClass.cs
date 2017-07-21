using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Models
{
    public class DynamicValueLookupClass
    {
        [DynamicValueLookup("DynamicValuePropertyId", "id", "name", "objects", "param1={test}&param2=test")]
        public string LookupProperty { get; set; }
    }
}