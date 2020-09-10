using Microsoft.Extensions.DependencyInjection;
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
        /// <param name="filePicker">File picker capability used for microsoft extension generation</param>
        public static void GenerateMicrosoftExtensions(this SwaggerGenOptions options, FilePickerCapabilityModel filePicker = null)
        {
            options.OperationFilter<OperationFilter>();
            options.SchemaFilter<SchemaFilter>();

            if (filePicker != null)
                options.DocumentFilter<CapabilityFilter>(filePicker);
        }
    }
}