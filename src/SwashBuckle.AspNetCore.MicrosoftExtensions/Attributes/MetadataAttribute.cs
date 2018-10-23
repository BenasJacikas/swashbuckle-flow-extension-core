using System;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{
    /// <summary>
    /// Provides metadata of display options
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Method)]
    public sealed class MetadataAttribute : Attribute
    {
        /// <summary>
        /// Display name
        /// </summary>
        public string Summary { get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Visibility option for ms flow/logic app designer
        /// </summary>
        public VisibilityType Visibility { get; }

        /// <param name="summary">Display name</param>
        /// <param name="description">Description</param>
        /// <param name="visibility">Visibility option for ms flow/logic app designer</param>
        public MetadataAttribute
        (
            string summary = null,
            string description = null,
            VisibilityType visibility = VisibilityType.None
        )
        {
            Summary = summary;
            Description = description;
            Visibility = visibility;
        }
    }
}