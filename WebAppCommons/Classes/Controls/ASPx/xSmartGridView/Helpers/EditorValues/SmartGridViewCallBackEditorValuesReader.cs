using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.CommonObjects;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Helpers.EditorValues
{
    public class SmartGridViewCallBackEditorValuesReader
    {
        protected string SourceText { get; set; }
        protected int CurrentPosition { get; set; }

        public List<SmartEditorValueInfo> Values { get; set; }



        public SmartGridViewCallBackEditorValuesReader(string sourceText)
        {
            SourceText = sourceText;
            Values = new List<SmartEditorValueInfo>();
        }



        public void Proccess()
        {
            CurrentPosition = 0;

            var number = GetNumber(';');
            if (number <= 0) return;

            var num = 0;
            while (num < number && ReadEditorValue()) ++num;
        }

        private bool ReadEditorValue()
        {
            var number1 = GetNumber();

            if (number1 < 0)
            {
                return false;
            }


            var number2 = GetNumber();

            if (number2 < 0)
            {
                Values.Add(new SmartEditorValueInfo(number1, null));

                ++CurrentPosition;
            }
            else
            {
                var str = SourceText.Substring(CurrentPosition, number2);

                CurrentPosition += number2 + 1;

                var value = (object)str;

                //TODO: пока просто заменил на более специфичный разделитель (также и в ASPxClientSmartListBox). возможно, стоит выделить отдельные ValueReader в зависимости от типа столбца.
                if (str.Contains("\u0007"))
                {
                    value = str.Split("\u0007", StringSplitOptions.RemoveEmptyEntries).ToArray();
                }

                Values.Add(new SmartEditorValueInfo(number1, value));
            }

            return true;
        }

        protected int GetNumber()
        {
            return GetNumber(',');
        }

        protected int GetNumber(char separator)
        {
            var pos = CurrentPosition;

            CurrentPosition = SourceText.IndexOf(separator, CurrentPosition);

            if (CurrentPosition < 0)
            {
                return -1;
            }

            var result = 0;

            if (!int.TryParse(SourceText.Substring(pos, CurrentPosition - pos), out result))
            {
                return -1;
            }

            ++CurrentPosition;

            return result;
        }
    }
}