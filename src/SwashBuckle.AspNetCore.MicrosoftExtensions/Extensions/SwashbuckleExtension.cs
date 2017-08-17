using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.Filters;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Extensions
{
    /// <summary>
    /// Swagger generation opetions extensions
    /// </summary>
    public static class SwashbuckleExtension
    {
        /// <summary>
        /// Enables microsoft extension generation
        /// </summary>
        public static void GenerateMicrosoftExtensions(this SwaggerGenOptions options)
        {
            options.OperationFilter<OperationFilter>();
            options.SchemaFilter<SchemaFilter>();
        }

        /// <summary>
        /// Enables microsoft extension generation
        /// </summary>
        public static void GenerateMicrosoftExtensions(this SwaggerGenOptions options, FilePickerCapabilityModel filePicker)
        {
            options.OperationFilter<OperationFilter>();
            options.SchemaFilter<SchemaFilter>();
            options.DocumentFilter<CapabilityFilter>(filePicker);
        }
    }
}