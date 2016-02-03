using System.Collections.Generic;

namespace Commons.Localization.LocalizationDataResources
{
    public class LocalizationDataItem
    {
        public string Key { get; set; }
        
        public Dictionary<string, string> Values { get; set; }
    }
}