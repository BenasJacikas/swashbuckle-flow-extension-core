using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.Filters
{
    internal class CapabilityFilter : IDocumentFilter
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
                new Dictionary<string, object> {{Constants.FilePicker, m_filePickerCapability}}
            );
        }
    }
}