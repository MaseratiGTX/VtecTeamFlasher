using Commons.Localization;
using WebAppCommons.Classes.Configuration;
using WebAppCommons.Classes.Localization.LanguageContextProviders;

namespace WebAppCommons.Classes.Localization
{
    public static class ApplicationLocalizationConfiguration
    {
        public static void Configure(LocalizationManager localizationManager)
        {
            localizationManager
                .ENABLE_TRACE(
                    ASPNetConfiguration.IsDebuggingEnabled
                )
                .AddEmbeddedResources(
                    "WebAreaCommons, Version=3.0.0.0, Culture=neutral, PublicKeyToken=null",
                    "WebAreaCommons.Localization",
                    "base-localizationdata.xml"
                )
                .AddResourceByVirtualPath(
                    "Localization/area-specific-localizationdata.xml"
                )
                .SetLanguageContextProvider(
                    new CommonLanguageContextProvider(
                        LocalizationConstants.LANGUAGE_CONTEXT_KEY,
                        localizationManager.PresentedLanguages,
                        Languages.Russian
                    )
                )
                .MarkAsInitialized();
        }
    }
}