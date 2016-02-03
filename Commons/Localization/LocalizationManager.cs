using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using Commons.Helpers;
using Commons.Helpers.Cultures;
using Commons.Helpers.Objects;
using Commons.Localization.LanguageContextProviders;
using Commons.Localization.LocalizationDataResources;
using Commons.Localization.LocalizationDataResources.Parsers;
using Commons.Logging;

namespace Commons.Localization
{
    public class LocalizationManager
    {
        private readonly ReaderWriterLockSlim synchronizationObject = new ReaderWriterLockSlim();
        
        
        private readonly Dictionary<string, LocalizationDataItem> DataItemsRepository = new Dictionary<string, LocalizationDataItem>();

        private readonly List<string> AllowedLangages;


        public ILanguageContextProvider LanguageContextProvider { get; private set; }
        
        public bool IsInitialzed { get; private set; }

        public List<string> PresentedLanguages { get; private set; }

        public List<LanguageDescription> PresentedLanguagesDescriptions { get; private set; }



        public LocalizationManager(ILanguageContextProvider languageContextProvider)
        {
            LanguageContextProvider = languageContextProvider;

            IsInitialzed = false;

            PresentedLanguages = new List<string>();

            PresentedLanguagesDescriptions = null;
        }

        public LocalizationManager(ILanguageContextProvider languageContextProvider, IEnumerable<string> allowedLanguages) : this(languageContextProvider)
        {
            if(allowedLanguages != null)
            {
                AllowedLangages = allowedLanguages.ToList();
            }
        }



        public LocalizationManager SetLanguageContextProvider(ILanguageContextProvider value)
        {
            LanguageContextProvider = value;

            return this;
        }


        public LocalizationManager MarkAsInitialized()
        {
            InitializePresentedLanguagesDescriptions();

            IsInitialzed = true;

            return this;
        }

        private void InitializePresentedLanguagesDescriptions()
        {
            var sourceLanguagesCollection = AllowedLangages != null
                                                ? PresentedLanguages.OrderBy(x => AllowedLangages.IndexOf(x)).ToList()
                                                : PresentedLanguages;

            PresentedLanguagesDescriptions = sourceLanguagesCollection.Select(x => new LanguageDescription(x)).ToList();
        }


        public LocalizationManager AddResource(string resourceSystemPath)
        {
            AddResourceInternal(File.Open(resourceSystemPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));

            return this;
        }


        public LocalizationManager AddEmbeddedResource(string assemblyString, string resourceName)
        {
            return AddEmbeddedResource(Assembly.Load(assemblyString), resourceName);
        }

        public LocalizationManager AddEmbeddedResource(Assembly assembly, string resourceName)
        {
            AddResourceInternal(assembly.GetManifestResourceStream(resourceName));

            return this;
        }



        public string Localize(string expression)
        {
            return synchronizationObject.ProvideReadLock(x =>
                {
                    return LocalizeInternal(expression, LanguageContextProvider.CurrentLanguageName());
                }
            );
        }

        public string Localize(string expression, CultureInfo culture)
        {
            return synchronizationObject.ProvideReadLock(x =>
                {
                    return LocalizeInternal(expression, culture.ThreeLetterWindowsLanguageName());
                }
            );
        }

        public string Localize(string expression, string languageName)
        {
            return synchronizationObject.ProvideReadLock(x =>
                {
                    return LocalizeInternal(expression.Trim(), languageName.Trim());
                }
            );
        }




        private void AddResourceInternal(Stream resourceStream)
        {
            if(AllowedLangages.IsNotNull() && AllowedLangages.IsEmpty()) return;

            ConsumeLocalizationDataResource(
                new LocalizationDataResourceParser(resourceStream, AllowedLangages).Parse()
            );
        }

        private void ConsumeLocalizationDataResource(LocalizationDataResource localizationDataResource)
        {
            if (localizationDataResource == null)
            {
                throw new Exception("Заданный локализационный ресурс имеет не верный формат.");
            }

            if (IsInitialzed)
            {
                throw new Exception("Инициализация LocalizationManager уже завершена.");
            }


            foreach (var languageName in localizationDataResource.PresentedLanguages)
            {
                if(PresentedLanguages.Contains(languageName) == false)
                {
                    PresentedLanguages.Add(languageName);
                }
            }

            foreach (var localizationDataItem in localizationDataResource.LocalizationDataItems)
            {
                if(DataItemsRepository.ContainsKey(localizationDataItem.Key) == false)
                {
                    DataItemsRepository.Add(localizationDataItem.Key, localizationDataItem);       
                }
                else
                {
                    DataItemsRepository[localizationDataItem.Key] = localizationDataItem;       
                }
            }
        }


        private string LocalizeInternal(string expression, string languageName)
        {
            if (expression.IsEmpty())
            {
                return expression;
            }

            if (languageName.IsEmpty())
            {
                return expression;
            }

            
            var localizationDataItem = (LocalizationDataItem) null;

            if(DataItemsRepository.TryGetValue(expression, out localizationDataItem))
            {
                var result = (string) null;

                if(localizationDataItem.Values.TryGetValue(languageName, out result))
                {
                    return result;
                }
                
                TRACE
                (
                    "ВНИМАНИЕ! Не найдены данные по локализации выражения '{0}' для локали '{1}' .",
                    expression, languageName
                );

                return expression;
            }
            
            TRACE
            (
                "ВНИМАНИЕ! Не найдены данные по локализации выражения '{0}'.",
                expression
            );

            return expression;
        }


        #region TRACE IMPLEMENTATION

        public bool TRACE_ENABLED { get; private set; }

        public LocalizationManager ENABLE_TRACE(bool value = true)
        {
            if (IsInitialzed)
            {
                throw new Exception("Инициализация LocalizationManager уже завершена.");
            }

            TRACE_ENABLED = value;

            return this;
        }

        public LocalizationManager DISABLE_TRACE(bool value = true)
        {
            if (IsInitialzed)
            {
                throw new Exception("Инициализация LocalizationManager уже завершена.");
            }

            TRACE_ENABLED = !value;

            return this;
        }

        private void TRACE(string format, params object[] args)
        {
            if(TRACE_ENABLED)
            {
                Log.Debug(format, args);
            }
        }

        #endregion
    }
}