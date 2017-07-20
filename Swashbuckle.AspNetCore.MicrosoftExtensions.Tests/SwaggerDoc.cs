using System.Collections.Generic;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Swashbuckle.AspNetCore.MicrosoftExtensions.Tests
{
    public class SwaggerDocument
    {
        public IDictionary<string, Schema> Definitions;
        public Info Info;
        public IDictionary<string, Parameter> Parameters;
        public IDictionary<string, PathItem> Paths;
        public readonly string Swagger;
        public Dictionary<string, object> VendorExtensions;
    }

    public class Info
    {
        public string Title;
        public Dictionary<string, object> VendorExtensions;
        public string Version;
    }

    public class Parameter
    {
        public string Name;
        public string In;
        public string Type;
        public Dictionary<string, object> VendorExtensions;
    }

    public class PathItem
    {
        public Operation Get;
        public Dictionary<string, object> VendorExtensions;
    }

    public class Operation
    {
        public IList<Parameter> Parameters;
        public IDictionary<string, Response> Responses;
    }

    public class Response
    {
        public string Description;
        public Schema Schema;
    }
}