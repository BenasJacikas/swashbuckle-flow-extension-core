using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class DynamicSchemaController
    {
        [HttpGet]
        [Route("api/schema")]
        [DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
        public DynamicSchemaLookupClass Get
        (
            [DynamicSchemaLookup("DynamicSchemaOpId", "schema", "param1={test}&param2=test")]
            IDictionary<string, object> param
        )
        {
            return null;
        }
    }
}