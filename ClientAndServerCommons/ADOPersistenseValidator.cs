using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Commons.Validation.Assertions;
using NHibernateContext.ADORepository;
using NHibernateContext.PersistenceValidation.ValidatorsBase;

namespace ClientAndServerCommons
{
    public abstract class ADOPersistenseValidator<T> : BasePersistenceValdator<T> where T : AbstractDataObject
    {
        protected ADOPersistenseValidator(IADORepository adoRepository)
            : base(adoRepository)
        {
        }


        public override void OnSave()
        {
            if (Validatable.IsAlreadyPersisted())
            {
                AssertionHelper
                    .AssertAny(ADORepository.Entities<T>().Is(Validatable))
                    .Return("Сохранение невозможно. Вы пытаетесь сохранить сущность, которая уже была удалена");
            }
        }

        public override void OnDelete()
        {
            AssertionHelper
                .AssertFalse(Validatable.IsNewEntry())
                .Return("Удаление невозможно. Вы пытаетесь удалить еще не сохраненную сущность.");

            AssertionHelper
                .AssertAny(ADORepository.Entities<T>().Is(Validatable))
                .Return("Удаление невозможно. Вы пытаетесь удалить сущность, которая уже была удалена.");
        }
    }
}
