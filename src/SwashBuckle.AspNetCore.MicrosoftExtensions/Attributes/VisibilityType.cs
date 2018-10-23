namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Attributes
{
    /// <summary>
    /// Visibility options for flow/logic app designer
    /// </summary>
    public enum VisibilityType
    {
        /// <summary>
        /// Visible
        /// </summary>
        None,
        /// <summary>
        /// Hidden in designer, can only be used by backend
        /// </summary>
        Internal,
        /// <summary>
        /// Visible when button is pressed
        /// </summary>
        Advanced,
        /// <summary>
        /// Prioritized and visible
        /// </summary>
        Important
    }
}