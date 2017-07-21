using Microsoft.AspNetCore.Mvc;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;

namespace TestApi.Controllers
{
    public class DynamicValueController : Controller
    {
        [HttpGet]
        [Route("api/dynamic")]
        public void Get
        (
            [DynamicValueLookup("DynamicValueLookupId", "id", "name", parameters: "test=static&test2={dynamic}")]
            string dynamicValue
        ) { }
    }
}