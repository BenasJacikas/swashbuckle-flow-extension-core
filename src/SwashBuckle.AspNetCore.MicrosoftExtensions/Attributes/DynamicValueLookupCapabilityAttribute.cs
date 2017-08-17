using System;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class DynamicValueLookupCapabilityAttribute : Attribute
    {
        public string Capability { get; }
        public string ValuePath { get; }
        public string ValueTitle { get; }
        public string Parameters { get; }

        public DynamicValueLookupCapabilityAttribute(string capability, string valuePath, string valueTitle = null, string parameters = null)
        {
            Capability = capability;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            Parameters = parameters;
        }
    }
}