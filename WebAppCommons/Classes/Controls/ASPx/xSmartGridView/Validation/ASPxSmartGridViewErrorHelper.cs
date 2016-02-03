using System;
using System.Collections.Generic;
using System.Linq;
using Commons.Helpers.Collections.Generic;
using Commons.Serialization;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.ErrorObjects;
using WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation.Exceptions;

namespace WebAppCommons.Classes.Controls.ASPx.xSmartGridView.Validation
{
    public class ASPxSmartGridViewErrorHelper
    {
        private List<Func<Exception, BaseErrorObject>> ConvertionFuctionsRepository { get; set; }



        public ASPxSmartGridViewErrorHelper() 
        {
            ConvertionFuctionsRepository = new List<Func<Exception, BaseErrorObject>>();

            InitializeDefaultConvertions();
        }



        private void InitializeDefaultConvertions()
        {
            AddConvertionFuction(
                (Func<SourceElementNotFoundException, SourceElementNotFoundErrorObject>) (
                    x => new SourceElementNotFoundErrorObject
                    {
                        Message = x.Message
                    }
                )
            );

            AddConvertionFuction(
                (Func<SourceElementValidationException, SourceElementValidationErrorObject>) (
                    x => new SourceElementValidationErrorObject
                    {
                        Message = x.Message,
                        FieldName = x.FieldName
                    }
                )
            );
        }


        public ASPxSmartGridViewErrorHelper AddConvertionFuction<T, F>(Func<T, F> convertionFunction)
            where T : Exception
            where F : BaseErrorObject
        {
            ConvertionFuctionsRepository.Add(
                x => x is T ? convertionFunction.Invoke((T)x) : null
            );

            return this;
        }


        public string Process(Exception exception)
        {
            if (exception == null) return null;

            var errorObject = ConvertionFuctionsRepository.Select(x => x.Invoke(exception)).EvictNull().FirstOrDefault();

            if (errorObject != null)
            {
                return errorObject.SerializeToJSON();
            }

            return null;
        }
    }
}