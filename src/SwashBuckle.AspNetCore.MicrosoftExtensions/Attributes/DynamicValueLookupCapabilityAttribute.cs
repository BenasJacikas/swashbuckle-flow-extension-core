using System;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{
    /// <summary>
    /// Extends swagger definition with vendor extension: x-ms-dynamic-values
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class DynamicValueLookupCapabilityAttribute : Attribute
    {
        /// <summary>
        /// Capability name, uses operations within capability to get value.
        /// </summary>
        public string Capability { get; }

        /// <summary>
        /// Backend value path  within object for further use.
        /// </summary>
        public string ValuePath { get; }

        /// <summary>
        /// User facing value path, these values will show up for user to choose.
        /// </summary>
        public string ValueTitle { get; }

        /// <summary>
        /// Parameter value to pass to capability
        /// (e.g., capabilityOpParam={paramNameFromThisOperation}&amp;capabilityOpParam2=hardcoded)
        /// </summary>
        public string Parameters { get; }

        /// <param name="capability">
        /// Capability name, uses operations within capability to get value.
        /// </param>
        /// <param name="valuePath">
        /// Backend value path  within object for further use.
        /// </param>
        /// <param name="valueTitle">
        /// User facing value path, these values will show up for user to choose.
        /// </param>
        /// <param name="parameters">
        /// Parameter value to pass to capability
        /// (e.g., capabilityOpParam={paramNameFromThisOperation}&amp;capabilityOpParam2=hardcoded)
        /// </param>
        public DynamicValueLookupCapabilityAttribute (string capability, string valuePath, string valueTitle = null, string parameters = null)
        {
            Capability = capability;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
            Parameters = parameters;
        }
    }
}