using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters
{
    public class CapabilityFilter : IDocumentFilter
    {
        private readonly FilePickerCapabilityModel m_filePickerCapability;

        public CapabilityFilter (FilePickerCapabilityModel capability)
        {
            m_filePickerCapability = capability;
        }

        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            AddFilePickerCapabilityExtension(swaggerDoc);
        }

        private void AddFilePickerCapabilityExtension(SwaggerDocument swaggerDoc)
            {
            swaggerDoc.Extensions.Add
                (
                Constants.XMsCapabilities,
                m_filePickerCapability
                );
            }
    }
}