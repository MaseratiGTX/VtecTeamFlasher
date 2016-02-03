using System;
using System.ComponentModel;
using Commons.Helpers.Objects;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers.PropertyDescriptors
{
    public class SimplePropertyDescriptor<TComponent, TProperty> : PropertyDescriptor
    {
        public delegate TProperty GetValueHandler(TComponent component);

        public delegate void SetValueHandler(TComponent component, TProperty property);


        private readonly GetValueHandler getValueHandler;
        private readonly SetValueHandler setValueHandler;


        public override Type ComponentType
        {
            get { return typeof (TComponent); }
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return typeof (TProperty); }
        }


        public SimplePropertyDescriptor(string name, GetValueHandler getValueHandler, params Attribute[] attributes) : this(name, getValueHandler, null, attributes)
        {
        }

        public SimplePropertyDescriptor(string name, GetValueHandler getValueHandler, SetValueHandler setValueHandler, params Attribute[] attributes) : base(name, attributes)
        {
            this.getValueHandler = getValueHandler;
            this.setValueHandler = setValueHandler;
        }



        public override object GetValue(object component)
        {
            return getValueHandler((TComponent) component);
        }

        public override void SetValue(object component, object value)
        {
            setValueHandler.IfFound(x => x((TComponent) component, (TProperty) value));
        }


        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }


        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }
}
