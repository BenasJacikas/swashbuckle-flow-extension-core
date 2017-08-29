using Newtonsoft.Json;

namespace SwashBuckle.AspNetCore.MicrosoftExtensions.VendorExtensionEntities
{
    /// <summary>
    /// Used to create swagger definition with vendor extension: x-ms-capabilities
    /// </summary>
    public class FilePickerCapabilityModel
    {
        /// <summary>
        /// Operation which will be called when you initially start picking folder/file
        /// </summary>
        [JsonProperty("open")]
        public FilePickerOperationModel Open { get; }

        /// <summary>
        /// Operation will be called when you browse through folders
        /// </summary>
        [JsonProperty("browse")]
        public FilePickerOperationModel Browse { get; }

        /// <summary>
        /// User facing value path, these values will show up for user to choose.
        /// </summary>
        [JsonProperty("value-title")]
        public string ValueTitle { get; }

        /// <summary>
        /// Backend value from either of operations (Open or Browse) output
        /// used to determine whether the output is a folder or a file
        /// Backend value should be a bool, if it's set to anything (not null)
        /// then MS Flow registers it as true
        /// </summary>
        [JsonProperty("value-folder-property")]
        public string ValueFolderProperty { get; }

        /// <summary>
        /// Backend value from either of operations (Open or Browse) output
        /// used to determine file type (.zip, .txt, etc.)
        /// </summary>
        [JsonProperty("value-media-property")]
        public string ValueMediaProperty { get; }

        /// <param name="open">
        /// Operation which will be called when you initially when you start picking folder/file
        /// </param>
        /// <param name="browse">
        /// Operation will be called when you browse through folders
        /// </param>
        /// <param name="valueTitle">
        /// User facing value path, these values will show up for user to choose.
        /// </param>
        /// <param name="valueFolderProperty">
        /// Backend value from either of operations (Open or Browse) output
        /// used to determine whether the output is a folder or a file
        /// </param>
        /// <param name="valueMediaProperty">
        /// Backend value from either of operations (Open or Browse) output
        /// used to determine file type (.zip, .txt, etc.)
        /// </param>
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
            Browse = browse;
            ValueTitle = valueTitle;
            ValueFolderProperty = valueFolderProperty;
            ValueMediaProperty = valueMediaProperty;
        }
    }
}