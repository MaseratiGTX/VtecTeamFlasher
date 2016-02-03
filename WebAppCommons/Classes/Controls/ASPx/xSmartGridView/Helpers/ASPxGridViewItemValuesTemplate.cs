using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.CommonObjects;
using Commons.Helpers.Objects;
using Commons.Reflections.PropertyValues.Fetching;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers
{
    public class ASPxGridViewItemValuesTemplate
    {
        public const char PROPERTY_NAME_START_MARKER = '[';
        public const char PROPERTY_NAME_END_MARKER = ']';
        
        public string ActualTemplate { get; private set; }
        
        public List<string> ItemPropertyNames { get; private set; }



        public ASPxGridViewItemValuesTemplate(string sourceTemplate)
        {
            ParseSourceTemplate(sourceTemplate);
        }



        private void ParseSourceTemplate(string sourceTemplate)
        {
            ActualTemplate = string.Empty;
            ItemPropertyNames = new List<string>();


            var currentPropertyName = string.Empty;

            var shouldUseCurrentChar = false;
            
            foreach (var character in sourceTemplate)
            {
                if (character == PROPERTY_NAME_START_MARKER)
                {
                    shouldUseCurrentChar = true;
                    
                    currentPropertyName = string.Empty;
                    
                    continue;
                }

                if (character == PROPERTY_NAME_END_MARKER)
                {
                    shouldUseCurrentChar = false;
                    
                    if (currentPropertyName.IsNotEmpty())
                    {
                        ItemPropertyNames.Add(currentPropertyName);

                        ActualTemplate = ActualTemplate + '{' + (ItemPropertyNames.Count - 1) + '}';
                    }
                    
                    continue;
                }

                if (shouldUseCurrentChar)
                {
                    currentPropertyName = currentPropertyName + character;
                }
                else
                {
                    ActualTemplate = ActualTemplate + character;
                }
            }
        }


        public string ApplyItemValues(object item)
        {
            return ActualTemplate.FillWith(FetchPropertyValues(item));
        }

        private object[] FetchPropertyValues(object item)
        {
            var propertyValues = item.FetchPropertyValues(ItemPropertyNames);
            
            return ItemPropertyNames.Select(x => propertyValues[x]).ToArray();
        }
    }
}