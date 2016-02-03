using Commons.Exceptions;
using Commons.Helpers.Objects;
using Commons.Validation.Assertions.Assertors;
using NHibernateContext.ADORepository;

namespace NHibernateContext.PersistenceValidation.ValidatorsBase
{
    public abstract class BasePersistenceValdator<T> : BaseAssertor, IPersistenceValidator where T : class 
    {
        public IADORepository ADORepository { get; private set; }

        
        public virtual T Validatable { get; protected set; }

        public virtual object ValidatableObject
        {
            get { return Validatable; }
        }



        protected BasePersistenceValdator(IADORepository adoRepository)
        {
            ADORepository = adoRepository;
        }



        public virtual BasePersistenceValdator<T> Validate(T entity)
        {
            Validatable = entity;

            return this;
        }

        public virtual IPersistenceValidator Validate(object entity)
        {
            if(entity == null)
            {
                throw new FormattedException("Переданный на валидацию объект не может быть NULL");
            }

            if (entity.IsNotInstanceOf(typeof (T)))
            {
                throw new FormattedException("Переданный на валидацию объект ('{0}') не является объектом типа '{1}'", entity.GetType().FullName, typeof (T).FullName);
            }

            return Validate((T) entity);
        }


        public abstract void OnSave();
        public abstract void OnDelete();
        
        
        public virtual void DropState()
        {
            Validatable = null;
        }


        public override void Return<TReturnException>(object key, string message, object context = null)
        {
            ReturnResult<TReturnException>(key, message, context, new object[] { key });
        }
    }
}