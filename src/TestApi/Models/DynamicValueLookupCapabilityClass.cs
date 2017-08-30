using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Models
{
    public class DynamicValueLookupCapabilityClass
    {
        [DynamicValueLookupCapability("DynamicValuePropertyName", "id", "name", "param1={test}&param2=test&param3=true")]
        public string LookupProperty { get; set; }
    }
}