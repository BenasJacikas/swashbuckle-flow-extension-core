using Microsoft.AspNetCore.Mvc;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Controllers
{
    public class DynamicValueCapabilityController : Controller
    {
        [HttpGet]
        [Route("api/capability")]
        public DynamicValueLookupCapabilityAttribute Get 
        (
            [DynamicValueLookupCapability("file-picker", "id", "name", parameters: "test=static&test2={dynamic}")]
            string dynamicValue
        )
        {
            return null;
        }
    }
}