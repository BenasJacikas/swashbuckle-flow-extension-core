using Microsoft.AspNetCore.Mvc;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using TestApi.Models;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    public class MetadataAttributeController : Controller
    {
        [HttpPost]
        [Metadata("FriendlyAction", "ActionDescription", VisibilityType.Important)]
        public MetdataAttributeClass Post([FromBody][Metadata("FriendlyParameter", "ParameterDescription")] string value)
        {
            return null;
        }
        
        [HttpPost]
        [Metadata(null, null, VisibilityType.Important)]
        [Route("/api/MetadataAttributeWithNullSummaryAndDescription")]
        public MetdataAttributeClass PostNull([FromBody][Metadata("FriendlyParameter", "ParameterDescription")] string value)
        {
            return null;
        }
    }
}