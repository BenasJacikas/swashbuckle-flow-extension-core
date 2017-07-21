using System;
using Newtonsoft.Json;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Filters;

namespace TestApi.Models
{
    public class MetdataAttributeClass
    {
        [JsonProperty("customName")]
        [Metadata("Friendly", "Description", VisibilityType.Advanced)]
        public string Name { get; }

        public MetdataAttributeClass(string name)
        {
            Name = name;
        }
    }
}