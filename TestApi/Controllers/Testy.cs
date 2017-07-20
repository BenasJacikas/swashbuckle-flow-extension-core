using System;
using Newtonsoft.Json;
using SwashBuckle.MicrosoftExtensions.Attributes;
using SwashBuckle.MicrosoftExtensions.Filters;

namespace TestApi.Controllers
{
    public class Testy
    {
        [JsonProperty("ohNoes")]
        [Metadata("Friendly", "Description", VisibilityType.Advanced)]
        public string Name { get; }

        public Testy(String name)
        {
            Name = name;
        }
    }
}