using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WebAppCommons.Classes.Controls.IListServer.Implementation.Helpers.PropertyDescriptors
{
    public static class PropertyDescriptorHelper
    {
        public static List<PropertyDescriptor> AddFrom<T>(this List<PropertyDescriptor> source)
        {
            return source.AddFrom(typeof (T));
        }

        public static List<PropertyDescriptor> AddFrom(this List<PropertyDescriptor> source, Type type)
        {
            source.AddRange(
                TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>()
            );

            return source;
        }
    }
}