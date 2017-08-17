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
            [DynamicValueLookupCapability("file-picker", "id", parameters: "isFolder=false")]
            string dynamicValue
        )
        {
            return null;
        }
    }
}