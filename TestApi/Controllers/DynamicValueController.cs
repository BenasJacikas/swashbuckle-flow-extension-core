using Microsoft.AspNetCore.Mvc;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class DynamicValueController : Controller
    {
        [HttpGet]
        [Route("api/dynamic")]
        public DynamicValueLookupClass Get
        (
            [DynamicValueLookup("DynamicValueLookupId", "id", "name", parameters: "test=static&test2={dynamic}")]
            string dynamicValue
        )
        {
            return null;
        }
    }
}