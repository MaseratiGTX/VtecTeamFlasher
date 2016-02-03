using System.Collections.Generic;

namespace Commons.Localization.LocalizationDataResources
{
    public class LocalizationDataResource
    {
        public List<string> PresentedLanguages { get; set; }
        
        public string DefaultLanguage { get; set; }

        public List<LocalizationDataItem> LocalizationDataItems { get; set; } 
    }
}