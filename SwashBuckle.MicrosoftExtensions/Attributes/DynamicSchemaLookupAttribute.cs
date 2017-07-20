using System;

namespace SwashBuckle.MicrosoftExtensions.Attributes
{

    /// <summary>
    /// Provides a mechanism to emit the x-ms-dynamic-schema vendor extension for a decorated parameter or method
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Parameter, Inherited = false)]
    public sealed class DynamicSchemaLookupAttribute : Attribute
    {

        /// <summary>
        /// Gets or sets the parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&lookupOpParam2=hardcoded)
        /// </summary>
        public string Parameters { get; }

        /// <summary>
        /// Gets or sets the operation Id of the operation that returns the schema current class.
        /// If you use the Metadata attribute on the lookup operation, use a friendly name without
        /// spaces and then use the EXACT same name for this value.
        /// </summary>
        public string LookupOperation { get; }

        /// <summary>
        /// Gets or sets the name of the property within the lookup operation's output that
        /// contains the schema that will be used.
        /// </summary>
        public string ValuePath { get; }

        /// <summary>
        /// Initializes a new instance of the DynamicSchemaLookup attribute using the information supplied
        /// </summary>
        /// <param name="lookupOperation">Operation Id of the operation that returns the schema current class.
        /// If you use the Metadata attribute on the lookup operation, use a friendly name without
        /// spaces and then use the EXACT same name for this value.</param>
        /// <param name="valuePath">Name of the property within the lookup operation's output that
        /// contains the schema that will be used.</param>
        /// <param name="parameters">Parameter values to pass to the lookup operation
        /// (e.g., lookupOpParam={paramNameFromThisOperation}&lookupOpParam2=hardcoded)</param>
        public DynamicSchemaLookupAttribute(string lookupOperation, string valuePath, string parameters = null)
        {
            LookupOperation = lookupOperation;
            Parameters = parameters;
            ValuePath = valuePath;
        }
    }
}