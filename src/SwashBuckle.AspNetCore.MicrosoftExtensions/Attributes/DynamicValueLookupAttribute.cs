using System;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{

    /// <summary>
    /// Extends swagger definition with vendor extension: x-ms-dynamic-values
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class DynamicValueLookupAttribute : Attribute
    {
        /// <summary>
        /// Gets the parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </summary>
        public string Parameters { get; }

        /// <summary>
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </summary>
        public string LookupOperation { get; }

        /// <summary>
        /// Backend value path  within object for further use.
        /// </summary>
        public string ValuePath { get; }

        /// <summary>
        /// Path to array where values are residing, if left empty base object will be parsed as array
        /// </summary>
        public string ValueCollection { get; }

        /// <summary>
        /// User facing value path, these values will show up for user to choose.
        /// </summary>
        public string ValueTitle { get; }

        /// <param name="lookupOperation">
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </param>
        /// <param name="valuePath">
        /// Backend value path  within object for further use.
        /// </param>
        /// <param name="valueTitle">
        /// User facing value path, these values will show up for user to choose.
        /// </param>
        /// <param name="valueCollection">
        /// Path to array where values are residing, if left empty base object will be parsed as array
        /// </param>
        /// <param name="parameters">
        /// Gets the parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </param>
        public DynamicValueLookupAttribute(string lookupOperation, string valuePath, string valueTitle, string valueCollection = null, string parameters = null)
        {
            LookupOperation = lookupOperation;
            Parameters = parameters;
            ValueCollection = valueCollection;
            ValuePath = valuePath;
            ValueTitle = valueTitle;
        }

    }
}