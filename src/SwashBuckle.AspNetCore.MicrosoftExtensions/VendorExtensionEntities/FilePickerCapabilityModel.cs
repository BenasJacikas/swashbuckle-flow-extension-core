using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    public class FilePickerCapabilityModel
    {
        [JsonProperty("open")]
        public FilePickerOperationModel Open { get; set; }

        [JsonProperty("browse")]
        public FilePickerOperationModel Browse { get; set; }

        [JsonProperty("value-title")]
        public string ValueTitle { get; set; }

        [JsonProperty("value-folder-property")]
        public string ValueFolderProperty { get; set; }

        [JsonProperty("value-media-property")]
        public string ValueMediaProperty { get; set; }

        /// <summary>
        /// Initializes a new instance of FilePickerCapability with information supplied
        /// </summary>
        /// <param name="open">This operation which will be called when you initially when you start
        /// picking folder/file</param>
        /// <param name="browse">This operation will be called when you browse through folders</param>
        /// <param name="valueTitle">Value from either of operations (Open or Browse) output
        /// which will be used</param>
        /// <param name="valueFolderProperty">Value from either of operations (Open or Browse) output
        /// used to determine whether the output is a folder or a file</param>
        /// <param name="valueMediaProperty">Value from either of operations (Open or Browse) output
        /// used to determine file type (.zip, .txt, etc.)</param>
        public FilePickerCapabilityModel
        (
            FilePickerOperationModel open,
            FilePickerOperationModel browse,
            string valueTitle,
            string valueFolderProperty,
            string valueMediaProperty
        )
        {
            Open = open;
            //remove parameters from open, they need to be in x-ms-dynamic-values
            Open.Parameters = null;
            Browse = browse;
            ValueTitle = valueTitle;
            ValueFolderProperty = valueFolderProperty;
            ValueMediaProperty = valueMediaProperty;
        }
    }
}