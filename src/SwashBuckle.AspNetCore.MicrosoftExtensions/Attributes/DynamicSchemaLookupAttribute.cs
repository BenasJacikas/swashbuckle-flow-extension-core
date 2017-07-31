using System;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{

    /// <summary>
    /// Extends swagger definition with vendor extension: x-ms-dynamic-schema
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter | AttributeTargets.Method, Inherited = false)]
    public sealed class DynamicSchemaLookupAttribute : Attribute
    {

        /// <summary>
        /// Parameter value to pass to lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)
        /// </summary>
        public string Parameters { get; }

        /// <summary>
        /// Lookup operation ID, use swagger operation ID of action to call
        /// </summary>
        public string LookupOperation { get; }

        /// <summary>
        /// JSON path, where schema class is residing (can't be empty)
        /// </summary>
        public string ValuePath { get; }

        /// <summary>Constructor</summary>
        /// <param name="lookupOperation">Operation ID of the operation that returns the schema, use swagger operation ID</param>
        /// <param name="valuePath"> JSON path where schema is residing (can't be empty)</param>
        /// <param name="parameters">Parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&amp;lookupOpParam2=hardcoded)</param>
        public DynamicSchemaLookupAttribute(string lookupOperation, string valuePath, string parameters = null)
        {
            LookupOperation = lookupOperation;
            Parameters = parameters;
            ValuePath = valuePath;
        }
    }
}