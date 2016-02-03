using System;
using System.Configuration;
using Commons.Helpers.Objects;

namespace WebAreaCommons.Classes.Providers.Configurations
{
    public class EDocumentUploadParametersProvider
    {
        private const int DEFAULT_EDOCUMENT_UPLOAD_PARAMETERS_MAX_FILE_SIZE = 512000;
        private const string DEFAULT_EDOCUMENT_UPLOAD_PARAMETERS_POSSIBLE_FILE_EXTENSION = ".edoc";

        
        public int GetMaxFileSize()
        {
            var appSetting = ConfigurationManager.AppSettings["EDocument.UploadParameters.MaxFileSize"];

            return appSetting.SafelyParseInt() ?? DEFAULT_EDOCUMENT_UPLOAD_PARAMETERS_MAX_FILE_SIZE;
        }

        
        public string[] GetPossibleExtensions()
        {
            var appSetting = ConfigurationManager.AppSettings["EDocument.UploadParameters.PossibleFileExtension"];
            var arrayItemSeparators = new[] { "/", "\\", "|" };

            var serializedResult = appSetting.NotFound() ? DEFAULT_EDOCUMENT_UPLOAD_PARAMETERS_POSSIBLE_FILE_EXTENSION : appSetting;


            return serializedResult.Split(arrayItemSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}