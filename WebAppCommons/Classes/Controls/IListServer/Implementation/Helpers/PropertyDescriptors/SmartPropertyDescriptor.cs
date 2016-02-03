using System;
using System.ComponentModel;
using Commons.Helpers.Objects;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers.PropertyDescriptors
{
    public class SmartPropertyDescriptor<T> : PropertyDescriptor
    {
        public PropertyDescriptor Source { get; private set; }


        public override Type ComponentType
        {
            get { return typeof(T); }
        }

        public override bool IsReadOnly
        {
            get { return Source.IsReadOnly; }
        }

        public override Type PropertyType
        {
            get { return Source.PropertyType; }
        }



        public SmartPropertyDescriptor(PropertyDescriptor source)
            : base(source)
        {
            Source = source;
        }



        public override object GetValue(object component)
        {
            return component.IsInstanceOf(Source.ComponentType) ? Source.GetValue(component) : null;
        }

        public override void SetValue(object component, object value)
        {
            if (component.IsNotInstanceOf(Source.ComponentType)) return;

            Source.SetValue(component, value);
        }


        public override bool CanResetValue(object component)
        {
            if (component.IsNotInstanceOf(Source.ComponentType)) return false;

            return Source.CanResetValue(component);
        }

        public override void ResetValue(object component)
        {
            if (component.IsNotInstanceOf(Source.ComponentType)) return;

            Source.ResetValue(component);
        }


        public override bool ShouldSerializeValue(object component)
        {
            if (component.IsNotInstanceOf(Source.ComponentType)) return false;

            return Source.ShouldSerializeValue(component);
        }
    }
}