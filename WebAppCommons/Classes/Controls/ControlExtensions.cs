using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using Commons.Helpers.Collections.Generic;
using Commons.Helpers.Objects;

namespace WebAppCommons.Classes.Controls
{
    public static class ControlExtensions
    {
        public static Control FindControlSmart(this Control source, string expression = null, string ID = null)
        {
            if (expression.IsNotEmpty())
            {
                // ReSharper disable AssignNullToNotNullAttribute
                var IDRegex = new Regex(expression);
                // ReSharper restore AssignNullToNotNullAttribute

                return source.FindControlSmart(x => x.ID != null && IDRegex.IsMatch(x.ID));
            }

            if (ID.IsNotEmpty())
            {
                return source.FindControlSmart(x => x.ID != null && x.ID == ID);
            }

            return null;
        }

        public static Control FindControlSmart(this Control source, Predicate<Control> predicate)
        {
            if (predicate.Invoke(source))
            {
                return source;
            }


            var childControls = source.Controls.Cast<Control>();

            foreach (var childControl in childControls)
            {
                var result = childControl.FindControlSmart(predicate);

                if (result.NotFound()) continue;

                return result;
            }

            return null;
        }

        public static T FindControlSmart<T>(this Control source, Predicate<T> predicate) where T : Control
        {
            return (T)source.FindControlSmart(x => x is T && predicate.Invoke((T)x));
        }

        public static Control FindParentNamingContainer(this Control source, Func<Control, bool> expression)
        {
            while (true)
            {
                if (source == null) return null;
                if (expression(source.NamingContainer)) return source.NamingContainer;

                source = source.NamingContainer;
            }
        }


        public static IEnumerable<T> ChildControls<T>(this Control source) where T : Control
        {
            var childControls = source.Controls.Cast<Control>();

            foreach (var childControl in childControls)
            {
                if (childControl is T)
                {
                    yield return (T) childControl;
                }
                else
                {
                    foreach (var x in childControl.ChildControls<T>())
                    {
                        yield return x;
                    }
                }
            }
        }



        public static string ID(this Control source)
        {
            if (source == null) return null;

            return source.ID;
        }

        public static T SetID<T>(this T source, string value) where T: Control
        {
            if (source == null) return null;

            source.ID = value;

            return source;
        }


        public static string ClientID(this Control source)
        {
            if (source == null) return null;

            return source.ClientID;
        }


        public static string ChildID(this Control source, string parentClientID)
        {
            if (source == null) return null;
            
            if (parentClientID.IsEmpty()) return null;


            var parentClientIDPrefix = parentClientID + "_";

            if (source.ClientID.StartsWith(parentClientIDPrefix) == false) return null;


            return source.ClientID.Substring(parentClientIDPrefix.Length);
        }

        public static IEnumerable<string> ChildIDs<T>(this IEnumerable<T> source, string parentClientID) where T : Control
        {
            return source.Select(x => x.ChildID(parentClientID)).NotEmpty().Distinct();
        }

        
        public static string ToClientID(this Control source, string ID)
        {
            if (source == null) return null;

            return source.FindControlSmart(ID: ID).ClientID();
        }


        public static T Elements<T>(this T source, params Control[] childs) where T : Control
        {
            return source.Clear().Add(childs);
        }


        public static T Clear<T>(this T source) where T : Control
        {
            source.Controls.Clear();

            return source;
        }

        public static T Add<T>(this T source, params Control[] childs) where T : Control
        {
            if (childs == null) return source;

            foreach (var child in childs)
            {
                source.Controls.Add(child);
            }

            return source;
        }
    }
}