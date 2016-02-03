using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Commons.Helpers;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;

namespace Commons.Localization.LocalizationDataResources.Parsers
{
    public class LocalizationDataResourceParser 
    {
        private Stream SourceStream { get; set; }


        private Dictionary<string, string> ElementNameToLanguageMap { get; set; }

        private List<string> AllowedLanguages { get; set; }
        private List<string> PresentedLanguages { get; set; }
        private string DefaultLanguage { get; set; }
        private List<LocalizationDataItem> LocalizationDataItems { get; set; }



        public LocalizationDataResourceParser(Stream sourceStream)
        {
            SourceStream = sourceStream;
        }

        public LocalizationDataResourceParser(Stream sourceStream, List<string> allowedLangages) 
            : this(sourceStream)
        {
            AllowedLanguages = allowedLangages;
        }

        public LocalizationDataResourceParser(Stream sourceStream, params string[] allowedLangages)
            : this(sourceStream, allowedLangages != null ? allowedLangages.ToList() : null)
        {
        }


        public LocalizationDataResource Parse()
        {
            using (SourceStream)
            {
                var xDocument = XDocument.Load(SourceStream, LoadOptions.None);
                
                try
                {
                    var rootElement = xDocument.Root();

                    ParseDescriptionSection(rootElement.DescriptionSection());
                    
                    ParseItemsSection(rootElement.ItemsSection());
                    

                    return new LocalizationDataResource
                    {
                        PresentedLanguages = PresentedLanguages,
                        DefaultLanguage = DefaultLanguage,
                        LocalizationDataItems = LocalizationDataItems
                    };

                }
                catch(NullReferenceException)
                {
                    return null;
                }
                catch(ArgumentNullException)
                {
                    return null;
                }
                catch(InvalidOperationException)
                {
                    return null;
                }
            }
        }



        private void ParseDescriptionSection(XElement descriptionSection)
        {
            ParsePresentedLanguagesSection(descriptionSection.PresentedLanguages());
            
            ParseDefaultLanguageSection(descriptionSection.DefaultLanguage());
        }


        private void ParsePresentedLanguagesSection(XElement presentedLanguagesSection)
        {
            ElementNameToLanguageMap = presentedLanguagesSection
                .LanguageSections()
                .Select(
                    languageSection =>
                    {
                        // ReSharper disable PossibleNullReferenceException
                        var languageName = languageSection.Attribute("Name").Value;
                        // ReSharper restore PossibleNullReferenceException
                        var nodeName = languageSection.Attribute("NodeName").Value();

                        return new
                        {
                            LanguageName = languageName,
                            NodeName = nodeName ?? languageName
                        };
                    }
                )
                .Where(
                    languageNodeData => AllowedLanguages == null || AllowedLanguages.Contains(languageNodeData.LanguageName)
                )
                .ToDictionary(
                    x => x.NodeName,
                    x => x.LanguageName
                );


            PresentedLanguages = ElementNameToLanguageMap.Select(x => x.Value).ToList();
        }

        private void ParseDefaultLanguageSection(XElement defaultLanguageSection)
        {
            var defaultLanguage = defaultLanguageSection.Value();

            if(AllowedLanguages == null || AllowedLanguages.Contains(defaultLanguage))
            {
                DefaultLanguage = defaultLanguage;
            }
        }


        private void ParseItemsSection(XElement itemsSection)
        {
            LocalizationDataItems = itemsSection
                .ItemSections()
                .Select(
                    itemSection =>
                    {
                        var KEY = itemSection.Attribute("KEY").Value() ?? itemSection.Elements("KEY").Single().Value;


                        var VALUES = itemSection
                            .Elements()
                            .Where(
                                element => element.Name != "KEY"
                            )
                            .Select(
                                element => 
                                new
                                {
                                    ElementName = element.Name.ToString(), 
                                    // ReSharper disable RedundantAnonymousTypePropertyName
                                    Value = element.Value
                                    // ReSharper restore RedundantAnonymousTypePropertyName
                                }
                            )
                            .Select(
                                elementData =>
                                new
                                {
                                    Language = ElementNameToLanguageMap
                                        .ValueOrDefault(
                                            elementData.ElementName
                                        ),
                                    // ReSharper disable RedundantAnonymousTypePropertyName
                                    Value = elementData.Value
                                    // ReSharper restore RedundantAnonymousTypePropertyName
                                }
                            )
                            .Where(
                                languageData => languageData.Language != null
                            )
                            .ToDictionary(
                                languageData => languageData.Language,
                                languageData => languageData.Value
                            );


                        if (DefaultLanguage.IsNotEmpty())
                        {
                            if(VALUES.ContainsKey(DefaultLanguage) == false)
                            {
                                VALUES.Add(DefaultLanguage, KEY);
                            }
                        }


                        return new LocalizationDataItem
                        {
                            Key = KEY,
                            Values = VALUES
                        };
                    }
                )
                .ToList();
        }
    }
}