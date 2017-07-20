using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Filters;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPost]
        [Metadata("FriendlyAction", "ActionDescription", VisibilityType.Important)]
        public void Post([FromBody][Metadata("FriendlyParameter", "ParameterDescription")] string value)
        {
        }
    }
}