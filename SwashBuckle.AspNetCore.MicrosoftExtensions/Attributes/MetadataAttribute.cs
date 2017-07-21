using System;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Filters;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{
    /// <summary>
    /// Provides information about how to display this action,
    /// parameter, or model property within the Logic App designer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class MetadataAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the Metadata attribute using the information supplied
        /// </summary>
        /// <param name="summary">Name of the item as it will be shown in the Logic App designer.
        /// For actions, this controls how the operation id is generated (pascal-cased form of the name supplied)</param>
        /// <param name="description">Brief description of the item to display in the Swagger UI</param>
        /// <param name="visibility">Visibility of the item in the Logic App designer. Default is visible, Advanced requires the user to click a button to reveal, and Internal hides the item.</param>
        public MetadataAttribute
        (
            string summary = null,
            string description = null,
            VisibilityType visibility = VisibilityType.Default
        )
        {
            Summary = summary;
            Description = description;
            Visibility = visibility;
        }

        /// <summary>
        /// Gets or sets the name of the item as it will be shown in the Logic App designer.
        /// </summary>
        public string Summary { get; }
        
        /// <summary>
        /// Gets or sets a brief description of the item to display in the Swagger UI.
        /// </summary>
        public string Description { get; }
        
        /// <summary>
        /// Gets or sets the visibility of the item in the Logic App designer. Default is visible, Advanced requires the user to click a button to reveal, and Internal hides the item.
        /// </summary>
        public VisibilityType Visibility { get; }

    }
}